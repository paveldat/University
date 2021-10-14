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
    public partial class changeFlight : Form
    {
        public changeFlight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flight_id.Text == "")
            {
                MessageBox.Show("Поле Flight_id пустое!");
            }

            bool isTrue = false;
            var data = sqlActions.doSqlCommand("Select * From Flight", 7);
            foreach (var d in data)
            {
                if (d[0] == flight_id.Text)
                {
                    isTrue = true;
                    break;
                }
            }
            if(!isTrue)
                MessageBox.Show("Нет такого Flight_id!");

            int flightId = Int32.Parse(flight_id.Text);
            

            //1
            if (plane_id.Text=="")
            {
                var data1 = sqlActions.doSqlCommand("Select f.plane_id From Flight f Where flight_id="+flightId,1);
                foreach (var d in data1)
                {
                    plane_id.Text = d[0];
                }
            }
            
            //2
            if (pilot_id.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select f.pilot_id From Flight f Where flight_id=" + flightId, 1);
                foreach (var d in data1)
                {
                    pilot_id.Text = d[0];
                }
            }
            

            //3
            if (disp.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select f.airport_dispatch_id From Flight f Where flight_id=" + flightId, 1);
                foreach (var d in data1)
                {
                    disp.Text = d[0];
                }
            }
            

            //4
            if (arr.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select f.airport_arrival_id From Flight f Where flight_id=" + flightId, 1);
                foreach (var d in data1)
                {
                    arr.Text = d[0];
                }
            }
            

            //5
            if (date1.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select f.departure_date From Flight f Where flight_id=" + flightId, 1);
                foreach (var d in data1)
                {
                    date1.Text = d[0];
                }
            }
           

            //6
            if (date2.Text == "")
            {
                var data1 = sqlActions.doSqlCommand("Select f.arrival_date From Flight f Where flight_id=" + flightId, 1);
                foreach (var d in data1)
                {
                    date2.Text = d[0];
                }
            }
           

            //change
            var data5 = sqlActions.doSqlCommand("Update Flight " +
                                                "Set plane_id=" + Int32.Parse(plane_id.Text) + ", pilot_id="+Int32.Parse(pilot_id.Text) + 
                                                ", airport_dispatch_id="+Int32.Parse(disp.Text) + ", airport_arrival_id="+Int32.Parse(arr.Text) +
                                                ", departure_date='"+date1.Text + "',arrival_date='"+date2.Text + 
                                                "' Where flight_id="+flightId, 6);
            this.Close();
        }
    }
}
