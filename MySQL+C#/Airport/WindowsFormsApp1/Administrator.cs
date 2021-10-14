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
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            userId.Text = "Id:\n";
            role.Text = "Должность:\n";
            nameUser.Text = "Имя:\n";
            surnameUser.Text = "Фамилия:\n";
            passUser.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From test1", 6);
            foreach(var d in data)
            {
                userId.Text += d[1] + "\n";
                role.Text += d[0] + "\n";
                nameUser.Text += d[2] + "\n";
                surnameUser.Text += d[3] + "\n";
                passUser.Text += d[4] + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addWorker worker = new addWorker();
            worker.ShowDialog();
            userId.Text = "Id:\n";
            role.Text = "Должность:\n";
            nameUser.Text = "Имя:\n";
            surnameUser.Text = "Фамилия:\n";
            passUser.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From test1", 6);
            foreach (var d in data)
            {
                userId.Text += d[1] + "\n";
                role.Text += d[0] + "\n";
                nameUser.Text += d[2] + "\n";
                surnameUser.Text += d[3] + "\n";
                passUser.Text += d[4] + "\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (pspDelete.Text!="")
            {
                sqlActions.doSqlCommand("Delete From Users Where passport_number='" + pspDelete.Text + "'");
            }
            userId.Text = "Id:\n";
            role.Text = "Должность:\n";
            nameUser.Text = "Имя:\n";
            surnameUser.Text = "Фамилия:\n";
            passUser.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From test1", 6);
            foreach (var d in data)
            {
                userId.Text += d[1] + "\n";
                role.Text += d[0] + "\n";
                nameUser.Text += d[2] + "\n";
                surnameUser.Text += d[3] + "\n";
                passUser.Text += d[4] + "\n";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            month.Text = "";
            var data = sqlActions.doSqlCommand("Select * From test2", 2);
            foreach (var d in data)
            {
                month.Text += d[0] + "         " + d[1] + "\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            maxPrice.Text = "";
            var data = sqlActions.doSqlCommand("Select * From priceMax", 2);
            foreach (var d in data)
            {
                maxPrice.Text += d[0] + "         " + d[1] + "\n";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            reis.Text = "";
            var data = sqlActions.doSqlCommand("Select * From flght", 1);
            foreach (var d in data)
            {
                reis.Text += d[0] + "\n";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dateDisp.Text != "Дату вылета")
            {
                id.Text = "Id\n";
                disp.Text = "Вылет:\n";
                arr.Text = "Посадка:\n";
                date1.Text = "Дата Вылета:\n";
                date2.Text = "Дата посадки:\n";


                var data = sqlActions.doSqlCommand("Select * From Flight Where Flight.departure_date='" + dateDisp.Text+"'", 7);
                foreach (var d in data)
                {
                    id.Text += d[0] + "\n";
                    date1.Text += d[5] + "\n";
                    date2.Text += d[6] + "\n";
                }

                var data1 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_dispatch_id And f.departure_date='" + dateDisp.Text+"'", 1);
                foreach (var d in data1)
                {
                    disp.Text += d[0] + "\n";
                }

                var data2 = sqlActions.doSqlCommand("Select a.city From Flight f, Airport a Where a.airport_id=f.airport_arrival_id And f.departure_date='" + dateDisp.Text+"'", 1);
                foreach (var d in data2)
                {
                    arr.Text += d[0] + "\n";
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            changeWorker worker = new changeWorker();
            worker.ShowDialog();
            userId.Text = "Id:\n";
            role.Text = "Должность:\n";
            nameUser.Text = "Имя:\n";
            surnameUser.Text = "Фамилия:\n";
            passUser.Text = "Паспорт:\n";
            var data = sqlActions.doSqlCommand("Select * From test1", 6);
            foreach (var d in data)
            {
                userId.Text += d[1] + "\n";
                role.Text += d[0] + "\n";
                nameUser.Text += d[2] + "\n";
                surnameUser.Text += d[3] + "\n";
                passUser.Text += d[4] + "\n";
            }
        }
    }
}
