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
    public partial class Personnel : Form
    {
        OleDbConnection sqlConnection;
        private string login;

        public Personnel(string log)
        {
            InitializeComponent();
            login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##SVETA;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        }

        private void button9_Click(object sender, EventArgs e) //изменить
        {
            string res1 = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //тайм аут
            string res2 = dataGridView1.CurrentRow.Cells[1].FormattedValue.ToString(); //тайм ин
            string res3 = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString(); //номер
            string res4 = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString(); //путь

            if ("".Equals(comboBox4.Text))
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите поменять!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (Convert.ToDateTime(res2) <= DateTime.Now)
            {
                MessageBox.Show("Пожалуйста, нельзя менять уже проеханный маршрут!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                switch (comboBox4.Text)
                {
                    case "Время прибытия":
                        if ("".Equals(dateTimePicker2.Text))
                        {
                            MessageBox.Show("Пожалуйста, выберите новое время прибытия!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else if (Convert.ToDateTime(res1) >= Convert.ToDateTime(dateTimePicker2.Text))
                        {
                            MessageBox.Show("Пожалуйста, время прибытия не может быть меньше отбытия!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update JOURNAL set time_in = TO_TIMESTAMP('" + dateTimePicker2.Text + "', 'DD-MM-RR HH24:MI:SS')" +
                            "where time_out = TO_TIMESTAMP('" + res1 + "', 'DD-MM-RR HH24:MI:SS') " +
                            "and time_in = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS') " +
                            "and auto_id = (select id from auto where num = '" + res3 + "') " +
                            "and route_id = (select id from routes where name = '" + res4 + "')";
                            OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            getJournal();
                        }
                        break;
                    case "Время отправления":
                        if ("".Equals(dateTimePicker1.Text))
                        {
                            MessageBox.Show("Пожалуйста, выберите новое время отправления!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update JOURNAL set time_out = TO_TIMESTAMP('" + dateTimePicker1.Text + "', 'DD-MM-RR HH24:MI:SS')" +
                            "where time_out = TO_TIMESTAMP('" + res1 + "', 'DD-MM-RR HH24:MI:SS') " +
                            "and time_in = TO_TIMESTAMP('" + res2 + "', 'DD-MM-RR HH24:MI:SS') " +
                            "and auto_id = (select id from auto where num = '" + res3 + "') " +
                            "and route_id = (select id from routes where name = '" + res4 + "')";
                            OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            getJournal();
                        }
                        break;
                }
            }
        }

        private void getJournal()
        {
            string str = "select time_out, time_in, a.num, r.name " +
                "from journal j " +
                "join auto a " +
                "on a.id = j.auto_id " +
                "join routes r " +
                "on r.id = j.route_id " +
                "join auto_personnel ap " +
                "on ap.id = a.personnel_id " +
                "join users u " +
                "on u.id = ap.user_id " +
                "where login = '" + login + "'";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns[0].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss";
        }

        private void button2_Click(object sender, EventArgs e) //показать
        {
            getJournal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "select a.num, a.color, a.mark " +
                "from journal j " +
                "join auto a " +
                "on a.id = j.auto_id " +
                "join routes r " +
                "on r.id = j.route_id " +
                "join auto_personnel ap " +
                "on ap.id = a.personnel_id " +
                "join users u " +
                "on u.id = ap.user_id " +
                "where login = '" + login + "'";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyAcc form = new MyAcc(login);
            form.Show();
            this.Hide();
        }
    }
}
