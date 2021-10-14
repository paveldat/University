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
    public partial class newUser : Form
    {
        public newUser()
        {
            InitializeComponent();
        }

        private void newUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (role.Text=="" || name.Text == "" || surname.Text == "" || passport.Text == "" || login.Text == "" || password.Text == "")
                MessageBox.Show("Не все поля заполнены");
            else
            {
                bool isLoginPassport = false;
                var data = sqlActions.doSqlCommand("Select * From Users", 7);
                foreach (var d in data)
                {
                    if (d[4] == passport.Text || d[5] == login.Text)
                    {
                        isLoginPassport = true;
                        break;
                    }
                }
                if (isLoginPassport)
                    MessageBox.Show("Уже есть такой паспорт или логин!!!");
                else
                {
                    sqlActions.doSqlCommand("Insert Into Users(role_id,name,surname,passport_number,login,password) Values('"+role.Text+"','" + name.Text + "','" + surname.Text + "','" + passport.Text + "','" + login.Text + "','" + password.Text + "')");
                    this.Close();
                }
            }
        }
    }
}
