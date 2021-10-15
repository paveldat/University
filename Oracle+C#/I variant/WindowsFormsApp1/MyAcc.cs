using System;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MyAcc : Form
    {
        OleDbConnection sqlConnection;
        private string login;

        public MyAcc(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##SVETA;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);
            SelectT();
        }

        private void SelectT()
        {
            sqlConnection.Open();

            string first_name = "select first_name from auto_personnel, users where user_id = users.id and login = '" + login + "'";
            string last_name = "select last_name from auto_personnel, users where user_id = users.id and login = '" + login + "'";
            string pather_name = "select pather_name from auto_personnel, users where user_id = users.id and login = '" + login + "'";
            string log_in = "SELECT login FROM Users where login = '" + login + "'";

            OleDbCommand cmd = new OleDbCommand(first_name, sqlConnection);
            OleDbCommand cmd2 = new OleDbCommand(last_name, sqlConnection);
            OleDbCommand cmd3 = new OleDbCommand(pather_name, sqlConnection);
            OleDbCommand cmd4 = new OleDbCommand(log_in, sqlConnection);

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
                string str = "SELECT password FROM Users WHERE login = '" + login + "'";
                OleDbCommand cmd = new OleDbCommand(str, sqlConnection);
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
                        string str1 = "UPDATE Users SET password = '" + hash(textBox5.Text) + "' WHERE login = '" + login + "'";
                        OleDbDataAdapter DA = new OleDbDataAdapter(str1, sqlConnection);
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
