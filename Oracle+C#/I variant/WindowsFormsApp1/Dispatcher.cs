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
    public partial class Dispatcher : Form
    {
        OleDbConnection sqlConnection;
        private string login;

        public Dispatcher(string log)
        {
            InitializeComponent();
            login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##SVETA;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            getRoutes();

            getJournal();

            getAutoPersonnel();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm:ss";

            string str = "SELECT NAME FROM ROUTES";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox2.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT NUM FROM AUTO";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT NUM FROM AUTO";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox6.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT NUM FROM AUTO";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox7.Items.Add(table.Rows[i].ItemArray[0].ToString());

            str = "SELECT NAME FROM ROUTES";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
                comboBox3.Items.Add(table.Rows[i].ItemArray[0].ToString());
        }

        #region Описание выводов

        private void getRoutes()
        {
            string str = "select * from all_routes";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void getJournal()
        {
            string str = "select time_out, time_in, a.num, r.name " +
                "from journal j " +
                "full join auto a " +
                "on a.id = j.auto_id " +
                "full join routes r " +
                "on r.id = j.route_id";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView2.Columns[0].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            dataGridView2.Columns[1].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
        }

        private void getAutoPersonnel()
        {
            string str = "select ap.first_name, ap.last_name, ap.pather_name, a.num, a.color, a.mark " +
                "from auto a " +
                "full join auto_personnel ap " +
                "on a.personnel_id = ap.id " +
                "join users u " +
                "on u.id = ap.user_id " +
                "where role = 'Персонал'";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView4.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView4.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        #endregion

        #region Маршруты

        private void button1_Click(object sender, EventArgs e) //добавить маршрут
        {
            if ("".Equals(textBox1.Text) || "".Equals(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (textBox1.Text.Equals(textBox2.Text))
            {
                MessageBox.Show("Начальная точка должна отличаться от конечной!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM routes WHERE name = " +
                    "concat(concat('" + textBox1.Text + "', ' -> '), '" + textBox2.Text + "')"; //уникальность маршрута
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if ("0".Equals(cnt))
                {
                    string st = "insert into routes (name) values(concat(concat('" + textBox1.Text + "', ' -> '), '" + textBox2.Text + "'))";
                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    getRoutes();
                }
                else
                    MessageBox.Show("Маршрут должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e) //изменить маршрут
        {
            if ("".Equals(textBox1.Text) || "".Equals(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (textBox1.Text.Equals(textBox2.Text))
            {
                MessageBox.Show("Начальная точка должна отличаться от конечной!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string res1 = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //route

                string into = "SELECT COUNT(*) FROM routes WHERE name = " +
                        "concat(concat('" + textBox1.Text + "', ' -> '), '" + textBox2.Text + "')"; //уникальность маршрута
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if ("0".Equals(cnt))
                {
                    string st = "update routes " +
                        "set name = concat(concat('" + textBox1.Text + "', ' -> '), '" + textBox2.Text + "') " +
                        "where name = '" + res1 + "'";
                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    getRoutes();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, маршрут должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) //удалить маршрут
        {
            string res = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //route
            string res1 = dataGridView1.CurrentRow.Cells[1].FormattedValue.ToString(); //count

            if ("0".Equals(res1))
            {
                string st = "delete from routes " +
                    "where name = '" + res + "'";
                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                getRoutes();
            }
            else
            {
                string st = "declare " +
                    "route_name varchar2(4000) := '" + res + "'; " +
                    "BEGIN " +
                    "DELETE FROM journal j " +
                    "WHERE j.route_id = (select id from routes where name = route_name); " +
                    "DELETE FROM routes r " +
                    "WHERE r.name = route_name; " +
                    "commit; " +
                    "end; ";
                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                getRoutes();
            }
        }

        private void button5_Click(object sender, EventArgs e) //обновить
        {
            getRoutes();
        }

        private void button4_Click(object sender, EventArgs e) //показать
        {
            string str = "SELECT name FROM routes " +
                "JOIN journal ON " +
                "routes.id = journal.route_id " +
                "WHERE journal.time_in > CURRENT_TIMESTAMP";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button6_Click(object sender, EventArgs e) //показать
        {
            try
            {
                string res = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //route

                string str = "SELECT routes.name, MIN(time_in - time_out) AS difference_in_minutes " +
                    "FROM JOURNAL " +
                    "JOIN AUTO ON journal.auto_id = auto.id " +
                    "JOIN ROUTES ON routes.id = journal.route_id " +
                    "WHERE routes.name = '" + res + "' " +
                    "GROUP BY routes.name";
                DataTable table = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView1.DataSource = table;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что-то!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button8_Click(object sender, EventArgs e) //изменить все
        {
            string res1 = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //route

            if ("".Equals(comboBox3.Text) || res1.Equals(comboBox3.Text))
            {
                MessageBox.Show("Пожалуйста, выберите новый маршрут отличный от старого!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "DECLARE " +
                    "old_id number; " +
                    "new_id number; " +
                    "BEGIN " +
                    "SELECT id INTO old_id FROM ROUTES WHERE name = '" + res1 + "'; " +
                    "SELECT id INTO new_id FROM ROUTES WHERE name = '" + comboBox3.Text + "'; " +
                    "UPDATE journal " +
                    "SET route_id = new_id " +
                    "WHERE route_id = old_id; " +
                    "DELETE FROM ROUTES " +
                    "WHERE id = old_id; " +
                    "END; ";
                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                getRoutes();

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if ("".Equals(comboBox6.Text) || "".Equals(comboBox7.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (comboBox6.Text.Equals(comboBox7.Text))
            {
                MessageBox.Show("Машины должны быть разными!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string str = "select t1.name " +
                    "from(SELECT name, round(MIN((CAST(time_in AS DATE) - CAST(time_out AS DATE)) * 24 * 60)) as time " +
                    "FROM routes " +
                    "INNER JOIN journal ON(routes.id = journal.route_id) " +
                    "INNER JOIN auto ON(journal.auto_id = auto.id) " +
                    "WHERE auto.num = '" + comboBox6.Text + "' AND time_in IS NOT NULL AND time_out IS NOT NULL GROUP BY name) t1" +
                    ", (SELECT name, round(MIN((CAST(time_in AS DATE) - CAST(time_out AS DATE)) * 24 * 60)) as time " +
                    "FROM routes " +
                    "INNER JOIN journal ON(routes.id = journal.route_id) " +
                    "INNER JOIN auto ON(journal.auto_id = auto.id) " +
                    "WHERE auto.num = '" + comboBox7.Text + "' AND time_in IS NOT NULL AND time_out IS NOT NULL GROUP BY name) t2 " +
                    "where t1.time < t2.time and t1.name = t2.name";
                DataTable table = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string res1 = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString(); //route

            string str = "SELECT (round((CAST(time_in AS DATE) - CAST(time_out AS DATE))*24*60)) as min" +
                ", num " +
                "FROM journal " +
                "INNER JOIN auto ON(journal.auto_id = auto.id) " +
                "WHERE time_in-time_out = (SELECT MIN(time_in - time_out) FROM journal " +
                "INNER JOIN auto ON(journal.auto_id = auto.id) " +
                "INNER JOIN routes ON(journal.route_id = routes.id) " +
                "WHERE name = routes.name and routes.name = '" + res1 + "')";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;
        }

        #endregion

        #region Журнал

        private void button7_Click(object sender, EventArgs e) //добавить в журнал
        {
            if ("".Equals(comboBox1.Text) || "".Equals(comboBox2.Text))
            {
                MessageBox.Show("Пожалуйста, выберите машину и маршрут!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT personnel_id " +
                "FROM auto " +
                "WHERE num = '" + comboBox1.Text + "'";
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string pers = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                into = "SELECT count(*) " +
                    "FROM auto, journal " +
                    "WHERE auto_id = auto.id and time_in > current_timestamp " +
                    "and personnel_id = " + pers + "";
                sqlConnection.Open();
                cmd = new OleDbCommand(into, sqlConnection);
                string time_1 = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                into = "SELECT COUNT(num) FROM AUTO " +
                    "JOIN JOURNAL ON journal.auto_id = auto.id " +
                    "JOIN ROUTES ON journal.route_id = routes.id " +
                    "WHERE time_in > current_timestamp " +
                    "and routes.name = '" + comboBox2.Text + "'";
                sqlConnection.Open();
                cmd = new OleDbCommand(into, sqlConnection);
                string count1 = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (dateTimePicker1.Value >= dateTimePicker2.Value || dateTimePicker1.Value <= DateTime.Now)
                {
                    MessageBox.Show("Пожалуйста, дата отъезда должна быть меньше даты приезда " +
                        "и дата отъезда не должна быть меньше текущей!", "Ошибка", MessageBoxButtons.OK);
                }
                else if (!"0".Equals(time_1))
                {
                    MessageBox.Show("Пожалуйста, выберите другую машину, так как водитель выбранной " +
                      "сейчас находится в пути!", "Ошибка", MessageBoxButtons.OK);
                }
                else if (Convert.ToInt32(count1) >= 2)
                {
                    MessageBox.Show("Пожалуйста, нельзя отправить водителя в рейс, в котором больше двух машин!", "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    string st = "insert into journal (time_out, time_in, auto_id, route_id) " +
                        "values(to_timestamp('" + dateTimePicker1.Text + "', 'DD-MM-YYYY HH24:MI:SS')" +
                        ", to_timestamp('" + dateTimePicker2.Text + "', 'DD-MM-YYYY HH24:MI:SS')" +
                        ", (select id from auto where num = '" + comboBox1.Text + "')" +
                        ", (select id from routes where name = '" + comboBox2.Text + "'))";
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                    DA.Fill(dataSet);

                    getJournal();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e) //изменить запись в журнале
        {
            string res1 = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString(); //тайм аут
            string res2 = dataGridView2.CurrentRow.Cells[1].FormattedValue.ToString(); //тайм ин
            string res3 = dataGridView2.CurrentRow.Cells[2].FormattedValue.ToString(); //номер
            string res4 = dataGridView2.CurrentRow.Cells[3].FormattedValue.ToString(); //путь

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
                            MessageBox.Show("Пожалуйста, новое время отправления!", "Ошибка", MessageBoxButtons.OK);
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
                    case "Маршрут":
                        if ("".Equals(comboBox2.Text))
                        {
                            MessageBox.Show("Пожалуйста, выберите новый маршрут!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update JOURNAL set route_id = (select id from routes where name = '" + comboBox2.Text + "')" +
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

        #endregion

        #region Авто

        private void button10_Click(object sender, EventArgs e)
        {
            string res1 = dataGridView4.CurrentRow.Cells[0].FormattedValue.ToString(); //route
            string res2 = dataGridView4.CurrentRow.Cells[1].FormattedValue.ToString(); //route
            string res3 = dataGridView4.CurrentRow.Cells[2].FormattedValue.ToString(); //route

            string into = "SELECT count(*) " +
                "FROM auto " +
                "WHERE num = '" + textBox3.Text + "'";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string pers = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("".Equals(textBox3.Text) || "".Equals(textBox4.Text) || "".Equals(textBox5.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (!"0".Equals(pers))
            {
                MessageBox.Show("Пожалуйста, номер машины должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "insert into auto (num, color, mark, personnel_id) " +
                    "values('" + textBox3.Text + "'" +
                    ", '" + textBox4.Text + "'" +
                    ", '" + textBox5.Text + "'" +
                    ", (select id from auto_personnel where first_name = '" + res1 + "' " +
                    "and last_name = '" + res2 + "' and (pather_name = '" + res3 + "' or pather_name is null)))";
                DataSet dataSet = new DataSet();
                OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                DA.Fill(dataSet);

                getAutoPersonnel();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string res1 = dataGridView4.CurrentRow.Cells[3].FormattedValue.ToString();

            if ("".Equals(comboBox5.Text))
            {
                MessageBox.Show("Пожалуйста, выберите, что хотите поменять!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                switch (comboBox5.Text)
                {
                    case "Номер":
                        if ("".Equals(textBox3.Text))
                        {
                            MessageBox.Show("Пожалуйста, введите новый номер!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string into = "SELECT count(*) " +
                                            "FROM auto " +
                                            "WHERE num = '" + textBox3.Text + "'";
                            sqlConnection.Open();
                            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                            string pers = cmd.ExecuteScalar().ToString();
                            sqlConnection.Close();

                            if (!"0".Equals(pers))
                            {
                                MessageBox.Show("Пожалуйста, номер машины должен быть уникальным!", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string st = "update auto set num = '" + textBox3.Text + "'" +
                                    "where num = '" + res1 + "'";
                                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                DataSet dataSet1 = new DataSet();
                                DA1.Fill(dataSet1);

                                getAutoPersonnel();
                            }
                        }
                        break;
                    case "Цвет":
                        if ("".Equals(textBox4.Text))
                        {
                            MessageBox.Show("Пожалуйста, введите новый цвет!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update auto set color = '" + textBox4.Text + "'" +
                            "where num = '" + res1 + "'";
                            OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            getAutoPersonnel();
                        }
                        break;
                    case "Марка":
                        if ("".Equals(textBox5.Text))
                        {
                            MessageBox.Show("Пожалуйста, введите новую марку!", "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            string st = "update auto set mark = '" + textBox5.Text + "'" +
                            "where num = '" + res1 + "'";
                            OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                            DataSet dataSet1 = new DataSet();
                            DA1.Fill(dataSet1);

                            getAutoPersonnel();
                        }
                        break;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string res = dataGridView4.CurrentRow.Cells[3].FormattedValue.ToString();

            string into = "SELECT count(*) " +
                "FROM auto, journal " +
                "WHERE auto_id = auto.id and time_in > current_timestamp " +
                "and num = '" + res + "'";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string pers = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("0".Equals(pers))
            {
                string st = "delete from auto " +
                    "where num = '" + res + "'";
                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                getAutoPersonnel();
            }
            else
            {
                MessageBox.Show("Нельзя удалить машину, которая сейчас в пути!", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string into = "SELECT COUNT(num) FROM auto WHERE num like '" + textBox11.Text + "%'";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string pers = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();
            textBox11.Text = pers;
        }

        #endregion

        #region Водители

        private void button19_Click(object sender, EventArgs e)
        {
            getAutoPersonnel();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string into = "SELECT count(*) " +
                "FROM auto_personnel " +
                "WHERE first_name = '" + textBox6.Text + "' " +
                "and last_name = '" + textBox7.Text + "' " +
                "and (pather_name = '" + textBox8.Text + "' or pather_name is null)";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string pers = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            into = "SELECT count(*) " +
                "FROM users " +
                "WHERE login = '" + textBox9.Text + "'";
            sqlConnection.Open();
            cmd = new OleDbCommand(into, sqlConnection);
            string us = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("".Equals(textBox6.Text) || "".Equals(textBox7.Text) 
                || "".Equals(textBox8.Text) || "".Equals(textBox9.Text) 
                || "".Equals(textBox10.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Ошибка", MessageBoxButtons.OK);
            }
            else if (!"0".Equals(pers) || !"0".Equals(us))
            {
                MessageBox.Show("Пожалуйста, ФИО и логин должны быть уникальными!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "begin " +
                    "insert into users(login, password, role) " +
                    "values('" + textBox9.Text + "', '" + Hash(textBox10.Text) + "', 'Персонал'); " +
                    "insert into auto_personnel(first_name, last_name, pather_name, user_id) " +
                    "values('" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "'" +
                    ", (select id from users order by id desc fetch FIRST 1 ROWS ONLY)); " +
                    "end; ";
                DataSet dataSet = new DataSet();
                OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                DA.Fill(dataSet);

                getAutoPersonnel();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string res = dataGridView4.CurrentRow.Cells[3].FormattedValue.ToString(); //route
            string res1 = dataGridView4.CurrentRow.Cells[0].FormattedValue.ToString(); //route
            string res2 = dataGridView4.CurrentRow.Cells[1].FormattedValue.ToString(); //route
            string res3 = dataGridView4.CurrentRow.Cells[2].FormattedValue.ToString(); //route

            string into = "SELECT count(*) " +
                "FROM auto, journal " +
                "WHERE auto_id = auto.id and time_in > current_timestamp " +
                "and num = '" + res + "'";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string pers = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            try 
            {
                if ("0".Equals(pers))
                {
                    string st = "begin " +
                        "DELETE FROM auto " +
                        "WHERE personnel_id = (SELECT id " +
                    "FROM auto_personnel " +
                    "WHERE first_name = '" + res1 + "' " +
                    "and last_name = '" + res2 + "' " +
                    "and (pather_name = '" + res3 + "' or pather_name is null)); " +
                        "DELETE FROM auto_personnel " +
                        "WHERE first_name = '" + res1 + "' " +
                    "and last_name = '" + res2 + "' " +
                    "and (pather_name = '" + res3 + "' or pather_name is null); " +
                        "end; ";
                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    getAutoPersonnel();
                }
                else
                {
                    MessageBox.Show("Нельзя удалить пользователя, который сейчас в пути!", "Ошибка", MessageBoxButtons.OK);
                }
            } 
            catch(OleDbException) 
            {
                MessageBox.Show("Нельзя удалить пользователя, у которого есть машины!", "Ошибка", MessageBoxButtons.OK);
            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if ("".Equals(textBox12.Text) || dateTimePicker3.Value.Date >= dateTimePicker4.Value.Date)
            {
                MessageBox.Show("Пожалуйста, вы не ввели сумму премии или дата начала не отличается от даты конца!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    string str = "select count(ap.id) as count_, concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) as fio" +
                        ", " + textBox12.Text + " * 0.5 " +
                        "from journal j, auto_personnel ap, auto a, routes r " +
                        "where j.auto_id = a.id and j.route_id = r.id and a.personnel_id = ap.id " +
                        "and j.time_in is not null and j.time_out > TO_DATE('" + dateTimePicker3.Text + "', 'DD.MM.YY') " +
                        "and j.time_in < TO_DATE('" + dateTimePicker4.Text + "', 'DD.MM.YY') " +
                        "group by concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) order by count_ desc " +
                        "OFFSET 0 ROWS " +
                        "FETCH NEXT 1 ROWS ONLY";
                    DataTable table = new DataTable();
                    OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                    DA.Fill(table);

                    str = "select count(ap.id) as count_, concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) as fio" +
                        ", " + textBox12.Text + " * 0.3 " +
                        "from journal j, auto_personnel ap, auto a, routes r " +
                        "where j.auto_id = a.id and j.route_id = r.id and a.personnel_id = ap.id " +
                        "and j.time_in is not null and j.time_out > TO_DATE('" + dateTimePicker3.Text + "', 'DD.MM.YY') " +
                        "and j.time_in < TO_DATE('" + dateTimePicker4.Text + "', 'DD.MM.YY') " +
                        "group by concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) order by count_ desc " +
                        "OFFSET 1 ROWS " +
                        "FETCH NEXT 1 ROWS ONLY";
                    DataTable table2 = new DataTable();
                    DA = new OleDbDataAdapter(str, sqlConnection);
                    DA.Fill(table2);

                    str = "select count(ap.id) as count_, concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) as fio" +
                        ", " + textBox12.Text + " * 0.2 " +
                        "from journal j, auto_personnel ap, auto a, routes r " +
                        "where j.auto_id = a.id and j.route_id = r.id and a.personnel_id = ap.id " +
                        "and j.time_in is not null and j.time_out > TO_DATE('" + dateTimePicker3.Text + "', 'DD.MM.YY') " +
                        "and j.time_in < TO_DATE('" + dateTimePicker4.Text + "', 'DD.MM.YY') " +
                        "group by concat(concat(concat(concat(ap.first_name, ' '), ap.last_name), ' '), ap.pather_name) order by count_ desc " +
                        "OFFSET 2 ROWS " +
                        "FETCH NEXT 1 ROWS ONLY";
                    DataTable table3 = new DataTable();
                    DA = new OleDbDataAdapter(str, sqlConnection);
                    DA.Fill(table3);

                    DataTable allDTs = table;
                    int rowCount = allDTs.Rows.Count - 1;
                    foreach (DataRow row in table2.Rows)
                    {
                        rowCount = rowCount + 1;
                        allDTs.Rows.Add();

                        int colCount = -1;
                        foreach (DataColumn col in table2.Columns)
                        {
                            colCount = colCount + 1;
                            if (colCount > allDTs.Columns.Count - 1) allDTs.Columns.Add(col.ColumnName);
                            allDTs.Rows[rowCount][colCount] = row[col];
                        }
                    }

                    rowCount = allDTs.Rows.Count - 1;
                    foreach (DataRow row in table3.Rows)
                    {
                        rowCount = rowCount + 1;
                        allDTs.Rows.Add();

                        int colCount = -1;
                        foreach (DataColumn col in table3.Columns)
                        {
                            colCount = colCount + 1;
                            if (colCount > allDTs.Columns.Count - 1) allDTs.Columns.Add(col.ColumnName);
                            allDTs.Rows[rowCount][colCount] = row[col];
                        }
                    }

                    dataGridView4.DataSource = allDTs;
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Пожалуйста, сумма премий должна быть числом!", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
    }
}
