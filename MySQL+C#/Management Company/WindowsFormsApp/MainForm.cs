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
    public partial class MainForm : Form
    {
        SqlConnection sqlConnection;

        public MainForm()
        {
            InitializeComponent();
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=UpComany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string log = loginField.Text;
            string pass = Hash(passField.Text);
            string rule;

            sqlConnection.Open();
            rule = "select r.Name " +
                "from Role r " +
                "join Users u " +
                "on r.Role_id = u.Role_id " +
                "WHERE Login = '" + log + "' AND Password = '" + pass + "'";
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
            else if (res == "Администратор")
            {
                Admin form = new Admin(log);
                form.Show();
                this.Hide();
            }
            else if (res == "Диспетчер")
            {
                Dispatcher form = new Dispatcher(log);
                form.Show();
                this.Hide();
            }
            else if (res == "Бухгалтер")
            {
                Accountant form = new Accountant(log);
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
            bool result;
            result = s == null || s == string.Empty;
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
