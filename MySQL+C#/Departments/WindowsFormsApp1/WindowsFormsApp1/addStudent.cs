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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || surname.Text == "" || passport.Text == "" || dep.Text == "" || numdep.Text == "" || rec.Text == "" || del.Text == "")
                MessageBox.Show("Пустое поле!!!");
            else
            {
                bool isPassport = false;
                var data = sqlActions.doSqlCommand("Select * From Students", 8);
                foreach (var d in data)
                {
                    if (d[3] == passport.Text)
                    {
                        isPassport = true;
                        break;
                    }
                }
                if (isPassport)
                    MessageBox.Show("Есть такой паспорт!!!");
                else
                {
                    var data1 = sqlActions.doSqlCommand("Insert Into Students(name, surname, passport_number, dep_id, work_id, date_receive, date_delivery)" +
                                                       "Values('" + name.Text + "', '" + surname.Text + "', '" + passport.Text + "', " + dep.Text + ", " + numdep.Text + ", '" + rec.Text + "', '" + del.Text + "')", 8);
                    this.Close();
                }
            }
        }
    }
}
