namespace WindowsFormsApp1
{
    partial class Pilot
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
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.companyplane = new System.Windows.Forms.RichTextBox();
            this.nameplane = new System.Windows.Forms.RichTextBox();
            this.idplane = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.RichTextBox();
            this.date1 = new System.Windows.Forms.RichTextBox();
            this.arr = new System.Windows.Forms.RichTextBox();
            this.disp = new System.Windows.Forms.RichTextBox();
            this.id = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(834, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Мои рейсы";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(83, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 39);
            this.button2.TabIndex = 7;
            this.button2.Text = "Вывести все самолеты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(788, 290);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "Вывести рейсы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // companyplane
            // 
            this.companyplane.Location = new System.Drawing.Point(205, 26);
            this.companyplane.Name = "companyplane";
            this.companyplane.Size = new System.Drawing.Size(110, 239);
            this.companyplane.TabIndex = 27;
            this.companyplane.Text = "";
            this.companyplane.TextChanged += new System.EventHandler(this.companyplane_TextChanged);
            // 
            // nameplane
            // 
            this.nameplane.Location = new System.Drawing.Point(79, 26);
            this.nameplane.Name = "nameplane";
            this.nameplane.Size = new System.Drawing.Size(110, 239);
            this.nameplane.TabIndex = 26;
            this.nameplane.Text = "";
            this.nameplane.TextChanged += new System.EventHandler(this.nameplane_TextChanged);
            // 
            // idplane
            // 
            this.idplane.Location = new System.Drawing.Point(29, 26);
            this.idplane.Name = "idplane";
            this.idplane.Size = new System.Drawing.Size(39, 239);
            this.idplane.TabIndex = 25;
            this.idplane.Text = "";
            this.idplane.TextChanged += new System.EventHandler(this.idplane_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Самолеты";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(1107, 26);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(185, 239);
            this.date2.TabIndex = 35;
            this.date2.Text = "";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(901, 26);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(185, 239);
            this.date1.TabIndex = 34;
            this.date1.Text = "";
            // 
            // arr
            // 
            this.arr.Location = new System.Drawing.Point(735, 26);
            this.arr.Name = "arr";
            this.arr.Size = new System.Drawing.Size(141, 239);
            this.arr.TabIndex = 32;
            this.arr.Text = "";
            // 
            // disp
            // 
            this.disp.Location = new System.Drawing.Point(562, 26);
            this.disp.Name = "disp";
            this.disp.Size = new System.Drawing.Size(152, 239);
            this.disp.TabIndex = 31;
            this.disp.Text = "";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(476, 26);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(59, 239);
            this.id.TabIndex = 30;
            this.id.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1323, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 366);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.arr);
            this.Controls.Add(this.disp);
            this.Controls.Add(this.id);
            this.Controls.Add(this.companyplane);
            this.Controls.Add(this.nameplane);
            this.Controls.Add(this.idplane);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Pilot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pilot";
            this.Load += new System.EventHandler(this.Pilot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox companyplane;
        private System.Windows.Forms.RichTextBox nameplane;
        private System.Windows.Forms.RichTextBox idplane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox date2;
        private System.Windows.Forms.RichTextBox date1;
        private System.Windows.Forms.RichTextBox arr;
        private System.Windows.Forms.RichTextBox disp;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.Button button1;
    }
}