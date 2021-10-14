using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Accountant : Form
    {
        SqlConnection sqlConnection;
        private string login;

        public Accountant(string log)
        {
            InitializeComponent();
            this.login = log;
            string connection = @"Data Source=KIRILL\SQLEXPRESS;Initial Catalog=UpComany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connection);

            string str = "SELECT FIO FROM Clients";
            DataTable table = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "select c.FIO as ClientFIO" +
                ", r.Status" +
                ", u.FIO as UserFIO" +
                ", rr.Name " +
                "from [References] r " +
                "inner join Clients c " +
                "on c.Client_id=r.Client_id " +
                "inner join Users u " +
                "on u.User_id=r.User_id " +
                "inner join Role rr " +
                "on rr.Role_id=u.Role_id";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            str = "select Bid_id as NumBid" +
                ", e.FIO" +
                ", BidTime" +
                ", BidStatus" +
                ", TypeWork" +
                ", Price " +
                "from Bid b " +
                "left join BidPrice bp " +
                "on b.BidPrice_id=bp.BidPrice_id " +
                "inner join ExecutorSchedule es " +
                "on es.ExecutorSchedule_id=b.ExecutorSchedule_id " +
                "inner join Executor e " +
                "on e.Executor_id=es.Executor_id";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            str = "select Adress" +
                ", Price " +
                "from Price p " +
                "inner join Houses h " +
                "on h.Price_id=p.Price_id " +
                "inner join Overhaul o " +
                "on o.Overhaul_id=p.Overhaul_id";
            table = new DataTable();
            DA = new SqlDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e) //справки.создать
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите клиента!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "insert into [References] values ((select Client_id from Clients where FIO = '"+ comboBox1.Text +"'), 0, (select User_id from Users where Login = '"+ login +"'))";
                SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                string str = "select c.FIO as ClientFIO" +
                ", r.Status" +
                ", u.FIO as UserFIO" +
                ", rr.Name " +
                "from [References] r " +
                "inner join Clients c " +
                "on c.Client_id=r.Client_id " +
                "inner join Users u " +
                "on u.User_id=r.User_id " +
                "inner join Role rr " +
                "on rr.Role_id=u.Role_id";
                DataTable table = new DataTable();
                SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button2_Click(object sender, EventArgs e) //справки.изменить
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, выберите новый статус!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (comboBox2.Text == "0" || comboBox2.Text == "1" || comboBox2.Text == "2")
                {
                    string selectedState = comboBox2.Text;
                    string res = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString();
                    string res1 = dataGridView1.CurrentRow.Cells[1].FormattedValue.ToString();
                    string res2 = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();

                    string st = "update [References] set Status = '" + selectedState + "' " +
                        "where Status = '" + res1 + "' " +
                        "and Client_id = (select Client_id from Clients where FIO = '" + res + "')" +
                        "and User_id = (select User_id from Users where FIO = '" + res2 + "')";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select c.FIO as ClientFIO" +
                    ", r.Status" +
                    ", u.FIO as UserFIO" +
                    ", rr.Name " +
                    "from [References] r " +
                    "inner join Clients c " +
                    "on c.Client_id=r.Client_id " +
                    "inner join Users u " +
                    "on u.User_id=r.User_id " +
                    "inner join Role rr " +
                    "on rr.Role_id=u.Role_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else
                    MessageBox.Show("Пожалуйста, введите корректный статус, он может быть только 2, 1 или 0!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите стоимость заявки!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (Convert.ToInt32(textBox1.Text) >= 0)
                {
                    string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();

                    string st = "begin transaction; " +
                        "insert into BidPrice values ('" + textBox1.Text + "'); " +
                        "update Bid set BidPrice_id = (select top 1 BidPrice_id from BidPrice order by BidPrice_id desc) where Bid_id = " + res + "; " +
                        "commit;";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select Bid_id as NumBid" +
                    ", e.FIO" +
                    ", BidTime" +
                    ", BidStatus" +
                    ", TypeWork" +
                    ", Price " +
                    "from Bid b " +
                    "left join BidPrice bp " +
                    "on b.BidPrice_id=bp.BidPrice_id " +
                    "inner join ExecutorSchedule es " +
                    "on es.ExecutorSchedule_id=b.ExecutorSchedule_id " +
                    "inner join Executor e " +
                    "on e.Executor_id=es.Executor_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView2.DataSource = table;
                }
                else
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите новую стоимость заявки!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (Convert.ToInt32(textBox2.Text) >= 0)
                {
                    string res = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();

                    string st = "update BidPrice set Price = '" + textBox2.Text + "' where BidPrice_id = (select BidPrice_id from Bid where Bid_id = " + res + ")";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select Bid_id as NumBid" +
                    ", e.FIO" +
                    ", BidTime" +
                    ", BidStatus" +
                    ", TypeWork" +
                    ", Price " +
                    "from Bid b " +
                    "left join BidPrice bp " +
                    "on b.BidPrice_id=bp.BidPrice_id " +
                    "inner join ExecutorSchedule es " +
                    "on es.ExecutorSchedule_id=b.ExecutorSchedule_id " +
                    "inner join Executor e " +
                    "on e.Executor_id=es.Executor_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView2.DataSource = table;
                }
                else
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите новую стоимость заявки!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (Convert.ToInt32(textBox3.Text) >= 0)
                {
                    string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

                    string st = "insert into Overhaul values ('" + textBox3.Text + "'); " +
                        "insert into Price values (NULL, (select User_id from Users where Login = '" + login + "'), (select top 1 Overhaul_id from Overhaul order by Overhaul_id desc)); " +
                        "update Houses set Price_id=(select top 1 Price_id from Price order by Price_id desc) where Adress='" + res + "';";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select Adress" +
                    ", Price " +
                    "from Price p " +
                    "inner join Houses h " +
                    "on h.Price_id=p.Price_id " +
                    "inner join Overhaul o " +
                    "on o.Overhaul_id=p.Overhaul_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView3.DataSource = table;
                }
                else
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите новую стоимость заявки!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                if (Convert.ToInt32(textBox4.Text) >= 0)
                {
                    string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

                    string st = "insert into Overhaul values ('" + textBox4.Text + "'); " +
                        "insert into Price values (NULL, (select User_id from Users where Login = '" + login + "'), (select top 1 Overhaul_id from Overhaul order by Overhaul_id desc)); " +
                        "update Houses set Price_id=(select top 1 Price_id from Price order by Price_id desc) where Adress='" + res + "';";
                    SqlDataAdapter DA1 = new SqlDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    string str = "select Adress" +
                    ", Price " +
                    "from Price p " +
                    "inner join Houses h " +
                    "on h.Price_id=p.Price_id " +
                    "inner join Overhaul o " +
                    "on o.Overhaul_id=p.Overhaul_id";
                    DataTable table = new DataTable();
                    SqlDataAdapter DA = new SqlDataAdapter(str, sqlConnection);
                    DA.Fill(table);
                    dataGridView3.DataSource = table;
                }
                else
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyAcc form = new MyAcc(login);
            form.Show();
            this.Close();
        }
    }
}
