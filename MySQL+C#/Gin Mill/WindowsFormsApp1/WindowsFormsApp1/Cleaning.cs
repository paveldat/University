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
    public partial class Cleaning : Form
    {
        public Cleaning()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id.Text = "Id:\n";
            floor.Text = "Floor:\n";
            room.Text = "Room:\n";
            status.Text = "Status:\n";
            var data = sqlActions.doSqlCommand("Select * From forClean",4);
            foreach(var d in data)
            {
                id.Text += d[0] + "\n";
                floor.Text += d[1] + "\n";
                room.Text += d[2] + "\n";
                status.Text += d[3] + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idClean.Text == "")
                MessageBox.Show("Введи id");
            else
            {
                sqlActions.doSqlCommand("Update Cleaning Set status_id=1 Where clean_id=" + idClean.Text);
                id.Text = "Id:\n";
                floor.Text = "Floor:\n";
                room.Text = "Room:\n";
                status.Text = "Status:\n";
                var data = sqlActions.doSqlCommand("Select * From forClean", 4);
                foreach (var d in data)
                {
                    id.Text += d[0] + "\n";
                    floor.Text += d[1] + "\n";
                    room.Text += d[2] + "\n";
                    status.Text += d[3] + "\n";
                }
            }
        }
    }
}
