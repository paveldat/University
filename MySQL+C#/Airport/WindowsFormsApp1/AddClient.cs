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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isTrue = false;
            bool isSeat = false;
            if (flight_id.Text == "" || name.Text == "" || surname.Text == "" || passport.Text == "" || price.Text == "" || seat.Text == "" || enable.Text == "")
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                var check = sqlActions.doSqlCommand("Select * From Ticket", 8);
                foreach (var d in check)
                {
                    if(d[4]==passport.Text && (d[2]!=name.Text && d[3] != surname.Text))
                    {
                        isTrue = true;
                        break;
                    }
                }

                var check1 = sqlActions.doSqlCommand("Select * From Ticket", 7);
                foreach (var d in check1)
                {
                    if (d[6] == seat.Text && d[1] == flight_id.Text)
                    {
                        isSeat = true;
                        break;
                    }
                }
              
                if (isTrue || isSeat)
                {
                    if(isTrue)
                        MessageBox.Show("Уже есть такой паспорт!");
                    if (isSeat)
                        MessageBox.Show("Место уже занято!");
                }
                else
                {
                    int flight = Int32.Parse(flight_id.Text);
                    int priceT = Int32.Parse(price.Text);
                    int seatT = Int32.Parse(seat.Text);
                    int enableT = Int32.Parse(enable.Text);
                    bool enbl;
                    if (enableT == 1)
                        enbl = true;
                    else
                        enbl = false;


                    if (priceT <= 0)
                    {
                        MessageBox.Show("Отрицательная цена");
                        this.Close();
                    }
                    else
                    {
                        var data = sqlActions.doSqlCommand("Insert Into Ticket(flight_id,passager_name,passager_surname,passport_number,price,seat, enable)" +
                                                            "Values(" + flight + ", '" + name.Text + "','" + surname.Text + "','" + passport.Text + "'," + priceT +
                                                                "," + seatT + "," + enableT + ")", 7);
                        this.Close();
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
