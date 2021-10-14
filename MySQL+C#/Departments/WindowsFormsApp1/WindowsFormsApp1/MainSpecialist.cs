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
    public partial class MainSpecialist : Form
    {
        public MainSpecialist()
        {
            InitializeComponent();
        }

        private void MainSpecialist_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            idwr.Text = "Id:\n";
            namewr.Text = "Имя:\n";
            surnamewr.Text = "Фамилия:\n";
            passportwr.Text = "Паспорт:\n";
            rolewr.Text = "Должность:\n";
            var data = sqlActions.doSqlCommand("Select * From Workers", 5);
            foreach (var d in data)
            {
                idwr.Text += d[0] + "\n";
                namewr.Text += d[1] + "\n";
                surnamewr.Text += d[2] + "\n";
                passportwr.Text += d[3] + "\n";
                rolewr.Text += d[4] + "\n";
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            namedep.Text = "Название:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            passportst.Text = "Паспорт:\n";
            date_rec.Text = "Дата выдачи:\n";
            date_del.Text = "Дата сдачи:\n";
            var data = sqlActions.doSqlCommand("Select Department.name, Students.name, Students.surname, Students.passport_number, date_receive, date_delivery From Students, Department Where Department.dep_id=Students.dep_id", 6);
            foreach(var d in data)
            {
                namedep.Text += d[0] + "\n";
                namest.Text += d[1] + "\n";
                surnamest.Text += d[2] + "\n";
                passportst.Text += d[3] + "\n";
                date_rec.Text += d[4] + "\n";
                date_del.Text += d[5] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addStudent student = new addStudent();
            student.ShowDialog();
            namedep.Text = "Название:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            passportst.Text = "Паспорт:\n";
            date_rec.Text = "Дата выдачи:\n";
            date_del.Text = "Дата сдачи:\n";
            var data = sqlActions.doSqlCommand("Select Department.name, Students.name, Students.surname, Students.passport_number, date_receive, date_delivery From Students, Department Where Department.dep_id=Students.dep_id", 6);
            foreach (var d in data)
            {
                namedep.Text += d[0] + "\n";
                namest.Text += d[1] + "\n";
                surnamest.Text += d[2] + "\n";
                passportst.Text += d[3] + "\n";
                date_rec.Text += d[4] + "\n";
                date_del.Text += d[5] + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(delete.Text!="")
            {
                sqlActions.doSqlCommand("Delete From Students Where passport_number='" + delete.Text+"'");
            }
            namedep.Text = "Название:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            passportst.Text = "Паспорт:\n";
            date_rec.Text = "Дата выдачи:\n";
            date_del.Text = "Дата сдачи:\n";
            var data = sqlActions.doSqlCommand("Select Department.name, Students.name, Students.surname, Students.passport_number, date_receive, date_delivery From Students, Department Where Department.dep_id=Students.dep_id", 6);
            foreach (var d in data)
            {
                namedep.Text += d[0] + "\n";
                namest.Text += d[1] + "\n";
                surnamest.Text += d[2] + "\n";
                passportst.Text += d[3] + "\n";
                date_rec.Text += d[4] + "\n";
                date_del.Text += d[5] + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            idLab.Text = "Id:\n";
            nameSur.Text = "Name, Surname:\n";
            nameDepart.Text = "Name:\n";
            var data = sqlActions.doSqlCommand("Select * From Laboratories", 4);
            foreach(var d in data)
            {
                idLab.Text += d[0] + "\n";
                nameSur.Text += d[1] + " " + d[2] + "\n";
                nameDepart.Text += d[3] + "\n";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            idTrial.Text = "Id:\n";
            stages.Text = "Stage:\n";
            trials.Text = "Trials:\n";
            var data = sqlActions.doSqlCommand("Select t.trial_id, t.name, s.name From Trials t, Stages s Where t.stage=s.stage_id", 3);
            foreach(var d in data)
            {
                idTrial.Text += d[0] + "\n";
                trials.Text += d[1] + "\n";
                stages.Text += d[2] + "\n";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (newId.Text == "" || newStage.Text == "")
                MessageBox.Show("Пустое поле!");
            else
            {
                int id = Int32.Parse(newId.Text);
                int stage = Int32.Parse(newStage.Text);
                sqlActions.doSqlCommand("Update Trials Set stage=" + stage + " Where trial_id=" + id);
                idTrial.Text = "Id:\n";
                stages.Text = "Stage:\n";
                trials.Text = "Trials:\n";
                var data = sqlActions.doSqlCommand("Select t.trial_id, t.name, s.name From Trials t, Stages s Where t.stage=s.stage_id", 3);
                foreach (var d in data)
                {
                    idTrial.Text += d[0] + "\n";
                    trials.Text += d[1] + "\n";
                    stages.Text += d[2] + "\n";
                }
            }
        }
    }
}
