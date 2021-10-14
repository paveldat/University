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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || room.Text == "" || date1.Text == "" || date2.Text == "")
                MessageBox.Show("Пустое поле!!!");
            else
            {
                sqlActions.doSqlCommand("Insert Into Booking(user_id, room_id, date_arrival, date_departure) Values('" + id.Text + "','" + room.Text + "','" + date1.Text + "','" + date2.Text + "')");
                this.Close();
            }
        }
    }
}
