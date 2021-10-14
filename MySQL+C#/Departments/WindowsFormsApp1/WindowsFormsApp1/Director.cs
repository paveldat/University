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
    public partial class Director : Form
    {
        public Director()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if(idworker.Text!="")
            {
                sqlActions.doSqlCommand("Delete From Users Where passport_number=" + idworker.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idst.Text = "Id:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            idtheme.Text = "Id темы:\n";
            theme.Text = "Тема:\n";
            var data = sqlActions.doSqlCommand("Select student_id, name, surname, Work.work_id, name_work From Students, Work Where Work.work_id=Students.work_id", 5);
            foreach(var d in data)
            {
                idst.Text += d[0] + "\n";
                namest.Text += d[1] + "\n";
                surnamest.Text += d[2] + "\n";
                idtheme.Text += d[3] + "\n";
                theme.Text += d[4] + "\n";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changeWork work = new changeWork();
            work.ShowDialog();
            idst.Text = "Id:\n";
            namest.Text = "Имя:\n";
            surnamest.Text = "Фамилия:\n";
            idtheme.Text = "Id темы:\n";
            theme.Text = "Тема:\n";
            var data = sqlActions.doSqlCommand("Select student_id, name, surname, Work.work_id, name_work From Students, Work Where Work.work_id=Students.work_id", 5);
            foreach (var d in data)
            {
                idst.Text += d[0] + "\n";
                namest.Text += d[1] + "\n";
                surnamest.Text += d[2] + "\n";
                idtheme.Text += d[3] + "\n";
                theme.Text += d[4] + "\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            namedepa.Text = "Отдел:\n";
            count.Text = "Кол-во:\n";
            var data = sqlActions.doSqlCommand("Select d.name, Count(w.work_id) as count From Department d, Work w, Students s Where w.work_id = s.work_id AND s.dep_id = d.dep_id Group By d.name", 2);
            foreach(var d in data)
            {
                namedepa.Text += d[0] + "\n";
                count.Text += d[1] + "\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            idLab.Text = "Id:\n";
            equpm.Text = "Equipment:\n";
            var dta = sqlActions.doSqlCommand("Select lab_id, name From LabEquipment, Equipment Where LabEquipment.eq_id=Equipment.eq_id", 2);
            foreach(var d in dta)
            {
                idLab.Text += d[0] + "\n";
                equpm.Text += d[1] + "\n";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            idLab2.Text = "Id:\n";
            nameSur.Text = "Name, Surname:\n";
            nameDepart.Text = "Name:\n";
            var data = sqlActions.doSqlCommand("Select * From Laboratories", 4);
            foreach (var d in data)
            {
                idLab2.Text += d[0] + "\n";
                nameSur.Text += d[1] + " " + d[2] + "\n";
                nameDepart.Text += d[3] + "\n";
            }
        }

        private void nameSur_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameDepart_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            idLab.Text = "Id:\n";
            equpm.Text = "Equipment:\n";
            var data = sqlActions.doSqlCommand("Select * From Equipment", 2);
            foreach(var d in data)
            {
                idLab.Text += d[0] + "\n";
                equpm.Text += d[1] + "\n";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (equipmentNew.Text == "")
                MessageBox.Show("Пустое поле!");
            else
            {
                bool isName = false;
                var dta = sqlActions.doSqlCommand("Select * From Equipment", 2);
                foreach (var d in dta)
                {
                    if (d[1] == equipmentNew.Text)
                    {
                        isName = true;
                        break;
                    }
                }
                if (isName)
                    MessageBox.Show("Есть такое оборудование!");
                else
                {
                    sqlActions.doSqlCommand("Insert Into Equipment(name) Values('" + equipmentNew.Text + "')", 1);
                    idLab.Text = "Id:\n";
                    equpm.Text = "Equipment:\n";
                    var data = sqlActions.doSqlCommand("Select * From Equipment", 2);
                    foreach (var d in data)
                    {
                        idLab.Text += d[0] + "\n";
                        equpm.Text += d[1] + "\n";
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Пустое поле!");
            else
            {
                int id = Int32.Parse(textBox1.Text);
                sqlActions.doSqlCommand("Delete From Equipment Where eq_id=" + id);
                idLab.Text = "Id:\n";
                equpm.Text = "Equipment:\n";
                var data = sqlActions.doSqlCommand("Select * From Equipment", 2);
                foreach (var d in data)
                {
                    idLab.Text += d[0] + "\n";
                    equpm.Text += d[1] + "\n";
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Пустое поле!");
            else
            {
                sqlActions.doSqlCommand("Delete From Labarotary Where lab_id=" + Int32.Parse(textBox2.Text));
                idLab2.Text = "Id:\n";
                nameSur.Text = "Name, Surname:\n";
                nameDepart.Text = "Name:\n";
                var data = sqlActions.doSqlCommand("Select * From Laboratories", 4);
                foreach (var d in data)
                {
                    idLab2.Text += d[0] + "\n";
                    nameSur.Text += d[1] + " " + d[2] + "\n";
                    nameDepart.Text += d[3] + "\n";
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            addLab lab = new addLab();
            lab.ShowDialog();
            idLab2.Text = "Id:\n";
            nameSur.Text = "Name, Surname:\n";
            nameDepart.Text = "Name:\n";
            var data = sqlActions.doSqlCommand("Select * From Laboratories", 4);
            foreach (var d in data)
            {
                idLab2.Text += d[0] + "\n";
                nameSur.Text += d[1] + " " + d[2] + "\n";
                nameDepart.Text += d[3] + "\n";
            }
        }
    }
}
