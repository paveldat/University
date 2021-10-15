using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class employee : Form
    {
        OleDbConnection sqlConnection;
        private string login;

        public employee(string log)
        {
            InitializeComponent();
            login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##6VAR;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            getDiagnosis();
        }

        private void getDiagnosis()
        {
            string str = "select d.name, w.name " +
                            "from diagnosis d " +
                            "join people p " +
                            "on p.diagnosis_id = d.id " +
                            "join wards w " +
                            "on w.id = p.ward_id " +
                            "join users u " +
                            "on u.id = p.users_id " +
                            "where u.login = '" + login + "'";
            DataTable table = new DataTable();
            OleDbDataAdapter DA1 = new OleDbDataAdapter(str, sqlConnection);
            DA1.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            getDiagnosis();
        }
    }
}
