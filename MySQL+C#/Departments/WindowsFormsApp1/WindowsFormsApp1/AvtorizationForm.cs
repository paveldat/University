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

        

        public AvtorizationForm()
        {
            InitializeComponent();

            data = new List<List<string>>();
        }

        private void avtorizationBtn_Click(object sender, EventArgs e)
        {
            login = false;
            password = false;

            data = sqlActions.doSqlCommand("select * from Users", 8);

            foreach (var d in data)
            {
                var loginWord = loginTextBox.Text.Trim();
                var passWord = passwordTextBox.Text.Trim();

                if (loginWord == d[6].Trim()) login = true;
                if (Verifycation.VerifySHA512Hash(passWord, d[7].Trim())) password = true;

                role_id = d[1];

                if (login && password)
                {
                    ifAvtorizationTrue(role_id.Trim(), d[3].Trim(), d[4].Trim(), Convert.ToInt32(d[0].Trim()));
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
                Specialist spec = new Specialist();
                spec.ShowDialog();
            }
            if (role_id == "2")
            {
                MainSpecialist mnspec = new MainSpecialist();
                mnspec.ShowDialog();
            }
            if (role_id == "3")
            {
                ZamDir zam = new ZamDir();
                zam.ShowDialog();
            }
            if (role_id == "4")
            {
                Director dir = new Director();
                dir.ShowDialog();
            }
        }
    }
}
