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
    public partial class changeWorker : Form
    {
        public changeWorker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
                MessageBox.Show("Нет Id");
            else
            {
                var data = sqlActions.doSqlCommand("Select * From Users Where user_id=" + id.Text, 8);
                foreach (var d in data)
                {
                    if (role.Text == "")
                        role.Text = d[1];
                    if (dep.Text == "")
                        dep.Text = d[2];
                    if (name.Text == "")
                        name.Text = d[3];
                    if (surname.Text == "")
                        surname.Text = d[4];
                    if (passport.Text == "")
                        passport.Text = d[5];
                }
                bool isPassport = false;
                String pass = "";
                var data1 = sqlActions.doSqlCommand("Select passport_number From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    pass = d[0];
                }
                var data2 = sqlActions.doSqlCommand("Select * From Users", 8);
                foreach (var d in data2)
                {
                    if (d[5] == passport.Text && passport.Text != pass)
                    {
                        isPassport = true;
                        break;
                    }
                }
                if (isPassport)
                    MessageBox.Show("Есть такой паспорт!");
                else
                {
                    var dat = sqlActions.doSqlCommand("Update Users " +
                                                    "Set role_id=" + Int32.Parse(role.Text) + ", dep_id=" + Int32.Parse(dep.Text) + ", name='" + name.Text +
                                                    "',surname='" + surname.Text + "',passport_number='" + passport.Text + "' Where user_id="+id.Text, 6);
                    this.Close();
                }
            }
        }
    }
}
