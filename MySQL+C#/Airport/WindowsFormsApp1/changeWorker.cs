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
                MessageBox.Show("Не введено id");
            if (role.Text=="")
            {
                var data1 = sqlActions.doSqlCommand("Select role_id From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    role.Text = d[0];
                }
            }
            if (name.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select name From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    name.Text = d[0];
                }
            }
            if (surname.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select surname From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    surname.Text = d[0];
                }
            }
            if (passport.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select passport_number From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    passport.Text = d[0];
                }
            }
            if (login.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select login From Users Where user_id=" + id.Text, 1);
                foreach (var d in data1)
                {
                    login.Text = d[0];
                }
            }
            String pass = "";
            var check10 = sqlActions.doSqlCommand("Select passport_number From Users Where user_id=" + id.Text, 1);
            foreach (var d in check10)
            {
                pass = d[0];
            }
            bool isTrue = false;
            var check = sqlActions.doSqlCommand("Select * From Users", 7);
            foreach (var d in check)
            {
                if (d[4] == passport.Text && passport.Text!=pass)
                {
                    isTrue = true;
                    break;
                }
            }

            String log = "";
            var check11 = sqlActions.doSqlCommand("Select login From Users Where user_id=" + id.Text, 1);
            foreach (var d in check11)
            {
                log = d[0];
            }

            bool isLogin = false;
            var check12 = sqlActions.doSqlCommand("Select * From Users", 7);
            foreach (var d in check12)
            {
                if (d[5] == login.Text && login.Text != log)
                {
                    isLogin = true;
                    break;
                }
            }


            if (isTrue || isLogin)
            {
                if (isTrue)
                    MessageBox.Show("Есть такой паспорт!");
                if (isLogin)
                    MessageBox.Show("Есть такой лоигн!");
            }
            else
            {


                var data = sqlActions.doSqlCommand("Update Users " +
                                                "Set role_id=" + Int32.Parse(role.Text) + ", name='" + name.Text +
                                                "', surname='" + surname.Text + "', passport_number='" + passport.Text +
                                                "', login='" + login.Text + "'" +
                                                " Where user_id=" + id.Text, 6);
                this.Close();
            }
        }
    }
}
