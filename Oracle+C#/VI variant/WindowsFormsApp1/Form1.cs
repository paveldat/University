using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OleDbConnection conn;

        public Form1()
        {
            InitializeComponent();
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;Data Source=127.0.0.1:1521/xe;User ID=C##6VAR;Persist Security Info=True;PASSWORD=MyPass;";
            conn = new OleDbConnection(connection);
        }

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pass = Hash(textBox2.Text);
            string rule;

            conn.Open();
            rule = "select ROLE from USERS WHERE login = '" + textBox1.Text + "' AND password = '" + pass + "'";
            OleDbCommand cmd = new OleDbCommand(rule, conn);
            string res = (string)cmd.ExecuteScalar();

            if ("".Equals(textBox2.Text) && "".Equals(textBox1.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK);
            }
            else if ("".Equals(textBox2.Text))
            {
                MessageBox.Show("Вы не ввели пароль", "Ошибка", MessageBoxButtons.OK);
            }
            else if ("".Equals(textBox1.Text))
            {
                MessageBox.Show("Вы не ввели логин", "Ошибка", MessageBoxButtons.OK);
            }
            else if (res == "ADMIN")
            {
                admin form = new admin(textBox1.Text);
                form.Show();
                this.Hide();
            }
            else if (res == "EMPLOYEE")
            {
                employee form = new employee(textBox1.Text);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином или паролем не существует", "Ошибка", MessageBoxButtons.OK);
            }
            conn.Close();
        }
    }
}
