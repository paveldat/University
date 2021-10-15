using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using MetroFramework;

namespace WindowsFormsApp1
{
    public partial class SecondCustomControl : UserControl
    {
        OleDbConnection sqlConnection;

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        public SecondCustomControl()
        {
            InitializeComponent();

            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##TESTPAV;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            viewTable();

            //добавление в метро комбо бокс статей
            string str = "SELECT NAME FROM ARTICLES";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy HH:mm:ss";
        }

        private void metroButton1_Click(object sender, EventArgs e) //добавление
        {
            if ("".Equals(metroTextBox1.Text) || "".Equals(comboBox1.Text)
                || dateTimePicker1 is null || "".Equals(metroTextBox2.Text))
            {
                //MetroMessageBox.Show(this, "Пожалуйста, введите название!", "Ошибка");
                this.Alert("Пожалуйста, заполните все поля", Form_Alert.enmType.Warning);
            }
            else
            {
                string st = "INSERT INTO OPERATIONS (ARTICLE_ID, DEBIT, CREDIT, CREATE_DATE, USER_ID) " +
                            "VALUES ((SELECT ID FROM ARTICLES WHERE NAME = '" + comboBox1.Text + "') " +
                            ", " + metroTextBox1.Text + "" +
                            ", " + metroTextBox2.Text + "" +
                            ", to_timestamp('" + dateTimePicker1.Text + "', 'DD-MM-RR HH24:MI:SS.FF') " +
                            ", (SELECT ID FROM USERS WHERE LOGIN = '1'))";
                DataSet dataSet = new DataSet();
                OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                DA.Fill(dataSet);

                viewTable();

                this.Alert("Операция для статьи \"" + comboBox1.Text + "\" успешно создана", Form_Alert.enmType.Success);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e) //удаление
        {
            string res = metroGrid1.CurrentRow.Cells[0].FormattedValue.ToString();
            string res2 = metroGrid1.CurrentRow.Cells[3].FormattedValue.ToString();
            string checkBalance = metroGrid1.CurrentRow.Cells[4].FormattedValue.ToString();
            string str = "delete from operations where article_id = (select id from articles where name = '"+ res +"') " +
                "and balance_id is null and create_date = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS')";

            DialogResult result = MetroMessageBox.Show(this, "Вы действительно хотите удалить операцию \nдля статьи \"" + res + "\"?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if ("".Equals(checkBalance))
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    this.Alert("Операция для статьи \"" + res + "\" удалена успешно", Form_Alert.enmType.Success);

                    viewTable();
                }
                else
                {
                    this.Alert("Вы не можете удалить операцию \"" + res + "\",\nт.к. она фигурирует в " +
                        "балансе №" + checkBalance + "", Form_Alert.enmType.Error);
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            string str = "select a.name" +
                ", SUM(o.debit)" +
                ", max(o.create_date) " +
                "from balance b " +
                "join operations o " +
                "on o.balance_id = b.id " +
                "join articles a " +
                "on a.id = o.article_id " +
                "where o.balance_id = (select id from balance fetch FIRST 1 ROWS ONLY) " +
                "group by a.name";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            metroGrid1.DataSource = table;

            ////////////////////////////////////////////////////////////////////////
            this.metroGrid1.Columns[2].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

            foreach (DataGridViewColumn column in metroGrid1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            metroGrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            ///////////////////////////////////////////////////////////////////////
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            viewTable();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            string str = "Select sum(debit-credit) as amount " +
                            "From Operations " +
                            "Where create_date = to_timestamp('" + dateTimePicker2.Text + "', 'DD-MM-RR HH24:MI:SS.FF')";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            metroGrid1.DataSource = table;
        }

        private void metroButton6_Click(object sender, EventArgs e) //изменение
        {
            if ("".Equals(comboBox2.Text))
            {
                this.Alert("Пожалуйста, выберите, что хотите изменить!", Form_Alert.enmType.Warning);
            }
            else
            {
                try
                {
                    string selectedState = comboBox2.Text;
                    string res1 = metroGrid1.CurrentRow.Cells[0].FormattedValue.ToString();
                    string res2 = metroGrid1.CurrentRow.Cells[3].FormattedValue.ToString();
                    switch (selectedState)
                    {
                        case "Статья":
                            if ("".Equals(comboBox1.Text))
                            {
                                this.Alert("Пожалуйста, выберите статью!", Form_Alert.enmType.Warning);
                            }
                            else
                            {
                                string st = "update OPERATIONS set ARTICLE_ID = (SELECT ID FROM ARTICLES WHERE NAME = '" + comboBox1.Text + "') " +
                                "where article_id = (select id from articles where name = '" + res1 + "') " +
                                "and create_date = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS')";
                                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                viewTable();
                            }
                            break;
                        case "Приход":
                            if ("".Equals(metroTextBox1.Text))
                            {
                                this.Alert("Пожалуйста, введите приход!", Form_Alert.enmType.Warning);
                            }
                            else
                            {
                                string st = "update OPERATIONS set DEBIT = " + metroTextBox1.Text + " " +
                                "where article_id = (select id from articles where name = '" + res1 + "') " +
                                "and create_date = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS')";
                                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                viewTable();
                            }
                            break;
                        case "Расход":
                            if ("".Equals(metroTextBox2.Text))
                            {
                                this.Alert("Пожалуйста, введите расход!", Form_Alert.enmType.Warning);
                            }
                            else
                            {
                                string st = "update OPERATIONS set CREDIT = " + metroTextBox2.Text + " " +
                                "where article_id = (select id from articles where name = '" + res1 + "') " +
                                "and create_date = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS')";
                                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                viewTable();
                            }
                            break;
                        case "Дата операции":
                            if ("".Equals(dateTimePicker1.Text))
                            {
                                this.Alert("Пожалуйста, введите новую дату!", Form_Alert.enmType.Warning);
                            }
                            else
                            {
                                string st = "update OPERATIONS set create_date = TO_TIMESTAMP('" + dateTimePicker1.Text + "', 'DD-MM-RR HH24:MI:SS') " +
                                "where article_id = (select id from articles where name = '" + res1 + "') " +
                                "and create_date = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS')";
                                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                viewTable();
                            }
                            break;
                    }
                } 
                catch (OleDbException exp)
                {
                    MetroMessageBox.Show(this, exp.Message, "Ошибка");
                }
            }
        }

        private void viewTable()
        {
            string str = "SELECT a.name " +
                             ", o.DEBIT " +
                             ", o.CREDIT " +
                             ", o.CREATE_DATE " +
                             ", o.BALANCE_ID " +
                        "FROM Articles a " +
                                 "JOIN Operations o " +
                                           "ON a.id = o.article_id " +
                                           "union " +
                         "SELECT a.name " +
                             ", o.DEBIT " +
                             ", o.CREDIT " +
                             ", o.CREATE_DATE " +
                             ", o.BALANCE_ID " +
                        "FROM Articles a " +
                                 "LEFT JOIN Operations o " +
                                           "ON a.id = o.article_id " +
                                           "WHERE o.article_id IS NULL";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            metroGrid1.DataSource = table;

            //форматирование таблицы и даты в столбце
            this.metroGrid1.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";

            foreach (DataGridViewColumn column in metroGrid1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            metroGrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            metroGrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            metroGrid1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
