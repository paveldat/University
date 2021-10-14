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
    public partial class AddFlight : Form
    {
        public AddFlight()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idPlane.Text=="" || idPilot.Text=="" || dispAiroport.Text=="" || arvAiroport.Text=="" || departDate.Text=="" || arvDate.Text=="")
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                int plane_id = Int32.Parse(idPlane.Text);
                int pilot_id = Int32.Parse(idPilot.Text);
                int airport_dispatch = Int32.Parse(dispAiroport.Text);
                int airport_arrival = Int32.Parse(arvAiroport.Text);
                var data = sqlActions.doSqlCommand("Insert Into Flight(plane_id,pilot_id,airport_dispatch_id,airport_arrival_id,departure_date,arrival_date)" +
                                                    "Values(" + plane_id + "," + pilot_id + "," + airport_dispatch + "," + airport_arrival + ",'" +
                                                     departDate.Text + "','" + arvDate.Text + "')", 6);
                this.Close();
            }
        }
    }
}
