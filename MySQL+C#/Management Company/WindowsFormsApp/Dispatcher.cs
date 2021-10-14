using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Dispatcher : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Dispatcher(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=UpComany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);

            string str = "SELECT FIO FROM Clients";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox2.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT FIO FROM Executor";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT FIO FROM Executor";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox7.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT FIO FROM Executor";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox5.Items.Add(table.Rows[i].ItemArray[0].ToString());

            //заявки
            str = "select * from BidDispatcher";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            //клиенты
            str = "select c.FIO" +
                ", c.Adress" +
                ", c.Phone " +
                "from Clients c";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            //время исполнителя
            str = "select es.ExecutorSchedule_id as NumExec" +
                ", FIO" +
                ", Phone" +
                ", Time " +
                "from ExecutorSchedule es " +
                "full join Executor e " +
                "on e.Executor_id = es.Executor_id " +
                "full join LeadTime lt " +
                "on lt.LeadTime_id = es.LeadTime_id";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e) //Заявки.создать
        {
            if (textBox3.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "BEGIN TRANSACTION; " +
                                "INSERT INTO ExecutorSchedule values ((select e.Executor_id from Executor e where e.FIO = '" + comboBox1.Text + "'), null); " +
                                "INSERT INTO Bid VALUES (CURRENT_TIMESTAMP" +
                                                        ", (select top 1 es.ExecutorSchedule_id from ExecutorSchedule es order by es.ExecutorSchedule_id desc)" +
                                                        ", 0" +
                                                        ", '" + textBox3.Text + "'" +
                                                        ", (select c.Client_id from Clients c where c.FIO = '" + comboBox2.Text + "')" +
                                                        ", null" +
                                                        ", (select User_id from Users where Login = '1')); " +
                            "COMMIT;";
                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                string str = "select * from BidDispatcher";
                DataTable table = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button2_Click(object sender, EventArgs e) //Заявки.изменить
        {
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string selectedState = comboBox3.Text;
                string result = textBox1.Text;
                string res1 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString();
                switch (selectedState)
                {
                    case "Исполнитель":
                        if (comboBox1.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, выберите исполнителя!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "Update ExecutorSchedule " +
                                        "set Executor_id = (select e.Executor_id from Executor e where e.FIO = '"+ comboBox1.Text +"') " +
                                        "where ExecutorSchedule_id = "+ res1 +"";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            string str2 = "select * from BidDispatcher";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView1.DataSource = table;
                        }
                        break;
                    case "Статус":
                        if (textBox1.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, введите статус!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            if (textBox1.Text == "0" || textBox1.Text == "1")
                            {
                                string str = "Update Bid set BidStatus = " + textBox1.Text + " where ExecutorSchedule_id = " + res1 + "";
                                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select * from BidDispatcher";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView1.DataSource = table;
                            }
                            else
                                MessageBox.Show("Пожалуйста, введите корректный статус, он может быть только 1 или 0!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                    case "Вид работ":
                        if (textBox3.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, введите тип работ!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string str = "Update Bid set TypeWork = '" + textBox3.Text + "' where ExecutorSchedule_id = " + res1 + "";
                            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select * from BidDispatcher";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView1.DataSource = table;
                        }
                        break;
                    case "Клиент":
                        if (comboBox2.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, выберите клиента!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string str = "Update Bid " +
                                         "set Client_id = (select Client_id from Clients where FIO = '"+ comboBox2.Text +"') " +
                                         "where ExecutorSchedule_id = " + res1 + "";
                            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select * from BidDispatcher";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView1.DataSource = table;
                        }
                        break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //заявки.удалить
        {
            string res = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();
            string res1 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString();
            string str = "delete from Bid where TypeWork = '" + res + "' and ExecutorSchedule_id = "+ res1 +"";
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select * from BidDispatcher";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e) //Кабинет
        {
            MyAcc form = new MyAcc(login);
            form.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e) //Клиенты.создать
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (textBox6.Text.Length != 11)
                    MessageBox.Show("Пожалуйста, проверьте корректность номера, он должен содержать 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                else
                {
                    string st = "insert into Clients values ('" + textBox5.Text + "', '" + textBox6.Text + "', '" + textBox10.Text + "')";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str2 = "select c.FIO" +
                                    ", c.Adress" +
                                    ", c.Phone " +
                                    "from Clients c";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                    DA2.Fill(table);
                    dataGridView2.DataSource = table;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //Клиенты.изменить
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
                string res1 = dataGridView2.CurrentRow.Cells[1].FormattedValue.ToString();
                string res2 = dataGridView2.CurrentRow.Cells[2].FormattedValue.ToString();

                string selectedState = comboBox4.Text;
                string result = textBox4.Text;
                switch (selectedState)
                {
                    case "ФИО":
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update Clients set FIO = '"+ textBox4.Text + "' " +
                                        "where FIO = '" + res + "' and Adress = '" + res1 + "' and Phone = '" + res2 + "'";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            string str2 = "select c.FIO" +
                                    ", c.Adress" +
                                    ", c.Phone " +
                                    "from Clients c";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView2.DataSource = table;
                        }
                        break;
                    case "Номер телефона":
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else if (textBox4.Text.Length != 11)
                            MessageBox.Show("Пожалуйста, проверьте корректность номера, он должен содержать 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                        else
                        {
                            string str = "update Clients set Phone = '" + textBox4.Text + "' " +
                                        "where FIO = '" + res + "' and Adress = '" + res1 + "' and Phone = '" + res2 + "'";
                            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select c.FIO" +
                                    ", c.Adress" +
                                    ", c.Phone " +
                                    "from Clients c";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView2.DataSource = table;
                        }
                        break;
                    case "Адрес":
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string str = "update Clients set Adress = '" + textBox4.Text + "' " +
                                        "where FIO = '" + res + "' and Adress = '" + res1 + "' and Phone = '" + res2 + "'";
                            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select c.FIO" +
                                    ", c.Adress" +
                                    ", c.Phone " +
                                    "from Clients c";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView2.DataSource = table;
                        }
                        break;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //Клиенты.удалить
        {
            string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
            string res1 = dataGridView2.CurrentRow.Cells[1].FormattedValue.ToString();
            string res2 = dataGridView2.CurrentRow.Cells[2].FormattedValue.ToString();
            string str = "delete from Clients where FIO = '"+ res +"' and Adress = '"+ res1 +"' and Phone = '"+ res2 +"'";
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select c.FIO" +
                ", c.Adress" +
                ", c.Phone " +
                "from Clients c";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView2.DataSource = table;
            }
        }

        private void button11_Click(object sender, EventArgs e) //Время.изменить
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

                if (textBox7.Text == "")
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    string st = "BEGIN TRANSACTION; " +
                        "insert into LeadTime values ('"+ textBox7.Text +"'); " +
                        "update ExecutorSchedule set LeadTime_id = (select top 1 LeadTime_id from LeadTime order by LeadTime_id desc) where ExecutorSchedule_id = "+ res +"; " +
                        "commit;";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str2 = "select es.ExecutorSchedule_id as NumExec" +
                                ", FIO" +
                                ", Phone" +
                                ", Time " +
                                "from ExecutorSchedule es " +
                                "full join Executor e " +
                                "on e.Executor_id = es.Executor_id " +
                                "full join LeadTime lt " +
                                "on lt.LeadTime_id = es.LeadTime_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                    DA2.Fill(table);
                    dataGridView3.DataSource = table;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e) //Время.удалить
        {
            string res = dataGridView3.CurrentRow.Cells[1].FormattedValue.ToString();
            string res1 = dataGridView3.CurrentRow.Cells[2].FormattedValue.ToString();
            string res2 = dataGridView3.CurrentRow.Cells[3].FormattedValue.ToString();
            string str;
            if (res2 == "")
            {
                str = "delete from ExecutorSchedule " +
                            "where ExecutorSchedule_id = (select ExecutorSchedule_id " +
                                                            "from ExecutorSchedule es " +
                                                            "full join Executor e " +
                                                            "on es.Executor_id = e.Executor_id " +
                                                            "full join LeadTime lt " +
                                                            "on lt.LeadTime_id = es.LeadTime_id " +
                                                            "where e.FIO = '"+ res +"' " +
                                                            "and Phone = '"+ res1 +"' " +
                                                            "and Time is null)";
            }
            else
            {
                str = "BEGIN TRANSACTION; " +
                    "delete from ExecutorSchedule " +
                            "where ExecutorSchedule_id = (select ExecutorSchedule_id " +
                                                            "from ExecutorSchedule es " +
                                                            "full join Executor e " +
                                                            "on es.Executor_id = e.Executor_id " +
                                                            "full join LeadTime lt " +
                                                            "on lt.LeadTime_id = es.LeadTime_id " +
                                                            "where e.FIO = '" + res + "' " +
                                                            "and Phone = '" + res1 + "' " +
                                                            "and Time = '"+ res2 + "'); " +
                      "delete from LeadTime where Time = '" + res2 + "'; " +
                      "commit;"; ;
            }
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select es.ExecutorSchedule_id as NumExec" +
                                ", FIO" +
                                ", Phone" +
                                ", Time " +
                                "from ExecutorSchedule es " +
                                "full join Executor e " +
                                "on e.Executor_id = es.Executor_id " +
                                "full join LeadTime lt " +
                                "on lt.LeadTime_id = es.LeadTime_id";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView3.DataSource = table;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Время.показать
        {
            string str = "select es.ExecutorSchedule_id as NumExec" +
                ", FIO" +
                ", Phone" +
                ", Time " +
                "from ExecutorSchedule es " +
                "full join Executor e " +
                "on e.Executor_id = es.Executor_id " +
                "full join LeadTime lt " +
                "on lt.LeadTime_id = es.LeadTime_id " +
                "where FIO = '"+ comboBox5.Text +"'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void button9_Click(object sender, EventArgs e) //время.показать все
        {
            string str = "select es.ExecutorSchedule_id as NumExec" +
                ", FIO" +
                ", Phone" +
                ", Time " +
                "from ExecutorSchedule es " +
                "full join Executor e " +
                "on e.Executor_id = es.Executor_id " +
                "full join LeadTime lt " +
                "on lt.LeadTime_id = es.LeadTime_id";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;
        }
    }
}
