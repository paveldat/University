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
    public partial class Cashier : Form
    {        
        public Cashier()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient newClient = new AddClient();
            newClient.ShowDialog();
            id.Text = "Id\n";
            surname.Text = "Фамилия:\n";
            name.Text = "Имя:\n";
            passport.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From Ticket", 8);
            foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                surname.Text += d[3] + "\n";
                name.Text += d[2] + "\n";
                passport.Text += d[4] + "\n";
            }
        }

        private void Clients_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id.Text = "Id\n";
            surname.Text = "Фамилия:\n";
            name.Text = "Имя:\n";
            passport.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From Ticket", 8);
            foreach (var d in data)
            {
                id.Text += d[0]  + "\n";
                surname.Text += d[3] + "\n";
                name.Text += d[2] + "\n";
                passport.Text += d[4] + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (passportCl.Text != "Write passport")
            {
                sqlActions.doSqlCommand("Delete From Ticket Where passport_number='" + passportCl.Text+"'");
            }
            id.Text = "Id\n";
            surname.Text = "Фамилия:\n";
            name.Text = "Имя:\n";
            passport.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From Ticket", 8);
            foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                surname.Text += d[3] + "\n";
                name.Text += d[2] + "\n";
                passport.Text += d[4] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
