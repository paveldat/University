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
    public partial class changeWork : Form
    {
        public changeWork()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
                MessageBox.Show("Не введено id");
            else
            {
                if (theme.Text == "")
                    MessageBox.Show("Не указана тема");
                else
                {
                    sqlActions.doSqlCommand("Update Work Set name_work='" + theme.Text + "' Where work_id=" + id.Text);
                    this.Close();
                }
            }
        }
    }
}
