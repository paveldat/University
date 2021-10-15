using System;
using System.Data;
using MetroFramework;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class FirstCustomControl : UserControl
    {
        OleDbConnection sqlConnection;

        public FirstCustomControl()
        {
            InitializeComponent();

            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##TESTPAV;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            getArticles();

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd-MM-yyyy HH:mm:ss";

            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd-MM-yyyy HH:mm:ss";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";

            //добавление в метро комбо бокс статей
            string str = "SELECT NAME FROM ARTICLES";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT NAME FROM ARTICLES";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox2.Items.Add(table.Rows[i].ItemArray[0].ToString());
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void metroButton1_Click(object sender, EventArgs e) //добавить статью
        {
            if ("".Equals(metroTextBox1.Text))
            {
                //MetroMessageBox.Show(this, "Пожалуйста, введите название!", "Ошибка");
                this.Alert("Пожалуйста, введите название!", Form_Alert.enmType.Warning);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM articles WHERE name = '" + metroTextBox1.Text + "'"; //уникальность статьи
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (cnt == "0")
                {
                    string st = "insert into articles (name) values ('" + metroTextBox1.Text + "')";
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                    DA.Fill(dataSet);

                    getArticles();

                    this.Alert("Статья \"" + metroTextBox1.Text + "\" успешно создана", Form_Alert.enmType.Success);
                }
                else
                {
                    this.Alert("Название статьи не должно повторяться", Form_Alert.enmType.Error);
                    //MetroMessageBox.Show(this, "Логин должен быть уникальным!", "Ошибка");
                }
            }
        }

        private void metroButton2_Click(object sender, EventArgs e) //удалить статью
        {
            string res = metroGrid1.CurrentRow.Cells[0].FormattedValue.ToString();

            string str_bal = "declare " +
                "id_ number; " +
                "name_ VARCHAR2(50 BYTE) := '" + res + "'; " +
                "begin " +
                "select id into id_ from articles where name = name_; " +
                "Delete From Operations o " +
                "Where o.article_id = id_; " +
                "Delete From Articles a " +
                "Where a.id = id_; " +
                "commit; " +
                "end;";

            string str = "delete from ARTICLES where NAME = '" + res + "'";

            string into = "select count(*) " +
                    "from operations " +
                    "where balance_id is null " +
                    "and article_id = (select id from articles where name = '" + res + "')"; //проверка на нефигурируемость в балансах
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            into = "select count(*) " +
                    "from operations " +
                    "where article_id = (select id from articles where name = '" + res + "')"; //проверка на нефигурируемость в операциях
            sqlConnection.Open();
            cmd = new OleDbCommand(into, sqlConnection);
            string cnt2 = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("0".Equals(cnt2))
            {
                DialogResult result = MetroMessageBox.Show(this, "Вы действительно хотите удалить статью \"" + res + "\"?", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    this.Alert("Статья \"" + res + "\" удалена успешно", Form_Alert.enmType.Success);

                    getArticles();
                }
            }
            else if (!"0".Equals(cnt))
            {
                DialogResult result = MetroMessageBox.Show(this, "Вы действительно хотите удалить статью \"" + res + "\"?\n" +
                    "Она может фигурировать в операциях.", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str_bal, sqlConnection); //выскакивает ошибка при удалении по этой ветке
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    this.Alert("Статья \"" + res + "\" удалена успешно", Form_Alert.enmType.Success);

                    getArticles();
                }
            }
            else
            {
                this.Alert("Статья \"" + res + "\" фигурирует в балансе,\nпоэтому ее нельзя удалить", Form_Alert.enmType.Warning);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e) //изменить статью
        {
            if ("".Equals(metroTextBox1.Text))
            {
                this.Alert("Пожалуйста, введите название\nновой статьи!", Form_Alert.enmType.Warning);
            }
            else
            {
                string res1 = metroGrid1.CurrentRow.Cells[0].FormattedValue.ToString();

                string into = "SELECT COUNT(*) FROM articles WHERE name = '" + metroTextBox1.Text + "'"; //уникальность статьи
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                into = "select count(*) " +
                    "from operations " +
                    "where balance_id is null " +
                    "and article_id = (select id from articles where name = '" + res1 + "')"; //проверка на нефигурируемость
                sqlConnection.Open();
                cmd = new OleDbCommand(into, sqlConnection);
                string cnt2 = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if ("0".Equals(cnt))
                {
                    if (!"0".Equals(cnt2))
                    {
                        string st = "update ARTICLES set name = '" + metroTextBox1.Text + "' where name = '" + res1 + "'";
                        DataSet dataSet = new DataSet();
                        OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                        DA.Fill(dataSet);

                        getArticles();

                        this.Alert("Статья \"" + res1 + "\" успешно изменена", Form_Alert.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Статья \"" + res1 + "\" фигурирует в балансе,\nпоэтому ее нельзя изменить", Form_Alert.enmType.Warning);
                    }
                }
                else
                {
                    this.Alert("Название статьи не должно повторяться", Form_Alert.enmType.Error);
                    //MetroMessageBox.Show(this, "Логин должен быть уникальным!", "Ошибка");
                }
            }
        }

        private void getArticles()
        {
            string str = "select a.name " +
                            "from articles a";
            DataTable table = new DataTable();
            OleDbDataAdapter DA1 = new OleDbDataAdapter(str, sqlConnection);
            DA1.Fill(table);
            metroGrid1.DataSource = table;
        }

        private void metroButton7_Click(object sender, EventArgs e) //статьи без операций
        {
            string str = "SELECT DISTINCT a.name " +
                "FROM Articles a " +
                "left join Operations o " +
                "on a.id = o.article_id " +
                "where not exists (SELECT 1 " +
                "FROM OPERATIONS o " +
                "where a.id = o.article_id " +
                "and o.create_date > to_timestamp('" + dateTimePicker3.Text + "', 'DD-MM-RRRR HH24:MI:SS.FF') " +
                "and o.create_date < to_timestamp('" + dateTimePicker4.Text + "', 'DD-MM-RRRR HH24:MI:SS.FF'))";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            metroGrid1.DataSource = table;
        }

        private void metroButton4_Click(object sender, EventArgs e) //все статьи
        {
            getArticles();
        }

        private void metroButton5_Click(object sender, EventArgs e) //сумма расходов
        {
            if ("".Equals(comboBox1.Text))
            {
                this.Alert("Пожалуйста, выберите название статьи!", Form_Alert.enmType.Warning);
            }
            else
            {
                string str = "SELECT a.name " +
                ", Sum(o.credit) " +
                "From Operations o " +
                "inner join Articles a " +
                "on a.id = o.article_id " +
                "Where a.name='" + comboBox1.Text + "' " +
                "and o.create_date > to_timestamp('" + dateTimePicker3.Text + "', 'DD-MM-RRRR HH24:MI:SS.FF') " +
                "and o.create_date < to_timestamp('" + dateTimePicker4.Text + "', 'DD-MM-RRRR HH24:MI:SS.FF') " +
                "group by a.name";
                DataTable table = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DA.Fill(table);
                metroGrid1.DataSource = table;
            }
        }

        private void metroButton6_Click(object sender, EventArgs e) //поток
        {
            string str = "SELECT round(SUM(o.DEBIT-o.credit)/t.percantage*100, 2) as percantage FROM operations o, " +
                                                                           "(SELECT SUM(AMOUNT) AS percantage " +
                                                                            "FROM BALANCE " +
                                                                            "where create_date " +
                                                                                      "BETWEEN TO_DATE('" + dateTimePicker1.Text + "', 'DD.MM.YY') " +
                                                                                      "and TO_DATE('" + dateTimePicker2.Text + "', 'DD.MM.YY')) t " +
                                    "where o.article_id = (select id from ARTICLES where name = '" + comboBox2.Text + "') " +
                                      "and o.create_date " +
                                        "BETWEEN TO_DATE('" + dateTimePicker1.Text + "', 'DD.MM.YY') " +
                                        "and TO_DATE('" + dateTimePicker2.Text + "', 'DD.MM.YY') " +
                                    "group by t.percantage";
            DataTable table = new DataTable();
            OleDbDataAdapter DA1 = new OleDbDataAdapter(str, sqlConnection);
            DA1.Fill(table);
            metroGrid1.DataSource = table;
        }
    }
}
