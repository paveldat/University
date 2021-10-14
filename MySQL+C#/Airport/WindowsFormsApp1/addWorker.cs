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
    public partial class addWorker : Form
    {
        public addWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isTrue = false;
            bool isTrue1 = false;
            if (role_id.Text == "" || nameUser.Text == "" || surnameUser.Text == "" || passportUser.Text == "" || loginUser.Text == "" || passwordUser.Text == "")
            {
                MessageBox.Show("Пустое поле!!!");
            }
            else
            {
                var check = sqlActions.doSqlCommand("Select * From Users", 7);
                foreach (var d in check)
                {
                    if (d[4] == passportUser.Text)
                    {
                        isTrue = true;
                        break;
                    }
                    if(d[5]==loginUser.Text)
                    {
                        isTrue1 = true;
                        break;
                    }
                }
                if (isTrue || isTrue1)
                {   
                    if(isTrue)
                        MessageBox.Show("Существует такой паспорт!!!");
                    if(isTrue1)
                        MessageBox.Show("Существует такой логин!!!");
                }
                else
                {
                    int role = Int32.Parse(role_id.Text);
                    var data = sqlActions.doSqlCommand("Insert Into Users(role_id,name,surname,passport_number,login,password)" +
                                                        "Values(" + role + ",'" + nameUser.Text + "','" + surnameUser.Text + "','" +
                                                        passportUser.Text + "','" + loginUser.Text + "','" + passwordUser.Text + "')", 6);
                    this.Close();
                }
            }
        }
    }
}
