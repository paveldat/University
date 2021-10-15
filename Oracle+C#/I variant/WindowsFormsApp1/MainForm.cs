using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        OleDbConnection conn;

        public MainForm()
        {
            InitializeComponent();
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;Data Source=127.0.0.1:1521/xe;User ID=C##SVETA;Persist Security Info=True;PASSWORD=MyPass;";
            conn = new OleDbConnection(connection);
        }
        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string log = loginField.Text;
            string pass = Hash(passField.Text);
            string rule;

            conn.Open();
            rule = "select ROLE from USERS WHERE login = '" + log + "' AND password = '" + pass + "'";
            OleDbCommand cmd = new OleDbCommand(rule, conn);
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
            else if ("Диспетчер".Equals(res))
            {
                Dispatcher form = new Dispatcher(log);
                form.Show();
                this.Hide();
            }
            else if ("Персонал".Equals(res))
            {
                Personnel form = new Personnel(log);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином или паролем не существует.\nПопробуйте ещё раз!", "Ошибка", MessageBoxButtons.OK);
            }
            conn.Close();
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
