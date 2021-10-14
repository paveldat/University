namespace WindowsFormsApp1
{
    partial class Specialist
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
            this.id = new System.Windows.Forms.RichTextBox();
            this.name = new System.Windows.Forms.RichTextBox();
            this.telephone = new System.Windows.Forms.RichTextBox();
            this.adress = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.depid = new System.Windows.Forms.TextBox();
            this.idst = new System.Windows.Forms.RichTextBox();
            this.namest = new System.Windows.Forms.RichTextBox();
            this.surnamest = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.theme = new System.Windows.Forms.RichTextBox();
            this.stid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "Показать отделы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(12, 41);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(49, 329);
            this.id.TabIndex = 1;
            this.id.Text = "";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(77, 41);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(85, 329);
            this.name.TabIndex = 2;
            this.name.Text = "";
            // 
            // telephone
            // 
            this.telephone.Location = new System.Drawing.Point(174, 41);
            this.telephone.Name = "telephone";
            this.telephone.Size = new System.Drawing.Size(140, 329);
            this.telephone.TabIndex = 3;
            this.telephone.Text = "";
            // 
            // adress
            // 
            this.adress.Location = new System.Drawing.Point(329, 41);
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(149, 329);
            this.adress.TabIndex = 4;
            this.adress.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Отделы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(687, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Студенты";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(716, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 32);
            this.button2.TabIndex = 7;
            this.button2.Text = "Показать студентов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // depid
            // 
            this.depid.Location = new System.Drawing.Point(593, 395);
            this.depid.Name = "depid";
            this.depid.Size = new System.Drawing.Size(82, 20);
            this.depid.TabIndex = 8;
            // 
            // idst
            // 
            this.idst.Location = new System.Drawing.Point(593, 41);
            this.idst.Name = "idst";
            this.idst.Size = new System.Drawing.Size(62, 329);
            this.idst.TabIndex = 9;
            this.idst.Text = "";
            // 
            // namest
            // 
            this.namest.Location = new System.Drawing.Point(661, 41);
            this.namest.Name = "namest";
            this.namest.Size = new System.Drawing.Size(96, 329);
            this.namest.TabIndex = 10;
            this.namest.Text = "";
            // 
            // surnamest
            // 
            this.surnamest.Location = new System.Drawing.Point(763, 41);
            this.surnamest.Name = "surnamest";
            this.surnamest.Size = new System.Drawing.Size(96, 329);
            this.surnamest.TabIndex = 11;
            this.surnamest.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Id отдела";
            // 
            // theme
            // 
            this.theme.Location = new System.Drawing.Point(922, 41);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(226, 96);
            this.theme.TabIndex = 13;
            this.theme.Text = "";
            // 
            // stid
            // 
            this.stid.Location = new System.Drawing.Point(922, 165);
            this.stid.Name = "stid";
            this.stid.Size = new System.Drawing.Size(100, 20);
            this.stid.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(919, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Id Студента";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1046, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Показать тему";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Specialist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 515);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stid);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.surnamest);
            this.Controls.Add(this.namest);
            this.Controls.Add(this.idst);
            this.Controls.Add(this.depid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.name);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button1);
            this.Name = "Specialist";
            this.Text = "Specialist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.RichTextBox name;
        private System.Windows.Forms.RichTextBox telephone;
        private System.Windows.Forms.RichTextBox adress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox depid;
        private System.Windows.Forms.RichTextBox idst;
        private System.Windows.Forms.RichTextBox namest;
        private System.Windows.Forms.RichTextBox surnamest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox theme;
        private System.Windows.Forms.TextBox stid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
    }
}