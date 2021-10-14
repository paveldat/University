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
    public partial class changePlane : Form
    {
        public changePlane()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idPlane.Text=="")
            {
                MessageBox.Show("Нет id самолета!");
            }
            else
            {
                int id = Int32.Parse(idPlane.Text);

                if (namePlane.Text=="" && company.Text=="")
                {
                    MessageBox.Show("Должно быть хотя бы одно изменение!");
                }

                if (namePlane.Text!="" && company.Text=="")
                {
                    var data = sqlActions.doSqlCommand("Update Plane Set plane_name='" + namePlane.Text + "' Where plane_id=" + id,2);
                    this.Close();
                }

                if (namePlane.Text == "" && company.Text != "")
                {
                    var data = sqlActions.doSqlCommand("Update Plane Set company='" + company.Text + "' Where plane_id=" + id, 2);
                    this.Close();
                }

                if (namePlane.Text != "" && company.Text != "")
                {
                    var data = sqlActions.doSqlCommand("Update Plane Set plane_name='" + namePlane.Text + "', company='" + company.Text +"' Where plane_id=" + id, 2);
                    this.Close();
                }
            }
        }
    }
}
