using System;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using MetroFramework;
using MetroFramework.Forms;
using Oracle.DataAccess.Client;
using MetroFramework.Design;
using MetroFramework.Components;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class MainForm : MetroForm
    {
        OleDbConnection conn;

        public MainForm()
        {
            InitializeComponent();
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;Data Source=127.0.0.1:1521/xe;User ID=C##TESTPAV;Persist Security Info=True;PASSWORD=MyPass;"; 
            conn = new OleDbConnection(connection);
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
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

        private void metroButton1_Click_1(object sender, EventArgs e)
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
                this.Alert("Введите логин и пароль", Form_Alert.enmType.Warning);
                //MetroMessageBox.Show(this, "Вы не ввели ничего.\nПопробуйте ещё раз!", "Ошибка");
            }
            else if (TestForNullOrEmpty(passField.Text))
            {
                this.Alert("Вы не ввели пароль.\nПопробуйте ещё раз", Form_Alert.enmType.Info);
                //MetroMessageBox.Show(this, "Вы не ввели пароль.\nПопробуйте ещё раз!", "Ошибка");
            }
            else if (TestForNullOrEmpty(log))
            {
                this.Alert("Вы не ввели логин.\nПопробуйте ещё раз", Form_Alert.enmType.Info);
                //MetroMessageBox.Show(this, "Вы не ввели логин.\nПопробуйте ещё раз!", "Ошибка");
            }
            else if (res == "Администратор")
            {
                Admin form = new Admin(log);
                form.Show();
                this.Hide();

                string fio = "SELECT FIO FROM USERS where LOGIN = " + log + "";

                OleDbCommand cmd1 = new OleDbCommand(fio, conn);

                string n1 = cmd1.ExecuteScalar().ToString();

                this.Alert("Вход выполнен успешно \n Здравствуйте, " + n1, Form_Alert.enmType.Success);
            }
            else
            {
                this.Alert("Пользователя с таким логином\nили паролем не существует", Form_Alert.enmType.Error);
                //MetroMessageBox.Show(this, "Пользователя с таким логином или паролем не существует.\nПопробуйте ещё раз!", "Ошибка");
            }
            conn.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "")
            {
                //MetroMessageBox.Show(this, "Пожалуйста, заполните все поля!", "Ошибка");
                this.Alert("Пожалуйста, заполните все поля", Form_Alert.enmType.Warning);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM USERS WHERE LOGIN = '" + metroTextBox2.Text + "'"; //уникальность логина
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(into, conn);
                string cnt = cmd.ExecuteScalar().ToString();
                conn.Close();

                if (cnt == "0")
                {
                    string st = "INSERT INTO USERS(FIO, ROLE, LOGIN, PASSWORD) " +
                                "VALUES('" + metroTextBox1.Text + "', 'Администратор', '" + metroTextBox2.Text + "', '" + Hash(metroTextBox3.Text) + "')";
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter DA = new OleDbDataAdapter(st, conn);
                    DA.Fill(dataSet);

                    this.Alert("Пользователь успешно создан", Form_Alert.enmType.Success);
                }
                else
                {
                    this.Alert("Логин должен быть уникальным", Form_Alert.enmType.Error);
                    //MetroMessageBox.Show(this, "Логин должен быть уникальным!", "Ошибка");
                }
            }
        }
    }
}
