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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idCl.Text = "Id:\n";
            nameCl.Text = "Name:\n";
            surnameCl.Text = "Surname:\n";
            passport.Text = "Passport:\n";
            status.Text = "Status:\n";
            var data = sqlActions.doSqlCommand("Select user_id, name, surname, passport_number, role_name From Workers", 5);
            foreach (var d in data)
            {
                idCl.Text += d[0] + "\n";
                nameCl.Text += d[1] + "\n";
                surnameCl.Text += d[2] + "\n";
                passport.Text += d[3] + "\n";
                status.Text += d[4] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            newUser user = new newUser();
            user.Show();
            idCl.Text = "Id:\n";
            nameCl.Text = "Name:\n";
            surnameCl.Text = "Surname:\n";
            passport.Text = "Passport:\n";
            status.Text = "Status:\n";
            var data = sqlActions.doSqlCommand("Select user_id, name, surname, passport_number, role_name From Workers", 5);
            foreach (var d in data)
            {
                idCl.Text += d[0] + "\n";
                nameCl.Text += d[1] + "\n";
                surnameCl.Text += d[2] + "\n";
                passport.Text += d[3] + "\n";
                status.Text += d[4] + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (delCl.Text == "")
                MessageBox.Show("Пустое поле");
            else
            {
                sqlActions.doSqlCommand("Delete From Users Where user_id=" + delCl.Text);
                idCl.Text = "Id:\n";
                nameCl.Text = "Name:\n";
                surnameCl.Text = "Surname:\n";
                passport.Text = "Passport:\n";
                status.Text = "Status:\n";
                var data = sqlActions.doSqlCommand("Select user_id, name, surname, passport_number, role_name From Workers", 5);
                foreach (var d in data)
                {
                    idCl.Text += d[0] + "\n";
                    nameCl.Text += d[1] + "\n";
                    surnameCl.Text += d[2] + "\n";
                    passport.Text += d[3] + "\n";
                    status.Text += d[4] + "\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idServ.Text = "Id:\n";
            nameServ.Text = "Name Service:\n";
            costServ.Text = "Cost:\n";
            var data = sqlActions.doSqlCommand("Select service_id, name, cost From Service", 3);
            foreach (var d in data)
            {
                idServ.Text += d[0] + "\n";
                nameServ.Text += d[1] + "\n";
                costServ.Text += d[2] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (newId.Text == "" || newCost.Text == "")
                MessageBox.Show("Заполни оба поля!");
            else
            {
                sqlActions.doSqlCommand("Update Service Set cost=" + newCost.Text + " Where service_id=" + newId.Text);
                idServ.Text = "Id:\n";
                nameServ.Text = "Name Service:\n";
                costServ.Text = "Cost:\n";
                var data = sqlActions.doSqlCommand("Select service_id, name, cost From Service", 3);
                foreach (var d in data)
                {
                    idServ.Text += d[0] + "\n";
                    nameServ.Text += d[1] + "\n";
                    costServ.Text += d[2] + "\n";
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (delId.Text == "")
                MessageBox.Show("Пустое поле");
            else
            {
                sqlActions.doSqlCommand("Delete From Service Where service_id=" + delId.Text);
                idServ.Text = "Id:\n";
                nameServ.Text = "Name Service:\n";
                costServ.Text = "Cost:\n";
                var data = sqlActions.doSqlCommand("Select service_id, name, cost From Service", 3);
                foreach (var d in data)
                {
                    idServ.Text += d[0] + "\n";
                    nameServ.Text += d[1] + "\n";
                    costServ.Text += d[2] + "\n";
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (addName.Text == "" || addCost.Text == "")
                MessageBox.Show("Пустое поле");
            else
            {
                sqlActions.doSqlCommand("Insert Into Service(name, cost) Values('" + addName.Text + "','" + addCost.Text + "')");
                idServ.Text = "Id:\n";
                nameServ.Text = "Name Service:\n";
                costServ.Text = "Cost:\n";
                var data = sqlActions.doSqlCommand("Select service_id, name, cost From Service", 3);
                foreach (var d in data)
                {
                    idServ.Text += d[0] + "\n";
                    nameServ.Text += d[1] + "\n";
                    costServ.Text += d[2] + "\n";
                }
            }
        }
    }
}
