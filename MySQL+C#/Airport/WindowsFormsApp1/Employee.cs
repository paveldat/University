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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void showFlights_Click(object sender, EventArgs e)
        {
            id.Text = "Id\n";
            disp.Text = "Вылет:\n";
            arr.Text = "Посадка:\n";
            date1.Text = "Дата Вылета:\n";
            date2.Text = "Дата посадки:\n";

            var data = sqlActions.doSqlCommand("Select * From Flight", 7);
           foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                date1.Text += d[5] + "\n";
                date2.Text += d[6] + "\n";
            }

            var data1 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_dispatch_id",1);
            foreach (var d in data1)
            {
                disp.Text += d[0] + "\n";
            }

            var data2 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_arrival_id", 1);
            foreach (var d in data2)
            {
                arr.Text += d[0] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddPlane plane = new AddPlane();
            plane.ShowDialog();
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddFlight flight = new AddFlight();
            flight.ShowDialog();
            id.Text = "Id\n";
            disp.Text = "Вылет:\n";
            arr.Text = "Посадка:\n";
            date1.Text = "Дата Вылета:\n";
            date2.Text = "Дата посадки:\n";

            var data = sqlActions.doSqlCommand("Select * From Flight", 7);
            foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                date1.Text += d[5] + "\n";
                date2.Text += d[6] + "\n";
            }

            var data1 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_dispatch_id", 1);
            foreach (var d in data1)
            {
                disp.Text += d[0] + "\n";
            }

            var data2 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_arrival_id", 1);
            foreach (var d in data2)
            {
                arr.Text += d[0] + "\n";
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            changePlane plane = new changePlane();
            plane.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void change_Click(object sender, EventArgs e)
        {
            changeFlight flight = new changeFlight();
            flight.ShowDialog();
            id.Text = "Id\n";
            disp.Text = "Вылет:\n";
            arr.Text = "Посадка:\n";
            date1.Text = "Дата Вылета:\n";
            date2.Text = "Дата посадки:\n";

            var data = sqlActions.doSqlCommand("Select * From Flight", 7);
            foreach (var d in data)
            {
                id.Text += d[0] + "\n";
                date1.Text += d[5] + "\n";
                date2.Text += d[6] + "\n";
            }

            var data1 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_dispatch_id", 1);
            foreach (var d in data1)
            {
                disp.Text += d[0] + "\n";
            }

            var data2 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_arrival_id", 1);
            foreach (var d in data2)
            {
                arr.Text += d[0] + "\n";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            bool isOcupate = false;
            var data = sqlActions.doSqlCommand("Select f.plane_id From Flight f", 1);
            foreach (var d in data)
            {
                if (d[0]==idplane1.Text)
                {
                    isOcupate = true;
                    break;
                }
            }
            if (isOcupate)
            {
                MessageBox.Show("Самолет зарегистрирован на рейс!");
            }
            else
            {
                sqlActions.doSqlCommand("Delete From Plane Where plane_id=" + idplane1.Text);

                idplane.Text = "Id:\n";
                nameplane.Text = "Название:\n";
                companyplane.Text = "Компания:\n";

                var data1 = sqlActions.doSqlCommand("Select * From Plane", 3);
                foreach (var d in data1)
                {
                    idplane.Text += d[0] + "\n";
                    nameplane.Text += d[1] + "\n";
                    companyplane.Text += d[2] + "\n";
                }
            }
        }

        private void date1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void arr_TextChanged(object sender, EventArgs e)
        {

        }

        private void disp_TextChanged(object sender, EventArgs e)
        {

        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void date2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
