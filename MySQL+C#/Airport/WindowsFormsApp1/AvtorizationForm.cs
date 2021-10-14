using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AvtorizationForm : Form
    {
        List<List<string>> data;
        bool login, password;
        string role_id;

        Form1 form1;

        public AvtorizationForm()
        {
            InitializeComponent();

            data = new List<List<string>>();
        }

        private void avtorizationBtn_Click(object sender, EventArgs e)
        {
            login = false;
            password = false;

            data = sqlActions.doSqlCommand("select * from Users", 7);

            foreach (var d in data)
            {
                var loginWord = loginTextBox.Text.Trim();
                var passWord = passwordTextBox.Text.Trim();

                if (loginWord == d[5].Trim()) login = true;
                if (Verifycation.VerifySHA512Hash(passWord, d[6].Trim())) password = true;

                role_id = d[1];

                if (login && password)
                {
                    ifAvtorizationTrue(role_id.Trim(), d[2].Trim(), d[3].Trim(), Convert.ToInt32(d[0].Trim()));
                    break;
                }

                login = false; password = false;
            }

            if(!login || !password)
                MessageBox.Show("Неправильный логин или пароль");
        }

        void ifAvtorizationTrue(string role_id, string name, string surname, int userId) 
        {
            MessageBox.Show($"Добро пожаловать, {name} {surname}");
            if (role_id == "1") 
            {
                Cashier cashier = new Cashier();
                cashier.ShowDialog();
            }
            if (role_id == "2")
            {
                Employee employee = new Employee();
                employee.ShowDialog();
            }
            if (role_id == "3")
            {
                Pilot pilot = new Pilot(userId);
                pilot.ShowDialog();
            }
            if (role_id == "4")
            {
                Administrator admin = new Administrator();
                admin.ShowDialog();
            }
        }
    }
}
