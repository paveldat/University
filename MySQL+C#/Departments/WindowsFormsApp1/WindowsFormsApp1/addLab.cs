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
    public partial class addLab : Form
    {
        public addLab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int chief = Int32.Parse(textBox1.Text);
            int dep = Int32.Parse(textBox2.Text);
            sqlActions.doSqlCommand("Insert Into Labarotary(chief,department) Values(" + chief + ", " + dep + ")");
            this.Close();
        }
    }
}
