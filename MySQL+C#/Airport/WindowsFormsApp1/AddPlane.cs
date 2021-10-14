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
    public partial class AddPlane : Form
    {
        public AddPlane()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (planeName.Text=="" || companyName.Text=="")
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                var data = sqlActions.doSqlCommand("Insert Into Plane(plane_name,company)" +
                                                    "Values('" + planeName.Text + "','" + companyName.Text + "')",2);
                this.Close();
            }
        }
    }
}
