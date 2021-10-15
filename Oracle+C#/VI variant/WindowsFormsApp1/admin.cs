using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class admin : Form
    {
        OleDbConnection sqlConnection;
        private string login;

        public admin(string log)
        {
            InitializeComponent();
            login = log;
            string connection = @"Provider=OraOLEDB.Oracle;OLEDB.NET=true;PLSQLRSet=true;USER ID=C##6VAR;DATA SOURCE=localhost:1521/xe;PASSWORD=MyPass;";
            sqlConnection = new OleDbConnection(connection);

            getDiagnosis();

            //добавление в комбо бокс диагнозов
            string str = "SELECT NAME FROM diagnosis";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox3.Items.Add(table.Rows[i].ItemArray[0].ToString());
            }

            //добавление в комбо бокс палат
            str = "SELECT NAME FROM wards";
            table = new DataTable();
            DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                comboBox1.Items.Add(table.Rows[i].ItemArray[0].ToString());
                comboBox2.Items.Add(table.Rows[i].ItemArray[0].ToString());
                comboBox8.Items.Add(table.Rows[i].ItemArray[0].ToString());
            }

            viewTable();

            getWards();
        }

        #region Диагнозы

        private void getDiagnosis()
        {
            string str = "select d.name " +
                            "from diagnosis d";
            DataTable table = new DataTable();
            OleDbDataAdapter DA1 = new OleDbDataAdapter(str, sqlConnection);
            DA1.Fill(table);
            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e) //добавить диагноз
        {
            if ("".Equals(textBox1.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM diagnosis WHERE name = '" + textBox1.Text + "'"; //уникальность диагноза
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if (cnt == "0")
                {
                    string st = "insert into diagnosis (name) values ('" + textBox1.Text + "')";
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                    DA.Fill(dataSet);

                    getDiagnosis();
                }
                else
                {
                    MessageBox.Show("Название диагноза не должно повторяться", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //удалить диагноз
        {
            string res = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString();

            string str_bal = "delete from diagnosis where name = '" + res + "'";

            string into = "select count(*) " +
                    "from people " +
                    "where diagnosis_id = (select id from diagnosis where name = '" + res + "')"; //проверка на нефигурируемость
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if (!"0".Equals(cnt))
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить диагноз \"" + res + "\"?\n" +
                    "С таким диазнозом могут быть люди!", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str_bal, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    getDiagnosis();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить диагноз \"" + res + "\"?\n",
                    "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str_bal, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    getDiagnosis();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e) //удалить самый популярный диагноз
        {
            string str = "DECLARE " +
                            "DIAGNOS NUMBER := 0; " +
                            "            COUNT_D NUMBER := 0; " +
                            "            BEGIN " +
                            "            SELECT COUNT(DIAGNOSIS_ID) INTO COUNT_D " +
                            "FROM " +
                            "(SELECT COUNT(ID), " +
                            "DIAGNOSIS_ID " +
                            "FROM PEOPLE " +
                            "GROUP BY DIAGNOSIS_ID " +
                            "HAVING COUNT(ID) = " +
                            "(SELECT MAX(COUNT(ID)) " +
                            "FROM PEOPLE " +
                            "GROUP BY DIAGNOSIS_ID)); " +
                            "            WHILE(COUNT_D > 0) LOOP " +
                            "            SELECT DIAGNOSIS_ID INTO DIAGNOS " +
                            "FROM " +
                            "(SELECT COUNT(ID), " +
                            "DIAGNOSIS_ID " +
                            "FROM PEOPLE " +
                            "GROUP BY DIAGNOSIS_ID " +
                            "HAVING COUNT(ID) = " +
                            "(SELECT MAX(COUNT(ID)) " +
                            "FROM PEOPLE " +
                            "GROUP BY DIAGNOSIS_ID)) " +
                            "WHERE ROWNUM = 1; " +
                            "            DELETE FROM PEOPLE " +
                            "            WHERE DIAGNOSIS_ID = DIAGNOS; " +
                            "            DELETE FROM DIAGNOSIS " +
                            "            WHERE ID = DIAGNOS; " +
                            "        COUNT_D:= COUNT_D - 1; " +
                            "            END LOOP; " +
                            "            END; ";

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить самый популярный диагноз?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                getDiagnosis();
            }
        }

        private void button3_Click(object sender, EventArgs e) //вывести список диагнозов
        {
            getDiagnosis();
        }

        private void button4_Click(object sender, EventArgs e) //изменить диагноз
        {
            if ("".Equals(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, введите название новой статьи!", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string res1 = dataGridView1.CurrentRow.Cells[0].FormattedValue.ToString();

                string into = "SELECT COUNT(*) FROM diagnosis WHERE name = '" + textBox1.Text + "'"; //уникальность статьи
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                into = "select count(*) " +
                    "from people " +
                    "where diagnosis_id = (select id from diagnosis where name = '" + res1 + "')"; //проверка на нефигурируемость
                sqlConnection.Open();
                cmd = new OleDbCommand(into, sqlConnection);
                string cnt2 = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                if ("0".Equals(cnt))
                {
                    if ("0".Equals(cnt2))
                    {
                        string st = "update diagnosis set name = '" + textBox1.Text + "' where name = '" + res1 + "'";
                        DataSet dataSet = new DataSet();
                        OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                        DA.Fill(dataSet);

                        getDiagnosis();
                    }
                    else
                    {
                        MessageBox.Show("С диагнозом \"" + res1 + "\" есть люди, поэтому его нельзя изменить", "Ошибка", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Название диагноза не должно повторяться", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //удалить самый популярный диагноз*
        {
            string str = "DECLARE " +
            "DIAGNOS NUMBER := 0; " +
            "COUNT_D NUMBER := 0; " +
            "COUNT_P NUMBER := 0; " +
            "BEGIN " +
            "SAVEPOINT SP; " +
            "SELECT MAX(COUNT(ID)) INTO COUNT_P " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID; " +
            "SELECT COUNT(DIAGNOSIS_ID) INTO COUNT_D " +
            "FROM " +
            "(SELECT COUNT(ID), " +
            "DIAGNOSIS_ID " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID " +
            "HAVING COUNT(ID) = " +
            "(SELECT MAX(COUNT(ID)) " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID)); " +
            "WHILE (COUNT_D > 0) LOOP " +
            "SELECT DIAGNOSIS_ID INTO DIAGNOS " +
            "FROM " +
            "(SELECT COUNT(ID), " +
            "DIAGNOSIS_ID " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID " +
            "HAVING COUNT(ID) = " +
            "(SELECT MAX(COUNT(ID)) " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID)) " +
            "WHERE ROWNUM = 1; " +
            "DELETE FROM PEOPLE " +
            "WHERE DIAGNOSIS_ID = DIAGNOS; " +
            "DELETE FROM DIAGNOSIS " +
            "WHERE ID = DIAGNOS; " +
            "COUNT_D := COUNT_D - 1; " +
            "END LOOP; " +
            "IF (COUNT_P < 3)THEN " +
            "ROLLBACK TO SP; " +
            "END IF; " +
            "END; ";

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить самый популярный диагноз?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DataSet dataSet = new DataSet();
                DA.Fill(dataSet);

                getDiagnosis();
            }
        }

        private void button7_Click(object sender, EventArgs e) //хранимка
        {
            string st = "SELECT NAME " +
                        "FROM ALL_WARDS " +
                        "WHERE COUNT_PEOPLE < " +
                        "(SELECT AVG(COUNT_PEOPLE) AS AVG_PEOPLE " +
                        "FROM " +
                        "(SELECT DIAGNOSIS_ID, " +
                        "COUNT(ID) AS COUNT_PEOPLE " +
                        "FROM PEOPLE " +
                        "GROUP BY DIAGNOSIS_ID) " +
                        "WHERE DIAGNOSIS_ID = '" + textBox4.Text + "' " +
                        "OR DIAGNOSIS_ID = '" + textBox5.Text + "')";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
            DA.Fill(table);
            dataGridView1.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        #endregion

        #region Люди

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.Clear();
        }

        private void button10_Click(object sender, EventArgs e) //добавить
        {
            if ("".Equals(textBox2.Text) || "".Equals(comboBox3.Text) 
                || "".Equals(textBox3.Text) || "".Equals(comboBox1.Text) 
                || "Имя".Equals(textBox2.Text) || "Фамилия".Equals(textBox3.Text))
            {
                MessageBox.Show("Заполните все необходимые поля", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    if ("Отчество".Equals(textBox6.Text))
                    {
                        textBox6.Text = "";
                    }
                    string st = "INSERT INTO PEOPLE (first_name, last_name, patronymic, diagnosis_id, ward_id) " +
                            "VALUES ('" + textBox2.Text + "' " +
                            ", '" + textBox3.Text + "'" +
                            ", '" + textBox6.Text + "'" +
                            ", (SELECT ID FROM diagnosis WHERE NAME = '" + comboBox3.Text + "')" +
                            ", (SELECT ID FROM wards WHERE NAME = '" + comboBox1.Text + "'))";
                    DataSet dataSet = new DataSet();
                    OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                    DA.Fill(dataSet);

                    viewTable();
                } 
                catch(OleDbException)
                {
                    MessageBox.Show("Выбранная палата переполнена", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e) //Добавить столько больных, сколько необходимо для переполнения одной палаты
        {
            try
            {
                string st = "DECLARE " +
            "COUNT_PEOPLE NUMBER; " +
            "MAX_CAP NUMBER; " +
            "ID_DIAGNOSIS NUMBER; " +
            "AVAILABLE_WARD NUMBER; " +
            "RATE NUMBER; " +
            "TAKE_PLACE NUMBER; " +
            "MAXIMUM_PLACE NUMBER; " +
            "EMPTY_WARD NUMBER; " +
            "EMPTY_PLACE NUMBER; " +
            "ID_WARD NUMBER := '10'; " +
            "BEGIN " +
            "BEGIN " +
            "SELECT COUNT(ID) INTO COUNT_PEOPLE " +
            "FROM PEOPLE " +
            "WHERE WARD_ID = ID_WARD " +
            "GROUP BY WARD_ID; " +
            "EXCEPTION  " +
            "WHEN NO_DATA_FOUND THEN " +
            "    COUNT_PEOPLE := '0'; " +
            "END; " +
            "SELECT MAX_COUNT INTO MAX_CAP " +
            "FROM WARDS " +
            "WHERE ID = ID_WARD; " +
            "BEGIN " +
            "SELECT DIAGNOSIS_ID INTO ID_DIAGNOSIS " +
            "FROM PEOPLE " +
            "WHERE ROWNUM = 1 " +
            "AND WARD_ID = ID_WARD; " +
            "EXCEPTION  " +
            "WHEN NO_DATA_FOUND THEN " +
            "    ID_DIAGNOSIS := '8'; " +
            "END; " +
            "WHILE COUNT_PEOPLE < MAX_CAP  " +
            "LOOP " +
            "    INSERT INTO PEOPLE (FIRST_NAME, LAST_NAME, WARD_ID, DIAGNOSIS_ID) " +
            "    VALUES ('Тест', 'Тест', ID_WARD, ID_DIAGNOSIS); " +
            "    COUNT_PEOPLE := COUNT_PEOPLE + 1; " +
            "END LOOP; " +
            "PR3(ID_WARD, AVAILABLE_WARD, RATE); " +
            "BEGIN " +
            "SELECT COUNT_ID INTO TAKE_PLACE " +
            "FROM " +
            "    (SELECT WARD_ID, " +
            "    COUNT(ID) AS COUNT_ID " +
            "    FROM PEOPLE " +
            "    WHERE WARD_ID = AVAILABLE_WARD " +
            "    GROUP BY WARD_ID); " +
            "EXCEPTION  " +
            "WHEN NO_DATA_FOUND THEN " +
            "    TAKE_PLACE := '0'; " +
            "END; " +
            "SELECT MAX_COUNT INTO MAXIMUM_PLACE " +
            "FROM WARDS " +
            "WHERE ID = AVAILABLE_WARD; " +
            "EMPTY_PLACE := MAXIMUM_PLACE - TAKE_PLACE; " +
            "IF EMPTY_PLACE = '0' THEN " +
            "    SELECT ID INTO EMPTY_WARD " +
            "    FROM WARDS " +
            "    WHERE ID NOT IN " +
            "        (SELECT WARD_ID " +
            "        FROM PEOPLE) " +
            "    AND ROWNUM = '1';       " +
            "    AVAILABLE_WARD := EMPTY_WARD; " +
            "    TAKE_PLACE := '0';        " +
            "    SELECT MAX_COUNT INTO MAXIMUM_PLACE " +
            "    FROM WARDS " +
            "    WHERE ID = AVAILABLE_WARD; " +
            "END IF; " +
            "WHILE (TAKE_PLACE < MAXIMUM_PLACE) AND (COUNT_PEOPLE > 0) " +
            "LOOP " +
            "    UPDATE PEOPLE " +
            "    SET WARD_ID = AVAILABLE_WARD " +
            "    WHERE WARD_ID = ID_WARD " +
            "    AND ROWNUM = 1; " +
            "    TAKE_PLACE := TAKE_PLACE + 1;  " +
            "    COUNT_PEOPLE := COUNT_PEOPLE - 1; " +
            "END LOOP; " +
            "COMMIT; " +
            "END;";
                DataSet dataSet = new DataSet();
                OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                DA.Fill(dataSet);

                viewTable();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Мест нет", "Ошибка", MessageBoxButtons.OK);
            }
        }
        
        private void button9_Click(object sender, EventArgs e) //Добавить столько больных, сколько необходимо для переполнения одной палаты*
        {
            string st = "DECLARE  " +
            "COUNT_PEOPLE NUMBER;  " +
            "MAX_CAP NUMBER;  " +
            "ID_DIAGNOSIS NUMBER;  " +
            "AVAILABLE_WARD NUMBER;  " +
            "RATE NUMBER;  " +
            "TAKE_PLACE NUMBER;  " +
            "MAXIMUM_PLACE NUMBER;  " +
            "EMPTY_WARD NUMBER;  " +
            "EMPTY_PLACE NUMBER;  " +
            "ID_WARD NUMBER := '10';  " +
            "IS_ROLLBACK NUMBER := '0';  " +
            "BEGIN  " +
            "SAVEPOINT INSERT_PEOPLE;  " +
            "BEGIN  " +
            "SELECT COUNT(ID) INTO COUNT_PEOPLE  " +
            "FROM PEOPLE  " +
            "WHERE WARD_ID = ID_WARD  " +
            "GROUP BY WARD_ID;  " +
            "EXCEPTION   " +
            "WHEN NO_DATA_FOUND THEN  " +
            "    COUNT_PEOPLE := '0';  " +
            "END;  " +
            "SELECT MAX_COUNT INTO MAX_CAP  " +
            "FROM WARDS  " +
            "WHERE ID = ID_WARD;  " +
            "BEGIN  " +
            "SELECT DIAGNOSIS_ID INTO ID_DIAGNOSIS  " +
            "FROM PEOPLE  " +
            "WHERE ROWNUM = 1  " +
            "AND WARD_ID = ID_WARD;  " +
            "EXCEPTION   " +
            "WHEN NO_DATA_FOUND THEN  " +
            "    ID_DIAGNOSIS := '8';  " +
            "END;  " +
            "WHILE COUNT_PEOPLE < MAX_CAP   " +
            "LOOP  " +
            "    INSERT INTO PEOPLE (FIRST_NAME, LAST_NAME, WARD_ID, DIAGNOSIS_ID)  " +
            "    VALUES ('JOE', 'BYDEN', ID_WARD, ID_DIAGNOSIS);  " +
            "    COUNT_PEOPLE := COUNT_PEOPLE + 1;  " +
            "END LOOP;  " +
            "PR3(ID_WARD, AVAILABLE_WARD, RATE);  " +
            "BEGIN  " +
            "SELECT COUNT_ID INTO TAKE_PLACE  " +
            "FROM  " +
            "    (SELECT WARD_ID,  " +
            "    COUNT(ID) AS COUNT_ID  " +
            "    FROM PEOPLE  " +
            "    WHERE WARD_ID = AVAILABLE_WARD  " +
            "    GROUP BY WARD_ID);  " +
            "EXCEPTION   " +
            "WHEN NO_DATA_FOUND THEN  " +
            "    TAKE_PLACE := '0';  " +
            "END;  " +
            "SELECT MAX_COUNT INTO MAXIMUM_PLACE  " +
            "FROM WARDS  " +
            "WHERE ID = AVAILABLE_WARD;  " +
            "EMPTY_PLACE := MAXIMUM_PLACE - TAKE_PLACE;  " +
            "IF EMPTY_PLACE = '0' THEN  " +
            "    BEGIN  " +
            "    SELECT ID INTO EMPTY_WARD  " +
            "    FROM WARDS  " +
            "    WHERE ID NOT IN  " +
            "        (SELECT WARD_ID  " +
            "        FROM PEOPLE)  " +
            "    AND ROWNUM = '1';  " +
            "    EXCEPTION   " +
            "    WHEN NO_DATA_FOUND THEN  " +
            "        ROLLBACK TO INSERT_PEOPLE;  " +
            "        IS_ROLLBACK := '1';  " +
            "    END;      " +
            "    IF IS_ROLLBACK = '0' THEN  " +
            "        AVAILABLE_WARD := EMPTY_WARD;  " +
            "        TAKE_PLACE := '0';         " +
            "        SELECT MAX_COUNT INTO MAXIMUM_PLACE  " +
            "        FROM WARDS  " +
            "        WHERE ID = AVAILABLE_WARD;  " +
            "    END IF;  " +
            "END IF;  " +
            "IF IS_ROLLBACK = '0' THEN  " +
            "    WHILE (TAKE_PLACE < MAXIMUM_PLACE) AND (COUNT_PEOPLE > 0)  " +
            "    LOOP  " +
            "        UPDATE PEOPLE  " +
            "        SET WARD_ID = AVAILABLE_WARD  " +
            "        WHERE WARD_ID = ID_WARD  " +
            "        AND ROWNUM = 1;  " +
            "        TAKE_PLACE := TAKE_PLACE + 1;   " +
            "        COUNT_PEOPLE := COUNT_PEOPLE - 1;  " +
            "    END LOOP;  " +
            "END IF;  " +
            "END; ";
            DataSet dataSet = new DataSet();
            OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
            DA.Fill(dataSet);

            viewTable();
        }

        private void viewTable()
        {
            string str = "select p.first_name " +
            ", p.last_name " +
            ", p.patronymic " +
            ", d.name " +
            ", w.name " +
            "from people p " +
            "join diagnosis d " +
            "on p.diagnosis_id = d.id " +
            "join wards w " +
            "on p.ward_id = w.id";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button11_Click(object sender, EventArgs e) //удалить
        {
            string res1 = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
            string res2 = dataGridView2.CurrentRow.Cells[1].FormattedValue.ToString();
            string res3 = dataGridView2.CurrentRow.Cells[2].FormattedValue.ToString();
            string res4 = dataGridView2.CurrentRow.Cells[3].FormattedValue.ToString();
            string res5 = dataGridView2.CurrentRow.Cells[4].FormattedValue.ToString();

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить пациента?", "Внимание!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if ("".Equals(res3))
                {
                    string st = "delete from PEOPLE " +
                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                "and first_name = '" + res1 + "' " +
                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                "and last_name = '" + res2 + "'";
                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    viewTable();
                }
                else
                {
                    string st = "delete from PEOPLE " +
                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                "and first_name = '" + res1 + "' " +
                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                "and last_name = '" + res2 + "' " +
                                "and patronymic = '" + res3 + "'";
                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                    DataSet dataSet1 = new DataSet();
                    DA1.Fill(dataSet1);

                    viewTable();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e) //изменить
        {
            if ("".Equals(comboBox4.Text))
            {
                MessageBox.Show("Выберите, что хотите изменить", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    string res1 = dataGridView2.CurrentRow.Cells[0].FormattedValue.ToString();
                    string res2 = dataGridView2.CurrentRow.Cells[1].FormattedValue.ToString();
                    string res3 = dataGridView2.CurrentRow.Cells[2].FormattedValue.ToString();
                    string res4 = dataGridView2.CurrentRow.Cells[3].FormattedValue.ToString();
                    string res5 = dataGridView2.CurrentRow.Cells[4].FormattedValue.ToString();

                    switch (comboBox4.Text)
                    {
                        case "Диагноз":
                            if ("".Equals(comboBox3.Text))
                            {
                                MessageBox.Show("Выберите диагноз", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if ("".Equals(res3))
                                {
                                    string st = "update PEOPLE set DIAGNOSIS_ID = (SELECT ID FROM DIAGNOSIS WHERE NAME = '" + comboBox3.Text + "') " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                                else
                                {
                                    string st = "update PEOPLE set DIAGNOSIS_ID = (SELECT ID FROM DIAGNOSIS WHERE NAME = '" + comboBox3.Text + "') " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "' " +
                                                "and patronymic = '" + res3 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                            }
                            break;
                        case "Имя":
                            if ("".Equals(textBox2.Text))
                            {
                                MessageBox.Show("Введите имя", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if ("".Equals(res3))
                                {
                                    string st = "update PEOPLE set first_name = '" + textBox2.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                                else
                                {
                                    string st = "update PEOPLE set first_name = '" + textBox2.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "' " +
                                                "and patronymic = '" + res3 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                            }
                            break;
                        case "Фамилия":
                            if ("".Equals(textBox3.Text))
                            {
                                MessageBox.Show("Введите фамилию", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if ("".Equals(res3))
                                {
                                    string st = "update PEOPLE set last_name = '" + textBox3.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                                else
                                {
                                    string st = "update PEOPLE set last_name = '" + textBox3.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "' " +
                                                "and patronymic = '" + res3 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                            }
                            break;
                        case "Отчество":
                            if ("".Equals(textBox6.Text))
                            {
                                MessageBox.Show("Введите отчество", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if ("".Equals(res3))
                                {
                                    string st = "update PEOPLE set patronymic = '" + textBox6.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                                else
                                {
                                    string st = "update PEOPLE set patronymic = '" + textBox6.Text + "' " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "' " +
                                                "and patronymic = '" + res3 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                            }
                            break;
                        case "Палата":
                            if ("".Equals(comboBox1.Text))
                            {
                                MessageBox.Show("Выберите палату", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                if ("".Equals(res3))
                                {
                                    string st = "update PEOPLE set WARD_ID = (SELECT ID FROM WARDS WHERE NAME = '" + comboBox1.Text + "') " +
                                                 "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                 "and first_name = '" + res1 + "' " +
                                                 "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                 "and last_name = '" + res2 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                                else
                                {
                                    string st = "update PEOPLE set WARD_ID = (SELECT ID FROM WARDS WHERE NAME = '" + comboBox1.Text + "') " +
                                                "where DIAGNOSIS_ID = (select id from DIAGNOSIS where name = '" + res4 + "') " +
                                                "and first_name = '" + res1 + "' " +
                                                "and WARD_ID = (select id from WARDS where name = '" + res5 + "') " +
                                                "and last_name = '" + res2 + "' " +
                                                "and patronymic = '" + res3 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    viewTable();
                                }
                            }
                            break;
                    }
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Нельзя изменить пациента", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button13_Click_1(object sender, EventArgs e) //удалить с уникальной болезнью
        {
            string str = "DECLARE " +
            "COUNT_D NUMBER := 0; " +
            "BEGIN " +
            "SELECT COUNT(DIAGNOSIS_ID) INTO COUNT_D " +
            "FROM " +
            "(SELECT COUNT(ID) AS COUNT_ID, " +
            "DIAGNOSIS_ID " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID) " +
            "WHERE COUNT_ID = 1; " +
            "WHILE (COUNT_D > 0) LOOP " +
            "DELETE FROM PEOPLE " +
            "WHERE DIAGNOSIS_ID = " +
            "(SELECT DIAGNOSIS_ID " +
            "FROM " +
            "(SELECT COUNT(ID) AS COUNT_ID, " +
            "DIAGNOSIS_ID " +
            "FROM PEOPLE " +
            "GROUP BY DIAGNOSIS_ID) " +
            "WHERE COUNT_ID = 1 " +
            "AND ROWNUM = 1); " +
            "COUNT_D := COUNT_D - 1; " +
            "END LOOP; " +
            "END;";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView2.DataSource = table;

            viewTable();
        }

        private void button14_Click(object sender, EventArgs e) //перевести
        {
            string into = "select count(*) from people where ward_id = (select id from wards where name = '" + comboBox2.Text + "')";
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            into = "select max_count from wards where name = '" + comboBox8.Text + "'";
            sqlConnection.Open();
            cmd = new OleDbCommand(into, sqlConnection);
            string cnt2 = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if (int.Parse(cnt) > int.Parse(cnt2))
            {
                MessageBox.Show("Нельзя переместить в меньшую палату", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string st = "UPDATE PEOPLE SET WARD_ID = (select id from wards where name = '" + comboBox8.Text + "') " +
                "WHERE WARD_ID = (select id from wards where name = '" + comboBox2.Text + "')";
                OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                DataSet dataSet1 = new DataSet();
                DA1.Fill(dataSet1);

                viewTable();
            }
        }

        private string Hash(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            var result = new SHA256Managed().ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        #endregion

        #region Палаты

        private void getWards()
        {
            string str = "SELECT NAME, MAX_COUNT FROM WARDS ORDER BY MAX_COUNT DESC, NAME";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button18_Click(object sender, EventArgs e) //обновить
        {
            getWards();
        }

        private void button15_Click(object sender, EventArgs e) //добавить
        {
            if ("".Equals(textBox7.Text) || "".Equals(textBox8.Text))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                string into = "SELECT COUNT(*) FROM wards WHERE name = '" + textBox7.Text + "'"; //уникальность диагноза
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                try
                {
                    if (cnt == "0")
                    {
                        if (int.Parse(textBox8.Text) >= 1)
                        {
                            string st = "insert into wards (name, max_count) values ('" + textBox7.Text + "', '" + textBox8.Text + "')";
                            DataSet dataSet = new DataSet();
                            OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                            DA.Fill(dataSet);

                            getWards();
                        }
                        else
                        {
                            MessageBox.Show("Вместимость должна быть числом, превышающим 1", "Ошибка", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Название палаты не должно повторяться", "Ошибка", MessageBoxButtons.OK);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Вместимость должна быть числом, превышающим 1", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e) //удалить (работает ок, если есть человек с таким же диагнозом)
        {
            string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

            string str_bal = "delete from wards where name = '" + res + "'";

            string into = "select count(*) " +
                    "from people " +
                    "where ward_id = (select id from wards where name = '" + res + "')"; //проверка на нефигурируемость
            sqlConnection.Open();
            OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
            string cnt = cmd.ExecuteScalar().ToString();
            sqlConnection.Close();

            if (!"0".Equals(cnt))
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить палату \"" + res + "\"?\n" +
                    "В этой палате могут лежать люди!", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str_bal, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    getWards();
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Вы действительно хотите удалить палату \"" + res + "\"?\n",
                    "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OleDbDataAdapter DA = new OleDbDataAdapter(str_bal, sqlConnection);
                    DataSet dataSet = new DataSet();
                    DA.Fill(dataSet);

                    getWards();
                }
            }
        }

        private void button17_Click(object sender, EventArgs e) //число больных
        {
            string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

            string str = "SELECT '" + res + "' as NAME, COUNT(*) " +
                "FROM PEOPLE " +
                "WHERE WARD_ID = (SELECT ID FROM WARDS WHERE NAME = '" + res + "')";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button19_Click(object sender, EventArgs e) //полные данные
        {
            string str = "SELECT WARDS.NAME" +
                ", WARDS.MAX_COUNT" +
                ", COUNT(PEOPLE.ID) " +
                "FROM WARDS " +
                "LEFT JOIN PEOPLE " +
                "ON WARDS.ID = PEOPLE.WARD_ID " +
                "GROUP BY WARDS.ID, WARDS.NAME, WARDS.MAX_COUNT";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button20_Click(object sender, EventArgs e) //изменить
        {
            if ("".Equals(comboBox5.Text))
            {
                MessageBox.Show("Выберите, что хотите изменить", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    string res1 = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

                    switch (comboBox5.Text)
                    {
                        case "Название":
                            if ("".Equals(textBox7.Text))
                            {
                                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                string into = "SELECT COUNT(*) FROM wards WHERE name = '" + textBox7.Text + "'";
                                sqlConnection.Open();
                                OleDbCommand cmd = new OleDbCommand(into, sqlConnection);
                                string cnt = cmd.ExecuteScalar().ToString();
                                sqlConnection.Close();

                                if (cnt == "0")
                                {
                                    string st = "update WARDS set NAME = '" + textBox7.Text + "' " +
                                            "where NAME = '" + res1 + "'";
                                    OleDbDataAdapter DA1 = new OleDbDataAdapter(st, sqlConnection);
                                    DataSet dataSet1 = new DataSet();
                                    DA1.Fill(dataSet1);

                                    getWards();
                                }
                                else
                                {
                                    MessageBox.Show("Название палаты не должно повторяться", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                        case "Вместимость":
                            if ("".Equals(textBox8.Text))
                            {
                                MessageBox.Show("Введите вместимость", "Ошибка", MessageBoxButtons.OK);
                            }
                            else
                            {
                                try
                                {
                                    if (int.Parse(textBox8.Text) >= 1)
                                    {
                                        string st = "DECLARE " +
                                                    "NEW_CAPACITY NUMBER := " + textBox8.Text + "; " +
                                                    "TAKED_SPACE NUMBER; " +
                                                    "BEGIN " +
                                                    "SAVEPOINT UPDATE_MAX_COUNT; " +
                                                    "UPDATE WARDS " +
                                                    "SET MAX_COUNT = NEW_CAPACITY " +
                                                    "WHERE NAME = '" + res1 + "'; " +
                                                    "SELECT COUNT_ID INTO TAKED_SPACE " +
                                                    "FROM " +
                                                    "(SELECT COUNT (ID) AS COUNT_ID " +
                                                    "FROM PEOPLE " +
                                                    "WHERE WARD_ID = (SELECT ID FROM WARDS WHERE NAME = '" + res1 + "')); " +
                                                    "IF TAKED_SPACE > NEW_CAPACITY THEN " +
                                                    "ROLLBACK TO UPDATE_MAX_COUNT; " +
                                                    "END IF; " +
                                                    "END;";
                                        DataSet dataSet = new DataSet();
                                        OleDbDataAdapter DA = new OleDbDataAdapter(st, sqlConnection);
                                        DA.Fill(dataSet);

                                        string str = "SELECT WARDS.NAME" +
                                                        ", WARDS.MAX_COUNT" +
                                                        ", COUNT(PEOPLE.ID) " +
                                                        "FROM WARDS " +
                                                        "LEFT JOIN PEOPLE " +
                                                        "ON WARDS.ID = PEOPLE.WARD_ID " +
                                                        "GROUP BY WARDS.ID, WARDS.NAME, WARDS.MAX_COUNT";
                                        DataTable table = new DataTable();
                                        DA = new OleDbDataAdapter(str, sqlConnection);
                                        DA.Fill(table);
                                        dataGridView3.DataSource = table;

                                        foreach (DataGridViewColumn column in dataGridView3.Columns)
                                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Вместимость должна быть числом, превышающим 1", "Ошибка", MessageBoxButtons.OK);
                                    }
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("Вместимость должна быть числом, превышающим 1", "Ошибка", MessageBoxButtons.OK);
                                }
                            }
                            break;
                    }
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Нельзя изменить операцию, которая учтена в балансе", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        private void button21_Click(object sender, EventArgs e) //представление
        {
            string str = "SELECT * FROM ALL_WARDS";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button22_Click(object sender, EventArgs e) //полные данные*
        {
            string str = "SELECT WARDS.NAME" +
                ", WARDS.MAX_COUNT" +
                ", COUNT(PEOPLE.ID) " +
                "FROM WARDS " +
                "INNER JOIN PEOPLE " +
                "ON WARDS.ID = PEOPLE.WARD_ID " +
                "GROUP BY WARDS.ID, WARDS.NAME, WARDS.MAX_COUNT";
            DataTable table = new DataTable();
            OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
            DA.Fill(table);
            dataGridView3.DataSource = table;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button23_Click(object sender, EventArgs e) //хранимка 3
        {
            string res = dataGridView3.CurrentRow.Cells[0].FormattedValue.ToString();

            string temp_ = "SELECT COUNT(*) FROM PEOPLE " +
                "WHERE WARD_ID = (SELECT ID FROM WARDS WHERE NAME = '" + res + "')";
            sqlConnection.Open();
            OleDbCommand cmd_ = new OleDbCommand(temp_, sqlConnection);
            string er = cmd_.ExecuteScalar().ToString();
            sqlConnection.Close();

            if ("0".Equals(er))
            {
                MessageBox.Show("Выберите палату из тех, в которых есть пациенты", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                double rate = double.MaxValue;
                double ocup = double.MaxValue;
                double tmp;
                string available = "";

                string temp = "SELECT COUNT(WARDS.ID) " +
                "FROM WARDS " +
                "JOIN " +
                "    (SELECT WARD_ID,  " +
                "    COUNT(ID) AS COUNT_PEOPLE " +
                "    FROM PEOPLE " +
                "    GROUP BY WARD_ID) " +
                "ON WARDS.ID = WARD_ID " +
                "WHERE WARDS.ID IN " +
                "    (SELECT DISTINCT WARDS.ID " +
                "    FROM WARDS " +
                "    JOIN PEOPLE " +
                "    ON WARDS.ID = PEOPLE.WARD_ID " +
                "    JOIN DIAGNOSIS " +
                "    ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                "    WHERE DIAGNOSIS.ID =  " +
                "        (SELECT DISTINCT DIAGNOSIS.ID  " +
                "        FROM WARDS " +
                "        JOIN PEOPLE " +
                "        ON WARDS.ID = PEOPLE.WARD_ID " +
                "        JOIN DIAGNOSIS " +
                "        ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                "        WHERE WARDS.NAME = '" + res + "'))";
                sqlConnection.Open();
                OleDbCommand cmd = new OleDbCommand(temp, sqlConnection);
                string cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                for (int i = 0; i < int.Parse(cnt); i++)
                {
                    temp = "SELECT COUNT_PEOPLE " +
                    "FROM WARDS " +
                    "JOIN " +
                    "    (SELECT WARD_ID,  " +
                    "    COUNT(ID) AS COUNT_PEOPLE " +
                    "    FROM PEOPLE " +
                    "    GROUP BY WARD_ID) " +
                    "ON WARDS.ID = WARD_ID " +
                    "WHERE WARDS.ID IN " +
                    "    (SELECT DISTINCT WARDS.ID " +
                    "    FROM WARDS " +
                    "    JOIN PEOPLE " +
                    "    ON WARDS.ID = PEOPLE.WARD_ID " +
                    "    JOIN DIAGNOSIS " +
                    "    ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "    WHERE DIAGNOSIS.ID =  " +
                    "        (SELECT DISTINCT DIAGNOSIS.ID  " +
                    "        FROM WARDS " +
                    "        JOIN PEOPLE " +
                    "        ON WARDS.ID = PEOPLE.WARD_ID " +
                    "        JOIN DIAGNOSIS " +
                    "        ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "        WHERE WARDS.NAME = '" + res + "')) " +
                    "OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
                    sqlConnection.Open();
                    cmd = new OleDbCommand(temp, sqlConnection);
                    string count_people = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    temp = "SELECT WARDS.MAX_COUNT " +
                    "FROM WARDS " +
                    "JOIN " +
                    "    (SELECT WARD_ID,  " +
                    "    COUNT(ID) AS COUNT_PEOPLE " +
                    "    FROM PEOPLE " +
                    "    GROUP BY WARD_ID) " +
                    "ON WARDS.ID = WARD_ID " +
                    "WHERE WARDS.ID IN " +
                    "    (SELECT DISTINCT WARDS.ID " +
                    "    FROM WARDS " +
                    "    JOIN PEOPLE " +
                    "    ON WARDS.ID = PEOPLE.WARD_ID " +
                    "    JOIN DIAGNOSIS " +
                    "    ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "    WHERE DIAGNOSIS.ID =  " +
                    "        (SELECT DISTINCT DIAGNOSIS.ID  " +
                    "        FROM WARDS " +
                    "        JOIN PEOPLE " +
                    "        ON WARDS.ID = PEOPLE.WARD_ID " +
                    "        JOIN DIAGNOSIS " +
                    "        ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "        WHERE WARDS.NAME = '" + res + "')) " +
                    "OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
                    sqlConnection.Open();
                    cmd = new OleDbCommand(temp, sqlConnection);
                    string max_count = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    temp = "SELECT WARDS.ID " +
                    "FROM WARDS " +
                    "JOIN " +
                    "    (SELECT WARD_ID,  " +
                    "    COUNT(ID) AS COUNT_PEOPLE " +
                    "    FROM PEOPLE " +
                    "    GROUP BY WARD_ID) " +
                    "ON WARDS.ID = WARD_ID " +
                    "WHERE WARDS.ID IN " +
                    "    (SELECT DISTINCT WARDS.ID " +
                    "    FROM WARDS " +
                    "    JOIN PEOPLE " +
                    "    ON WARDS.ID = PEOPLE.WARD_ID " +
                    "    JOIN DIAGNOSIS " +
                    "    ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "    WHERE DIAGNOSIS.ID =  " +
                    "        (SELECT DISTINCT DIAGNOSIS.ID  " +
                    "        FROM WARDS " +
                    "        JOIN PEOPLE " +
                    "        ON WARDS.ID = PEOPLE.WARD_ID " +
                    "        JOIN DIAGNOSIS " +
                    "        ON PEOPLE.DIAGNOSIS_ID = DIAGNOSIS.ID " +
                    "        WHERE WARDS.NAME = '" + res + "'))" +
                    "OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
                    sqlConnection.Open();
                    cmd = new OleDbCommand(temp, sqlConnection);
                    string ids = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    tmp = double.Parse(count_people) / double.Parse(max_count);
                    if (tmp < rate)
                    {
                        rate = tmp;
                        available = ids;
                    }
                }

                temp = "SELECT count(WARDS.ID) " +
                "FROM WARDS " +
                "JOIN " +
                "    (SELECT WARD_ID, " +
                "    COUNT(ID) AS COUNT_PEOPLE " +
                "    FROM PEOPLE " +
                "    GROUP BY WARD_ID) " +
                "ON WARDS.ID = " + available + "";
                sqlConnection.Open();
                cmd = new OleDbCommand(temp, sqlConnection);
                cnt = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                for (int i = 0; i < int.Parse(cnt); i++)
                {
                    temp = "SELECT WARDS.MAX_COUNT " +
                            "FROM WARDS " +
                            "JOIN " +
                            "    (SELECT WARD_ID, " +
                            "    COUNT(ID) AS COUNT_PEOPLE " +
                            "    FROM PEOPLE " +
                            "    GROUP BY WARD_ID) " +
                            "ON WARDS.ID = " + available + " " +
                            "OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
                    sqlConnection.Open();
                    cmd = new OleDbCommand(temp, sqlConnection);
                    string max_count = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    temp = "SELECT COUNT_PEOPLE " +
                            "FROM WARDS " +
                            "JOIN " +
                            "    (SELECT WARD_ID, " +
                            "    COUNT(ID) AS COUNT_PEOPLE " +
                            "    FROM PEOPLE " +
                            "    GROUP BY WARD_ID) " +
                            "ON WARDS.ID = " + available + " " +
                            "OFFSET " + i + " ROWS FETCH NEXT 1 ROWS ONLY";
                    sqlConnection.Open();
                    cmd = new OleDbCommand(temp, sqlConnection);
                    string count_people = cmd.ExecuteScalar().ToString();
                    sqlConnection.Close();

                    tmp = double.Parse(count_people) / double.Parse(max_count);
                    if (tmp < ocup)
                    {
                        ocup = tmp;
                    }
                }

                temp = "SELECT NAME " +
                            "FROM WARDS " +
                            "WHERE WARDS.ID = " + available + "";
                sqlConnection.Open();
                cmd = new OleDbCommand(temp, sqlConnection);
                label4.Text = cmd.ExecuteScalar().ToString();
                sqlConnection.Close();

                label5.Text = ocup.ToString("0.0000");

                var exePath = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(exePath, "..\\..\\procedure.txt");

                using (StreamWriter txt = new StreamWriter(path))
                {
                    txt.WriteLine("Название палаты: {0}\n" +
                        "Самое низкое отношение занятого места к свободному среди палат других диагнозов: {1}", 
                        label4.Text, 
                        ocup.ToString("0.0000000000"));
                }
            }
        }

        private void button24_Click(object sender, EventArgs e) //курсор
        {
            if (!"".Equals(textBox9.Text) || !"".Equals(textBox10.Text))
            {
                string str = "SELECT DIAGNOSIS.NAME, " +
            "SUM_COUNT_PEOPLE / SUM_MAX_COUNT as AVG " +
            "FROM DIAGNOSIS, " +
            "    (SELECT ID AS ID_COUNT_PEOPLE, " +
            "    SUM(COUNT_PEOPLE) AS SUM_COUNT_PEOPLE " +
            "    FROM  " +
            "        (SELECT DIAGNOSIS.ID,         " +
            "        ALL_WARDS.COUNT_PEOPLE, " +
            "        ALL_WARDS.MAX_COUNT " +
            "        FROM ALL_WARDS, DIAGNOSIS " +
            "        WHERE ALL_WARDS.NAME_DIAGNOSIS = DIAGNOSIS.NAME) " +
            "    WHERE COUNT_PEOPLE >= " + textBox9.Text + " * MAX_COUNT " +
            "    AND COUNT_PEOPLE <= " + textBox10.Text + " * MAX_COUNT " +
            "    GROUP BY ID), " +
            "    (SELECT ID AS ID_MAX_COUNT, " +
            "    SUM(MAX_COUNT) AS SUM_MAX_COUNT " +
            "    FROM  " +
            "        (SELECT DIAGNOSIS.ID,         " +
            "        ALL_WARDS.COUNT_PEOPLE, " +
            "        ALL_WARDS.MAX_COUNT " +
            "        FROM ALL_WARDS, DIAGNOSIS " +
            "        WHERE ALL_WARDS.NAME_DIAGNOSIS = DIAGNOSIS.NAME) " +
            "    WHERE COUNT_PEOPLE >= " + textBox9.Text + " * MAX_COUNT " +
            "    AND COUNT_PEOPLE <= " + textBox10.Text + " * MAX_COUNT " +
            "    GROUP BY ID) " +
            "WHERE ID_COUNT_PEOPLE = ID_MAX_COUNT " +
            "AND ID_COUNT_PEOPLE = DIAGNOSIS.ID";
                DataTable table = new DataTable();
                OleDbDataAdapter DA = new OleDbDataAdapter(str, sqlConnection);
                DA.Fill(table);
                dataGridView3.DataSource = table;

                var exePath = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(exePath, "..\\..\\cursor.txt");

                using (StreamWriter txt = new StreamWriter(path))
                {
                    DataRow[] rows = table.Select();

                    for (int i = 0; i < rows.Length; i++)
                    {
                        txt.WriteLine("Диагноз: {0}\nСредняя заполненность по всем палатам: {1}\n\n", rows[i]["NAME"], rows[i]["AVG"]);
                    }
                }

                foreach (DataGridViewColumn column in dataGridView3.Columns)
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            else
            {
                MessageBox.Show("Введите от 0 до 1", "Ошибка", MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}
