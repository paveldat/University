using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Manager : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Manager(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=Semen_proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);

            getUsers();
        }

        #region Клиенты

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private void button1_Click(object sender, System.EventArgs e) //клиенты.добавить
        {
            if ("".Equals(textBox1.Text) || "".Equals(textBox2.Text) || "".Equals(textBox3.Text)
                || "".Equals(textBox4.Text) || "".Equals(textBox5.Text) || "".Equals(textBox6.Text)
                || "".Equals(textBox7.Text) || "".Equals(textBox8.Text) || "".Equals(textBox9.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (dateTimePicker1.Value > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Клиенту должно быть 18!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    string into = "SELECT COUNT(*) FROM Users WHERE username = '" + textBox1.Text + "'"; //уникальность логина
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(into, sqlConnection);
                    string cnt = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    string into2 = "SELECT COUNT(*) FROM Client WHERE Passport = '" + textBox6.Text + "'"; //уникальность паспорта
                    sqlConnection.Open();
                    SqlCommand cmd2 = new SqlCommand(into2, sqlConnection);
                    string cnt2 = cmd2.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    string into3 = "SELECT COUNT(*) FROM Client WHERE INN = '" + textBox7.Text + "'"; //уникальность ИНН
                    sqlConnection.Open();
                    SqlCommand cmd3 = new SqlCommand(into2, sqlConnection);
                    string cnt3 = cmd3.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    string into4 = "SELECT COUNT(*) FROM Client WHERE SNILLS = '" + textBox9.Text + "'"; //уникальность СНИЛС
                    sqlConnection.Open();
                    SqlCommand cmd4 = new SqlCommand(into2, sqlConnection);
                    string cnt4 = cmd4.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    string into5 = "SELECT COUNT(*) FROM Client WHERE Phone = '" + textBox8.Text + "'"; //уникальность телефона
                    sqlConnection.Open();
                    SqlCommand cmd5 = new SqlCommand(into2, sqlConnection);
                    string cnt5 = cmd5.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    if ((textBox6.Text.Length != 10) && (textBox7.Text.Length != 11))
                        MessageBox.Show("Пожалуйста, проверьте корректность паспортных данных и ИНН, они должны содержать 10 цифр!", "Ошибка", MessageBoxButtons.OK);
                    else if ((textBox8.Text.Length != 11) && (textBox9.Text.Length != 11))
                        MessageBox.Show("Пожалуйста, проверьте корректность СНИЛС и номера телефона, они должны содержать 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                    else if ("0".Equals(cnt) && "0".Equals(cnt2) && "0".Equals(cnt3) && "0".Equals(cnt4) && "0".Equals(cnt5))
                    {
                        string st = "begin transaction; " +
                            "insert into Users " +
                            "values ('" + textBox1.Text + "', '" + Hash(textBox2.Text) + "', 'Клиент'); " +
                            "insert into Client " +
                            "values ((select top 1 id from Users order by id desc)" +
                            ", '" + textBox3.Text + "'" +
                            ", '" + dateTimePicker1.Text + "'" +
                            ", '" + textBox4.Text + "'" +
                            ", 'Россия'" +
                            ", '" + textBox5.Text + "'" +
                            ", '" + textBox6.Text + "'" +
                            ", '" + textBox7.Text + "'" +
                            ", '" + textBox9.Text + "'" +
                            ", '" + textBox8.Text + "'" +
                            ", GETDATE()); " +
                            "insert into BankAccount " +
                            "values ('0'" +
                            ", (select top 1 id from Client order by id desc)); " +
                            "commit;";
                        SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                        DataSet dataSet1 = new DataSet();
                        DA1.Fill(dataSet1);

                        getUsers();
                    }
                    else
                        MessageBox.Show("Логин, паспорт, ИНН, СНИЛС и телефон должны быть уникальными!", "Ошибка", MessageBoxButtons.OK);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Логин, паспорт, ИНН, СНИЛС и телефон должны содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, System.EventArgs e) //клиенты.изменить
        {
            if ("".Equals(comboBox1.Text))
            {
                MessageBox.Show("Пожалуйста, выберите, что заменить!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string res1 = dataGridView1.CurrentRow.Cells[5].FormattedValue.ToString(); //Passport

                try
                {
                    switch (comboBox1.Text)
                    {
                        case "Логин":
                            if ("".Equals(textBox1.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый логин!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Users WHERE username = '" + textBox1.Text + "'"; //уникальность логина
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Users " +
                                        "set username = '" + textBox1.Text + "' " +
                                        "where id = (select User_id from Client where Passport = '" + res1 + "')";
                                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, логин должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                        case "ФИО":
                            if ("".Equals(textBox3.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новые ФИО!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "update Client " +
                                    "set FullName = '" + textBox3.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                getUsers();
                            }
                            break;
                        case "Адрес":
                            if ("".Equals(textBox4.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый адрес!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "update Client " +
                                    "set Adress = '" + textBox4.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                getUsers();
                            }
                            break;
                        case "Город":
                            if ("".Equals(textBox5.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый город!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "update Client " +
                                    "set City = '" + textBox5.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                getUsers();
                            }
                            break;
                        case "Паспорт":
                            if ("".Equals(textBox6.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый паспорт!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Client WHERE Passport = '" + textBox6.Text + "'"; //уникальность паспорта
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Client " +
                                    "set Passport = '" + textBox6.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, паспорт должен быть уникальным и длина ровно 10 цифр!", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                        case "ИНН":
                            if ("".Equals(textBox7.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый ИНН!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Client WHERE INN = '" + textBox7.Text + "'"; //уникальность ИНН
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Client " +
                                    "set INN = '" + textBox7.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, ИНН должен быть уникальным и длина ровно 10 цифр!", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                        case "СНИЛС":
                            if ("".Equals(textBox9.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый СНИЛС!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Client WHERE SNILLS = '" + textBox9.Text + "'"; //уникальность СНИЛС
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Client " +
                                    "set SNILLS = '" + textBox9.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, СНИЛС должен быть уникальным и длина ровно 111 цифр!", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                        case "Телефон":
                            if ("".Equals(textBox8.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый телефон!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Client WHERE Phone = '" + textBox8.Text + "'"; //уникальность телефона
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Client " +
                                    "set Phone = '" + textBox8.Text + "' " +
                                    "where Passport = '" + res1 + "'";
                                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getUsers();
                                }
                                else
                                {
                                    MessageBox.Show("Пожалуйста, телефон должен быть уникальным и длина ровно 11 цифр!", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Логин, паспорт, ИНН, СНИЛС и телефон должны содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void getUsers()
        {
            string str = "select c.FullName" +
                ", c.Born" +
                ", c.Adress" +
                ", c.Country" +
                ", c.City" +
                ", c.Passport" +
                ", c.INN" +
                ", c.SNILLS" +
                ", c.Phone" +
                ", c.joinDate" +
                ", u.username " +
                ", ba.CurrentBalance " +
                "from Client c " +
                "join Users u " +
                "on u.id = c.User_id " +
                "join BankAccount ba " +
                "on ba.Client_id = c.id";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getUsers();
        }

        #endregion

        #region Кредиты

        private void button4_Click(object sender, EventArgs e) //Просмотр данных о клиенте и о его кредитах / получение полной выписки о счете клиента
        {
            getCredits();
        }

        private void getCredits()
        {
            try
            {
                string res1 = dataGridView1.CurrentRow.Cells[5].FormattedValue.ToString(); //Passport

                string str = "execute credit_view @Passport = N'" + res1 + "'";
                DataTable table = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Пожалуйста, выберите из таблицы клиентов!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e) //выдать кредит
        {
            double i, n, sum, plata;
            string p;

            if ("".Equals(textBox10.Text) || "".Equals(comboBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    i = 0.0075;
                    sum = Convert.ToInt32(textBox10.Text);
                    n = Convert.ToInt32(comboBox2.Text.Substring(0, 1)) * 12;
                    plata = sum * ((i * Math.Pow((1 + i), n)) / (Math.Pow((1 + i), n) - 1));
                    p = Convert.ToString(Math.Round(plata * n - sum, 2)).Replace(",", ".");

                    string res1 = dataGridView1.CurrentRow.Cells[5].FormattedValue.ToString(); //Passport

                    string st = "insert into Credit " +
                        "values ((select ba.id from BankAccount ba join Client c on c.id = ba.Client_id where Passport = '" + res1 + "')" +
                        ", GETDATE()" +
                        ", DATEADD(YEAR, " + comboBox2.Text.Substring(0, 1) + ", GETDATE())" +
                        ", '" + textBox10.Text + "'" +
                        ", '" + p + "'" +
                        ", 9" +
                        ", 1" +
                        ", (select e.id from Employee e join Users u on u.id = e.User_id where username = '" + login + "'))";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    getUsers();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Пожалуйста, выберите из таблицы клиентов, введите корректную сумму и выберите срок из списка!", "Ошибка", MessageBoxButtons.OK);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Пожалуйста, выберите из таблицы клиентов!", "Ошибка", MessageBoxButtons.OK);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Пожалуйста, выберите из таблицы клиентов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //сумма переплат
        {
            double i, n, sum, plata;
            if ("".Equals(textBox10.Text) || "".Equals(comboBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    i = 0.0075;
                    sum = Convert.ToInt32(textBox10.Text);
                    n = Convert.ToInt32(comboBox2.Text.Substring(0, 1)) * 12;
                    plata = sum * ((i * Math.Pow((1 + i), n)) / (Math.Pow((1 + i), n) - 1));
                    label17.Text = Convert.ToString(Math.Round(plata * n - sum, 2));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Пожалуйста, введите корректную сумму и выберите срок из списка!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button7_Click_1(object sender, EventArgs e) //показать неподтвержденные
        {
            string str = "select cr.Date_Begin, cr.Date_Close, cr.Main_debt, cl.Passport " +
                "from Credit cr join BankAccount ba on ba.id = cr.BankAccount_id " +
                "join Client cl on cl.id = ba.Client_id " +
                "where cr.Approved = 0"/* and cr.Employee_id = (select e.id from Employee e join Users u on e.User_id = u.id where username = '" + login + "')*/;
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button10_Click(object sender, EventArgs e) //удалить
        {
            string res1 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString(); //Passport
            string res = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString().Replace(",", "."); //sum

            string st = "delete from Credit " +
                "where BankAccount_id = (select ba.id from BankAccount ba join Client c on c.id = ba.Client_id where c.Passport = '" + res1 + "') " +
                "and Main_debt = '" + res + "'";
            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
            DataSet dataSet1 = new DataSet();
            DA1.Fill(dataSet1);

            string str = "select cr.Date_Begin, cr.Date_Close, cr.Main_debt, cl.Passport " +
                "from Credit cr join BankAccount ba on ba.id = cr.BankAccount_id " +
                "join Client cl on cl.id = ba.Client_id " +
                "where cr.Approved = 0";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        #endregion
    }
}
