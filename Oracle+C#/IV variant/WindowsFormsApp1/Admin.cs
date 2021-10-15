using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Admin : MetroForm
    {
        OleDbConnection sqlConnection;
        private string login;

        public Admin() //тест
        {
            InitializeComponent();
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##TESTPAV;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            SidePanel.Location = new Point(1, button1.Location.Y + 6);
            firstCustomControl2.BringToFront();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        public Admin(string log)
        {
            InitializeComponent();
            login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##TESTPAV;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            SidePanel.Location = new Point(1, button1.Location.Y + 6);
            firstCustomControl2.BringToFront();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            this.Hide();

            this.Alert("Выход выполнен успешно", Form_Alert.enmType.Success);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(1, button1.Location.Y + 6);
            firstCustomControl2.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(1, button2.Location.Y + 6);
            secondCustomControl1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Location = new Point(1, button3.Location.Y + 6);
            thirdCustomControl1.BringToFront();
        }
    }
}
