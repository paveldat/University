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
    public partial class Pilot : Form
    {
        int userId { get; set; }
        public Pilot(int userId_)
        {
            InitializeComponent();

            userId = userId_;
        }


        private void Pilot_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idplane.Text = "Id:\n";
            nameplane.Text = "Название:\n";
            companyplane.Text = "Компания:\n";

            var data = sqlActions.doSqlCommand("Select * From Plane", 3);
            foreach (var d in data)
            {
                idplane.Text += d[0] + "\n";
                nameplane.Text += d[1] + "\n";
                companyplane.Text += d[2] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            id.Text = "Id\n";
            disp.Text = "Вылет:\n";
            arr.Text = "Посадка:\n";
            date1.Text = "Дата Вылета:\n";
            date2.Text = "Дата посадки:\n";

            var data = sqlActions.doSqlCommand("Select * From Flight Where pilot_id="+ userId, 7);
            foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                date1.Text += d[5] + "\n";
                date2.Text += d[6] + "\n";
            }

            var data1 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_dispatch_id And f.pilot_id="+ userId, 1);
            foreach (var d in data1)
            {
                disp.Text += d[0] + "\n";
            }

            var data2 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_arrival_id And pilot_id="+ userId, 1);
            foreach (var d in data2)
            {
                arr.Text += d[0] + "\n";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nameplane_TextChanged(object sender, EventArgs e)
        {

        }

        private void idplane_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void companyplane_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
