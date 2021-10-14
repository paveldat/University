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
    public partial class Client : Form
    {
        int UserId { get; set; }
        public Client(int userID)
        {
            InitializeComponent();
            UserId = userID;
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            infoClient.Text = "";
            var data = sqlActions.doSqlCommand("Select name, surname, passport_number, login From Users Where user_id=" + UserId, 4);
            foreach(var d in data)
            {
                infoClient.Text = d[0]+ " " + d[1] + " " + d[2] + " " + d[3];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idServ.Text = "Id:\n";
            nameServ.Text = "Name Service:\n";
            costServ.Text = "Cost:\n";
            var data = sqlActions.doSqlCommand("Select service_id, name, cost From Service", 3);
            foreach(var d in data)
            {
                idServ.Text += d[0] + "\n";
                nameServ.Text += d[1] + "\n";
                costServ.Text += d[2] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nameServUse.Text = "Services:\n";
            var data = sqlActions.doSqlCommand("Select s.name From Service s, Requests r Where r.service_id=s.service_id And r.user_id=" + UserId, 1);
            foreach(var d in data)
            {
                nameServUse.Text += d[0] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int room = 0;
            var data = sqlActions.doSqlCommand("Select room_id From Booking Where user_id=" + UserId, 1);
            foreach(var d in data)
            {
                room = Int32.Parse(d[0]);
            }

            sqlActions.doSqlCommand("Insert Into Cleaning(room_id,status_id) Values(" + room + ", 2)");
            MessageBox.Show("Успешно создано!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
                MessageBox.Show("Укажите id услуги");
            else
            {
                sqlActions.doSqlCommand("Insert Into Requests(service_id, user_id, status_id) Values(" + id.Text + "," + UserId + ",2)");
                nameServUse.Text = "Services:\n";
                var data = sqlActions.doSqlCommand("Select s.name From Service s, Requests r Where r.service_id=s.service_id And r.user_id=" + UserId, 1);
                foreach (var d in data)
                {
                    nameServUse.Text += d[0] + "\n";
                }
            }
        }
    }
}
