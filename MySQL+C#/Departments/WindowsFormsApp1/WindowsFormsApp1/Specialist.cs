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
    public partial class Specialist : Form
    {
        public Specialist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id.Text = "Id:\n";
            name.Text = "Название:\n";
            telephone.Text = "Телефон:\n";
            adress.Text = "Адрес:\n";

            var data = sqlActions.doSqlCommand("Select * From Department", 6);
            foreach(var d in data)
            {
                id.Text += d[0] + "\n";
                name.Text += d[2] + "\n";
                telephone.Text += d[3] + "\n";
                adress.Text += d[4] + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            idst.Text = "Id:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            if(depid.Text!="")
            {
                var data = sqlActions.doSqlCommand("Select * From Students Where dep_id=" + depid.Text, 8);
                foreach(var d in data)
                {
                    idst.Text += d[0] + "\n";
                    namest.Text += d[1] + "\n";
                    surnamest.Text += d[2] + "\n";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            theme.Text = "";
            if(stid.Text!="")
            {
                var data = sqlActions.doSqlCommand("Select Work.name_work From Work, Students Where Work.work_id=Students.work_id AND Students.student_id=" + stid.Text, 1);
                foreach(var d in data)
                {
                    theme.Text += d[0];
                }
            }
        }
    }
}
