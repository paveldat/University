using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Admin : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Admin(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=Semen_proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);

            getUsers();
        }

        private void button1_Click(object sender, System.EventArgs e) //удалить клиента
        {
            string into = "select count(*) " +
                "from Credit cr " +
                "join BankAccount ba " +
                "on ba.id = cr.BankAccount_id " +
                "join Client cl " +
                "on cl.id = ba.Client_id " +
                "where cr.Date_Close >= GETDATE() " +
                "and cl.Passport = '" + textBox1.Text + "'"; //сумма
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            string into1 = "select count(*) " +
                "from Client " +
                "where Passport = '" + textBox1.Text + "'"; //сумма
            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand(into1, sqlConnection);
            string cnt1 = cmd1.ExecuteScalar().ToString();
            sqlConnection.Close();

            try
            {
                if ("0".Equals(cnt1))
                    MessageBox.Show("Пользователя с таким паспортом нет!", "Ошибка", MessageBoxButtons.OK);
                else
                {
                    if (!"".Equals(textBox1.Text))
                    {
                        if ("0".Equals(cnt))
                        {
                            string st = "delete from Users " +
                                "where username = (select username from Users u join Client c on c.User_id = u.id where c.Passport = '" + textBox1.Text + "')";
                            SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            MessageBox.Show("Ползователь удален!", "Все ок", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Вы не можете удалить клиента, у которого есть незакрытые кредиты!", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не заполнили поле!", "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Пожалуйста, паспорт должен содержать только цифры!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, System.EventArgs e) //удалить сотрудника
        {
            string into1 = "select count(*) " +
                "from Employee " +
                "where Passport = '" + textBox1.Text + "'"; //сумма
            sqlConnection.Open();
            SqlCommand cmd1 = new SqlCommand(into1, sqlConnection);
            string cnt1 = cmd1.ExecuteScalar().ToString();
            sqlConnection.Close();

            try
            {
                if ("0".Equals(cnt1))
                    MessageBox.Show("Сотрудника с таким паспортом нет!", "Ошибка", MessageBoxButtons.OK);
                else
                {
                    if (!"".Equals(textBox1.Text))
                    {
                        string st = "delete from Users " +
                            "where username = (select username from Users u join Employee c on c.User_id = u.id where c.Passport = '" + textBox1.Text + "')";
                        SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                        DataSet dataSet1 = new DataSet();
                        DA1.Fill(dataSet1);

                        MessageBox.Show("Сотрудник удален!", "Все ок", MessageBoxButtons.OK);

                        getUsers();
                    }
                    else
                    {
                        MessageBox.Show("Вы не заполнили поле!", "Ошибка", MessageBoxButtons.OK);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Пожалуйста, паспорт должен содержать только цифры!", "Ошибка", MessageBoxButtons.OK);
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
                ", c.Mage" +
                ", u.username " +
                "from Employee c " +
                "join Users u " +
                "on u.id = c.User_id " +
                "where u.Role <> 'Администратор'";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if ("".Equals(textBox10.Text) || "".Equals(textBox2.Text) || "".Equals(textBox3.Text)
                || "".Equals(textBox4.Text) || "".Equals(textBox5.Text) || "".Equals(textBox6.Text)
                || "".Equals(textBox7.Text) || "".Equals(textBox8.Text) || "".Equals(textBox9.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (dateTimePicker1.Value > DateTime.Today.AddYears(-18))
            {
                MessageBox.Show("Сотруднику должно быть 18!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    string into = "SELECT COUNT(*) FROM Users WHERE username = '" + textBox10.Text + "'"; //уникальность логина
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
                            "values ('" + textBox10.Text + "', '" + Hash(textBox2.Text) + "', 'Сотрудник банка'); " +
                            "insert into Employee " +
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
                            ", '" + textBox11.Text + "'); " +
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
                    MessageBox.Show("Логин, паспорт, ИНН, СНИЛС, зп и телефон должны содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) //показать неподтвержденные
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

        private void button8_Click(object sender, EventArgs e) //одобрить
        {
            try
            {
                string res1 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString(); //Passport

                string st = "update Credit " +
                    "set Employee_id = (select e.id from Employee e join Users u on e.User_id = u.id where username = '" + login + "')" +
                    ", Approved = 1 " +
                    "where BankAccount_id = (select ba.id from BankAccount ba join Client c on c.id = ba.Client_id where c.Passport = '" + res1 + "')";
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
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет неодобренных кредитов!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button9_Click(object sender, EventArgs e) //отклонить
        {
            string res1 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString(); //Passport

            string st = "update Credit " +
                "set Employee_id = (select e.id from Employee e join Users u on e.User_id = u.id where username = '" + login + "')" +
                ", Approved = 2 " +
                "where BankAccount_id = (select ba.id from BankAccount ba join Client c on c.id = ba.Client_id where c.Passport = '" + res1 + "')";
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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
                            if ("".Equals(textBox10.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новый логин!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM Users WHERE username = '" + textBox10.Text + "'"; //уникальность логина
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Users " +
                                        "set username = '" + textBox10.Text + "' " +
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
                                string st = "update Employee " +
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
                                string st = "update Employee " +
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
                                string st = "update Employee " +
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
                                string into = "SELECT COUNT(*) FROM Employee WHERE Passport = '" + textBox6.Text + "'"; //уникальность паспорта
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Employee " +
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
                                string into = "SELECT COUNT(*) FROM Employee WHERE INN = '" + textBox7.Text + "'"; //уникальность ИНН
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Employee " +
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
                                string into = "SELECT COUNT(*) FROM Employee WHERE SNILLS = '" + textBox9.Text + "'"; //уникальность СНИЛС
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Employee " +
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
                                string into = "SELECT COUNT(*) FROM Employee WHERE Phone = '" + textBox8.Text + "'"; //уникальность телефона
                                sqlConnection.Open();
                                SqlCommand cmd = new SqlCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if ("0".Equals(cnt))
                                {
                                    string st = "update Employee " +
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
                        case "ЗП":
                            if ("".Equals(textBox11.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите новую зп!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "update Employee " +
                                "set Mage = '" + textBox11.Text + "' " +
                                "where Passport = '" + res1 + "'";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                getUsers();
                            }
                            break;
                        default:
                            MessageBox.Show("Пожалуйста, выберите, что менять из списка!", "Ошибка", MessageBoxButtons.OK);
                            break;
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Логин, паспорт, ИНН, СНИЛС и телефон должны содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string str = "select sum(cr.interest_payable)" +
                ", cl.Passport " +
                "from Credit cr " +
                "join BankAccount ba " +
                "on ba.id = cr.BankAccount_id " +
                "join Client cl " +
                "on cl.id = ba.Client_id " +
                "group by cl.Passport " +
                "union all " +
                "(select sum(cr.interest_payable)" +
                ", 'Суммарная выручка' " +
                "from Credit cr " +
                "join BankAccount ba " +
                "on ba.id = cr.BankAccount_id " +
                "join Client cl " +
                "on cl.id = ba.Client_id)";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string str = "select count(cr.Approved)" +
                ", e.Passport" +
                ", e.FullName " +
                "from Employee e " +
                "join Credit cr " +
                "on cr.Employee_id = e.id group by e.Passport, e.FullName";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getUsers();
        }
    }
}
