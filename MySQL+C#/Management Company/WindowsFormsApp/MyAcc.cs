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
    public partial class MyAcc : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public MyAcc(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=UpComany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);
            SelectT();
        }

        private void SelectT()
        {
            sqlConnection.Open();

            string fio = "SELECT FIO + ' ' FROM Users where Login = '" + login + "'";
            string tel = "SELECT Passport FROM Users where Login = '" + login + "'";
            string birth = "SELECT Role.Name FROM Users, Role where Users.Role_id = Role.Role_id and Login = '" + login + "'";
            string log_in = "SELECT Login FROM Users where Login = '" + login + "'";

            SqlCommand cmd = new SqlCommand(fio, sqlConnection);
            SqlCommand cmd2 = new SqlCommand(tel, sqlConnection);
            SqlCommand cmd3 = new SqlCommand(birth, sqlConnection);
            SqlCommand cmd4 = new SqlCommand(log_in, sqlConnection);

            string n1 = cmd.ExecuteScalar().ToString();
            string n2 = cmd2.ExecuteScalar().ToString();
            string n3 = cmd3.ExecuteScalar().ToString();
            string n4 = cmd4.ExecuteScalar().ToString();

            sqlConnection.Close();

            textBox1.Text = n1;
            textBox2.Text = n2;
            textBox3.Text = n3;
            textBox4.Text = n4;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            this.Close();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("Введите старый пароль!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Введите новый пароль!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                sqlConnection.Open();
                string str = "SELECT Password FROM Users WHERE Login = '" + login + "'";
                SqlCommand cmd = new SqlCommand(str, sqlConnection);
                string res = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();
                if (hash(textBox6.Text) == res)
                {
                    if (hash(textBox6.Text) == hash(textBox5.Text))
                    {
                        MessageBox.Show("Новый пароль не может быть как старый пароль!", "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string str1 = "UPDATE Users SET Password = '" + hash(textBox5.Text) + "' WHERE Login = '" + login + "'";
                        SqlDataAdapter DA = new SqlDataAdapter(str1, sqlConnection);
                        DataSet dataSet = new DataSet();
                        DA.Fill(dataSet);
                        MessageBox.Show("Пароль успешно изменен", "Успешно", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Старый пароль введен неверно!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private string hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
