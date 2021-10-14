namespace WindowsFormsApp1
{
    partial class addStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.surname = new System.Windows.Forms.TextBox();
            this.passport = new System.Windows.Forms.TextBox();
            this.dep = new System.Windows.Forms.TextBox();
            this.numdep = new System.Windows.Forms.TextBox();
            this.rec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.del = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(237, 22);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(115, 20);
            this.name.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Паспорт";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Отдел";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Номер работы";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Дата выдачи";
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(237, 56);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(115, 20);
            this.surname.TabIndex = 8;
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(237, 92);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(115, 20);
            this.passport.TabIndex = 9;
            // 
            // dep
            // 
            this.dep.Location = new System.Drawing.Point(237, 126);
            this.dep.Name = "dep";
            this.dep.Size = new System.Drawing.Size(115, 20);
            this.dep.TabIndex = 10;
            // 
            // numdep
            // 
            this.numdep.Location = new System.Drawing.Point(237, 155);
            this.numdep.Name = "numdep";
            this.numdep.Size = new System.Drawing.Size(115, 20);
            this.numdep.TabIndex = 11;
            // 
            // rec
            // 
            this.rec.Location = new System.Drawing.Point(237, 190);
            this.rec.Name = "rec";
            this.rec.Size = new System.Drawing.Size(115, 20);
            this.rec.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дата сдачи";
            // 
            // del
            // 
            this.del.Location = new System.Drawing.Point(237, 222);
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(115, 20);
            this.del.TabIndex = 14;
            // 
            // addStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 365);
            this.Controls.Add(this.del);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rec);
            this.Controls.Add(this.numdep);
            this.Controls.Add(this.dep);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "addStudent";
            this.Text = "addStudent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox passport;
        private System.Windows.Forms.TextBox dep;
        private System.Windows.Forms.TextBox numdep;
        private System.Windows.Forms.TextBox rec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox del;
    }
}