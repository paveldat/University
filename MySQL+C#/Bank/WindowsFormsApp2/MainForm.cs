using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class MainForm : Form
    {
        SqlConnection sqlConnection;

        public MainForm()
        {
            InitializeComponent();
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=Semen_proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string log = loginField.Text;
            string pass = Hash(passField.Text);
            string rule;

            sqlConnection.Open();
            rule = "select Role " +
                "from Users " +
                "WHERE username = '" + log + "' AND password = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(rule, sqlConnection);
            string res = (string)cmd.ExecuteScalar();

            if (TestForNullOrEmpty(passField.Text) && TestForNullOrEmpty(log))
            {
                MessageBox.Show("Вы не ввели ничего.\nПопробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (TestForNullOrEmpty(passField.Text))
            {
                MessageBox.Show("Вы не ввели пароль.\nПопробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (TestForNullOrEmpty(log))
            {
                MessageBox.Show("Вы не ввели логин.\nПопробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK);
            }
            else if ("Администратор".Equals(res))
            {
                Admin form = new Admin(log);
                form.Show();
                this.Hide();
            }
            else if ("Сотрудник банка".Equals(res))
            {
                Manager form = new Manager(log);
                form.Show();
                this.Hide();
            }
            else if ("Клиент".Equals(res))
            {
                Client form = new Client(log);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином или паролем не существует.\nПопробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK);
            }
            sqlConnection.Close();
        }

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        bool TestForNullOrEmpty(string s)
        {
            return s == null || s == string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
