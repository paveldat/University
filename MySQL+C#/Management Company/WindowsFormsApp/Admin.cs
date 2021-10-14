using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Admin : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Admin(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=UpComany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);

            //пользователи
            string str = "select u.FIO" +
                ", r.Name" +
                ", u.Passport" +
                ", u.Phone" +
                ", u.Login " +
                "from Users u " +
                "inner join Role r " +
                "on r.Role_id = u.Role_id";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            //Дома для осмотра и кап ремонта
            str = "select Adress, hv.TimeStamp as HView, ho.TimeStamp as Overhaul, Defects, ListOfWork " +
                "from HousesView hv " +
                "inner join Houses h " +
                "on h.HouseView_id = hv.HouseView_id " +
                "inner join HousesOverhaul ho " +
                "on ho.HouseOver_id = h.HouseOver_id";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            //Исполнители
            str = "select FIO, Phone, Passport from Executor";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView4.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e) //пользователи.создать
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM Users WHERE Login = '" + textBox4.Text + "'"; //уникальность логина
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                string into2 = "SELECT COUNT(*) FROM Users WHERE Passport = '" + textBox2.Text + "'"; //уникальность паспорта
                sqlConnection.Open();
                SqlCommand cmd2 = new SqlCommand(into2, sqlConnection);
                string cnt2 = cmd2.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (textBox3.Text.Length != 11)
                    MessageBox.Show("Пожалуйста, проверьте корректность номера, он должен содержать 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                else if (textBox2.Text.Length != 10)
                    MessageBox.Show("Пожалуйста, проверьте корректность паспортных данных, они должны содержать 10 цифр!", "Ошибка", MessageBoxButtons.OK);
                else if (cnt == "0" && cnt2 == "0")
                {
                    string st = "insert into Users values ((select Role_id from Role where Name = '" + comboBox1.Text + "')" +
                    ", '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + Hash(textBox5.Text) + "')";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select u.FIO" +
                    ", r.Name" +
                    ", u.Passport" +
                    ", u.Phone" +
                    ", u.Login " +
                    "from Users u " +
                    "inner join Role r " +
                    "on r.Role_id = u.Role_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else
                    MessageBox.Show("Логин и паспорт должны быть уникальными!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private void button2_Click(object sender, EventArgs e) //пользователи.изменить
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string selectedState = comboBox2.Text;
                string result = textBox6.Text;
                string res1 = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();
                switch (selectedState)
                {
                    case "ФИО":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите ФИО!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update Users set FIO = '"+ result +"' where Passport = '"+ res1 +"'";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            string str2 = "select u.FIO" +
                                            ", r.Name" +
                                            ", u.Passport" +
                                            ", u.Phone" +
                                            ", u.Login " +
                                            "from Users u " +
                                            "inner join Role r " +
                                            "on r.Role_id = u.Role_id";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView1.DataSource = table;
                        }
                        break;
                    case "Паспорт":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите паспорт!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT COUNT(*) FROM Users WHERE Passport = '" + result + "'"; //уникальность логина
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(into, sqlConnection);
                            string cnt = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (cnt == "0")
                            {
                                string st = "update Users set Passport = '" + result + "' where Passport = '" + res1 + "'";
                                SqlDataAdapter DA = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select u.FIO" +
                                            ", r.Name" +
                                            ", u.Passport" +
                                            ", u.Phone" +
                                            ", u.Login " +
                                            "from Users u " +
                                            "inner join Role r " +
                                            "on r.Role_id = u.Role_id";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView1.DataSource = table;
                            }
                            else
                                MessageBox.Show("Пасспорт должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                    case "Телефон":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите тип работ!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT COUNT(*) FROM Users WHERE Phone = '" + result + "'"; //уникальность логина
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(into, sqlConnection);
                            string cnt = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (cnt == "0")
                            {
                                string str = "update Users set Phone = '" + result + "' where Passport = '" + res1 + "'";
                                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select u.FIO" +
                                                ", r.Name" +
                                                ", u.Passport" +
                                                ", u.Phone" +
                                                ", u.Login " +
                                                "from Users u " +
                                                "inner join Role r " +
                                                "on r.Role_id = u.Role_id";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView1.DataSource = table;
                            }
                            else
                                MessageBox.Show("Телефон должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                    case "Должность":
                        if (comboBox3.Text == "")
                        {
                            MessageBox.Show("Пожалуйста, выберите должность!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string str = "update Users set Role_id = (select Role_id from Role where Name = '" + comboBox3.Text + "') where Passport = '" + res1 + "'";
                            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select u.FIO" +
                                            ", r.Name" +
                                            ", u.Passport" +
                                            ", u.Phone" +
                                            ", u.Login " +
                                            "from Users u " +
                                            "inner join Role r " +
                                            "on r.Role_id = u.Role_id";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView1.DataSource = table;
                        }
                        break;
                    case "Логин":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, выберите клиента!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT COUNT(*) FROM Users WHERE Login = '" + result + "'"; //уникальность логина
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(into, sqlConnection);
                            string cnt = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (cnt == "0")
                            {
                                string str = "update Users set Login = '" + result + "' where Passport = '" + res1 + "'";
                                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select u.FIO" +
                                            ", r.Name" +
                                            ", u.Passport" +
                                            ", u.Phone" +
                                            ", u.Login " +
                                            "from Users u " +
                                            "inner join Role r " +
                                            "on r.Role_id = u.Role_id";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView1.DataSource = table;
                            }
                            else
                                MessageBox.Show("Логин должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //пользователи.удалить
        {
            string res = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();
            string str = "delete from Users where Passport = '" + res + "'";
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select u.FIO" +
                ", r.Name" +
                ", u.Passport" +
                ", u.Phone" +
                ", u.Login " +
                "from Users u " +
                "inner join Role r " +
                "on r.Role_id = u.Role_id";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button4_Click(object sender, EventArgs e) //Дома для осмотра и кап ремонта.создать
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите адрес!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM Houses WHERE Adress = '" + textBox7.Text + "'"; //уникальность адреса
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (cnt == "0")
                {
                    string st = "begin transaction; " +
                    "insert into HousesOverhaul values (CURRENT_TIMESTAMP, ''); " +
                    "insert into HousesView values (CURRENT_TIMESTAMP, ''); " +
                    "insert into Houses values ((select top 1 HouseView_id from HousesView order by HouseView_id desc)" +
                                                ", (select top 1 HouseOver_id from HousesOverhaul order by HouseOver_id desc), NULL, '"+ textBox7.Text +"'); " +
                    "commit;";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select Adress, hv.TimeStamp as HView, ho.TimeStamp as Overhaul, Defects, ListOfWork " +
                "from HousesView hv " +
                "inner join Houses h " +
                "on h.HouseView_id = hv.HouseView_id " +
                "inner join HousesOverhaul ho " +
                "on ho.HouseOver_id = h.HouseOver_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView2.DataSource = table;
                }
                else
                    MessageBox.Show("Адрес должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e) //Дома для осмотра и кап ремонта.изменить
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string selectedState = comboBox4.Text;
                string result = textBox8.Text;
                string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
                switch (selectedState)
                {
                    case "Дефекты при осмотре":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите дефекты или 'Дефектов не обнаружено'!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update HousesView set Defects = '" + result + "' where HouseView_id = (select HouseView_id from Houses where Adress = '" + res + "'); " +
                                "update HousesView set TimeStamp = CURRENT_TIMESTAMP where HouseView_id = (select HouseView_id from Houses where Adress = '" + res + "');";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            string str2 = "select Adress, hv.TimeStamp as HView, ho.TimeStamp as Overhaul, Defects, ListOfWork " +
                                            "from HousesView hv " +
                                            "inner join Houses h " +
                                            "on h.HouseView_id = hv.HouseView_id " +
                                            "inner join HousesOverhaul ho " +
                                            "on ho.HouseOver_id = h.HouseOver_id";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView2.DataSource = table;
                        }
                        break;
                    case "Список работ":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, перечислите список работ!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update HousesOverhaul set ListOfWork = '" + result + "' where HouseOver_id = (select HouseOver_id from Houses where Adress = '" + res + "'); " +
                            "update HousesOverhaul set TimeStamp = CURRENT_TIMESTAMP where HouseOver_id = (select HouseOver_id from Houses where Adress = '" + res + "');";
                            SqlDataAdapter DA = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet = new DataSet();
                            DA.Fill(dataSet);

                            string str2 = "select Adress, hv.TimeStamp as HView, ho.TimeStamp as Overhaul, Defects, ListOfWork " +
                                            "from HousesView hv " +
                                            "inner join Houses h " +
                                            "on h.HouseView_id = hv.HouseView_id " +
                                            "inner join HousesOverhaul ho " +
                                            "on ho.HouseOver_id = h.HouseOver_id";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView2.DataSource = table;
                        }
                        break;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //Дома для осмотра и кап ремонта.удалить
        {
            string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
            string str = "DECLARE @HVID int, @HOID int " +
                "SET @HVID = (select HouseView_id from Houses where Adress = '"+ res +"') " +
                "SET @HOID = (select HouseOver_id from Houses where Adress = '"+ res +"') " +
                "exec DeleteHouses @HVID, @HOID";

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select Adress, hv.TimeStamp as HView, ho.TimeStamp as Overhaul, Defects, ListOfWork " +
                "from HousesView hv " +
                "inner join Houses h " +
                "on h.HouseView_id = hv.HouseView_id " +
                "inner join HousesOverhaul ho " +
                "on ho.HouseOver_id = h.HouseOver_id";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView2.DataSource = table;
            }
        }

        private void button7_Click(object sender, EventArgs e) //исполнители.создать
        {
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM Executor WHERE Passport = '" + textBox11.Text + "'"; //уникальность паспорта
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                string into2 = "SELECT COUNT(*) FROM Executor WHERE Phone = '" + textBox10.Text + "'"; //уникальность телефона
                sqlConnection.Open();
                SqlCommand cmd2 = new SqlCommand(into2, sqlConnection);
                string cnt2 = cmd2.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (textBox10.Text.Length != 11)
                    MessageBox.Show("Пожалуйста, проверьте корректность номера, он должен содержать 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                else if (cnt == "0" && cnt2 == "0")
                {
                    string st = "insert into Executor values ('"+ textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "')";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select FIO, Phone, Passport from Executor";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView4.DataSource = table;
                }
                else
                    MessageBox.Show("Паспорт и номер телефона должны быть уникальными!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button8_Click(object sender, EventArgs e) //исполнители.изменить
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите изменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string selectedState = comboBox5.Text;
                string result = textBox12.Text;
                string res1 = dataGridView4.CurrentRow.Cells[2].FormattedValue.ToString();
                switch (selectedState)
                {
                    case "ФИО":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите ФИО!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update Executor set FIO = '" + result + "' where Passport = '" + res1 + "'";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            string str2 = "select FIO, Phone, Passport from Executor";
                            DataTable table = new DataTable();
                            SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                            DA2.Fill(table);
                            dataGridView4.DataSource = table;
                        }
                        break;
                    case "Паспорт":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите паспорт!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT COUNT(*) FROM Executor WHERE Passport = '" + result + "'"; //уникальность логина
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(into, sqlConnection);
                            string cnt = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (cnt == "0")
                            {
                                string st = "update Executor set Passport = '" + result + "' where Passport = '" + res1 + "'";
                                SqlDataAdapter DA = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select FIO, Phone, Passport from Executor";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView4.DataSource = table;
                            }
                            else
                                MessageBox.Show("Пасспорт должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                    case "Телефон":
                        if (result == "")
                        {
                            MessageBox.Show("Пожалуйста, введите тип работ!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT COUNT(*) FROM Executor WHERE Phone = '" + result + "'"; //уникальность логина
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(into, sqlConnection);
                            string cnt = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (cnt == "0")
                            {
                                string str = "update Executor set Phone = '" + result + "' where Passport = '" + res1 + "'";
                                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                                DataSet dataSet = new DataSet();
                                DA.Fill(dataSet);

                                string str2 = "select FIO, Phone, Passport from Executor";
                                DataTable table = new DataTable();
                                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                                DA2.Fill(table);
                                dataGridView4.DataSource = table;
                            }
                            else
                                MessageBox.Show("Телефон должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                        }
                        break;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e) //исполнители.удалить
        {
            string res = dataGridView4.CurrentRow.Cells[2].FormattedValue.ToString();
            string str = "delete from Executor where Passport = '" + res + "'";
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                string str2 = "select FIO, Phone, Passport from Executor";
                DataTable table = new DataTable();
                SqlDataAdapter DA2 = new SqlDataAdapter(str2, sqlConnection);
                DA2.Fill(table);
                dataGridView4.DataSource = table;
            }
        }

        private void button10_Click(object sender, EventArgs e) //профиль
        {
            MyAcc form = new MyAcc(login);
            form.Show();
            this.Close();
        }
    }
}
