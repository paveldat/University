using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Client : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Client(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=Semen_proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);
        }

        private void button1_Click(object sender, System.EventArgs e) //кредиты
        {
            string str = "select cr.Date_Begin, cr.Date_Close, cr.Main_debt, cl.Passport, cr.Approved " +
                "from Credit cr join BankAccount ba on ba.id = cr.BankAccount_id " +
                "join Client cl on cl.id = ba.Client_id " +
                "where cl.id = (select c.id from Client c, Users u where c.User_id = u.id and u.username = '" + login + "')";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, System.EventArgs e) //выписка
        {
            string str = "select distinct 'Общий баланс' as name, ba.CurrentBalance, GETDATE() as date " +
                "from BankAccount ba " +
                "join Client cl on cl.id = ba.Client_id " +
                "where cl.id = (select c.id from Client c, Users u where c.User_id = u.id and u.username = '" + login + "') " +
                "union all " +
                "(select distinct 'Операция', avg(oh.IncomeExpenese), max(oh.Date) " +
                "from BankAccount ba " +
                "join Client cl on cl.id = ba.Client_id " +
                "join OperationsHistory oh on oh.Account_id = ba.id " +
                "where cl.id = (select c.id from Client c, Users u where c.User_id = u.id and u.username = '" + login + "') " +
                "group by MONTH(oh.Date))";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button5_Click(object sender, System.EventArgs e)
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

                    string st = "insert into Credit " +
                        "values ((select ba.id from BankAccount ba join Client c on c.id = ba.Client_id join Users u on u.id = c.User_id where username = '" + login + "')" +
                        ", GETDATE()" +
                        ", DATEADD(YEAR, " + comboBox2.Text.Substring(0, 1) + ", GETDATE())" +
                        ", '" + textBox10.Text + "'" +
                        ", '" + p + "'" +
                        ", 9" +
                        ", 0" +
                        ", null)";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    MessageBox.Show("Запрос на кредит оставлен!", "Все ок", MessageBoxButtons.OK);
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

        private void button6_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string into = "select ba.CurrentBalance from BankAccount ba " +
                "join Client c on c.id = ba.Client_id " +
                "join Users u on u.id = c.User_id " +
                "where u.username = '" + login + "'"; //сумма
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            double sum = Convert.ToDouble(cnt);

            if ("".Equals(comboBox1.Text) && "".Equals(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, введите сумму и выберите тип операции!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    switch (comboBox1.Text)
                    {
                        case "Снять":
                            if (sum < Convert.ToDouble(textBox1.Text))
                            {
                                MessageBox.Show("Пожалуйста, сумма не должна превышать текущую!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "begin transaction; " +
                                    "insert into OperationsHistory " +
                                    "values((select ba.id from BankAccount ba join Client c on c.id = ba.Client_id join Users u on u.id = c.User_id where username = '" + login + "')" +
                                    ", 0 - " + textBox1.Text + "" +
                                    ", GETDATE()); " +
                                    "update BankAccount " +
                                    "set CurrentBalance = CurrentBalance - " + textBox1.Text + " " +
                                    "where Client_id = (select c.id from Client c join Users u on u.id = c.User_id where username = '" + login + "'); " +
                                    "commit;";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);
                            }
                            break;
                        case "Внести":
                            if ("".Equals(textBox1.Text))
                            {
                                MessageBox.Show("Пожалуйста, введите сумму!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "begin transaction; " +
                                    "insert into OperationsHistory " +
                                    "values((select ba.id from BankAccount ba join Client c on c.id = ba.Client_id join Users u on u.id = c.User_id where username = '" + login + "')" +
                                    ", " + textBox1.Text + "" +
                                    ", GETDATE()); " +
                                    "update BankAccount " +
                                    "set CurrentBalance = CurrentBalance + " + textBox1.Text + " " +
                                    "where Client_id = (select c.id from Client c join Users u on u.id = c.User_id where username = '" + login + "'); " +
                                    "commit;";
                                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);
                            }
                            break;
                        default:
                            MessageBox.Show("Выберите тип из списка!", "Ошибка", MessageBoxButtons.OK);
                            break;
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Сумма должна содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Сумма должна содержать только цифры без пробелов и лишних символов!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string into = "select count(*) " +
                "from Credit cr " +
                "join BankAccount ba " +
                "on ba.id = cr.BankAccount_id " +
                "join Client cl " +
                "on cl.id = ba.Client_id " +
                "where cr.Date_Close >= GETDATE() " +
                "and cl.id = (select c.id from Client c join Users u on u.id = c.User_id where username = '" + login + "')"; //сумма
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("0".Equals(cnt))
            {
                    string st = "delete from Users where username = '" + login + "'";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    MainForm form = new MainForm();
                    form.Show();
                    this.Hide();

                    MessageBox.Show("Ползователь удален!", "Все ок", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Вы не можете удалить свой аккаунт, пока есть незакрытые кредиты!", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
