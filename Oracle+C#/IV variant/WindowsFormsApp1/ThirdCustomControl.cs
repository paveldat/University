using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using MetroFramework;

namespace WindowsFormsApp1
{
    public partial class ThirdCustomControl : UserControl
    {
        OleDbConnection sqlConnection;

        public ThirdCustomControl()
        {
            InitializeComponent();
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##TESTPAV;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            getBalance();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy HH:mm:ss";

            //добавление в метро комбо бокс статей
            string str = "SELECT NAME FROM ARTICLES";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void metroButton1_Click(object sender, System.EventArgs e) //создать баланс
        {
            if (dateTimePicker1.Value.Date >= dateTimePicker2.Value.Date)
            {
                this.Alert("Дата начала должна быть\nменьше даты конца", Form_Alert.enmType.Warning);
            }
            else
            {
                string st = "declare " +
                  "debit_ number; " +
                  "credit_ number; " +
                  "begin " +
                  "select sum(debit), sum(credit) into debit_, credit_ " +
                  "from operations " +
                  "where create_date > to_timestamp('" + dateTimePicker1.Text + "', 'DD-MM-YYYY HH24:MI:SS') " +
                  "and create_date < to_timestamp('" + dateTimePicker2.Text + "', 'DD-MM-YYYY HH24:MI:SS'); " +
                  "Insert Into Balance(create_date, debit, credit, amount) " +
                  "Values(systimestamp, debit_, credit_, debit_-credit_); " +
                  "update operations " +
                  "set balance_id = (select id from balance ORDER BY id desc FETCH first 1 rows only) " +
                  "where create_date > to_timestamp('" + dateTimePicker1.Text + "', 'DD-MM-YYYY HH24:MI:SS') " +
                  "and create_date < to_timestamp('" + dateTimePicker2.Text + "', 'DD-MM-YYYY HH24:MI:SS'); " +
                  "commit; " +
                  "end; ";
                DataSet dataSet = new DataSet();
                OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                DA.Fill(dataSet);

                getBalance();

                this.Alert("Баланс успешно создан", Form_Alert.enmType.Success);
            }

        }

        private void getBalance()
        {
            string str = "select create_date, debit, credit, amount from balance";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            metroGrid1.DataSource = table;

            //форматирование таблицы и даты в столбце
            this.metroGrid1.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

            foreach (DataGridViewColumn column in metroGrid1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            metroGrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            metroGrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            metroGrid1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void metroButton2_Click(object sender, System.EventArgs e) //показать все балансы
        {
            getBalance();
        }

        private void metroButton3_Click(object sender, System.EventArgs e) //удалить убыточный
        {
            string str = "declare " +
                "b_id number; " +
                "min_balance number; " +
                "begin " +
                "Select Min(amount) " +
                "into min_balance " +
                "From Balance; " +
                "Select b.id " +
                "into b_id " +
                "From Balance b " +
                "Where b.amount = min_balance; " +
                "Delete From Operations o " +
                "Where o.balance_id = b_id; " +
                "Delete From Balance b " +
                "Where b.id = b_id; " +
                "end;";

            DialogResult result = MetroMessageBox.Show(this, "Вы действительно хотите удалить самый убыточный баланс?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                this.Alert("Баланс и операции удалены успешно", Form_Alert.enmType.Success);

                getBalance();
            }
        }

        private void metroButton4_Click(object sender, System.EventArgs e) //количество
        {
            if ("".Equals(comboBox1.Text))
            {
                this.Alert("Пожалуйста, выберите название статьи!", Form_Alert.enmType.Warning);
            }
            else
            {
                string str = "Select count(*) " +
                                "from(select a.name, o.balance_id " +
                            "From Operations o " +
                                     "inner join Balance b " +
                                                "On b.id = o.balance_id " +
                                     "inner join Articles a " +
                                                "On a.id = o.article_id " +
                            "Where a.name = '" + comboBox1.Text + "' " +
                            "group by a.name, o.BALANCE_ID)";
                DataTable table = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DA.Fill(table);
                metroGrid1.DataSource = table;
            }
        }
    }
}
