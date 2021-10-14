namespace WindowsFormsApp1
{
    partial class Employee
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
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.addPlaneBtn = new System.Windows.Forms.Button();
            this.showPlanes = new System.Windows.Forms.Button();
            this.showFlights = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.RichTextBox();
            this.disp = new System.Windows.Forms.RichTextBox();
            this.arr = new System.Windows.Forms.RichTextBox();
            this.change = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.RichTextBox();
            this.date2 = new System.Windows.Forms.RichTextBox();
            this.idplane = new System.Windows.Forms.RichTextBox();
            this.nameplane = new System.Windows.Forms.RichTextBox();
            this.companyplane = new System.Windows.Forms.RichTextBox();
            this.idplane1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Самолеты";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Добавить новый рейс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addPlaneBtn
            // 
            this.addPlaneBtn.Location = new System.Drawing.Point(344, 116);
            this.addPlaneBtn.Name = "addPlaneBtn";
            this.addPlaneBtn.Size = new System.Drawing.Size(108, 42);
            this.addPlaneBtn.TabIndex = 6;
            this.addPlaneBtn.Text = "Добавить новый самолет";
            this.addPlaneBtn.UseVisualStyleBackColor = true;
            this.addPlaneBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // showPlanes
            // 
            this.showPlanes.Location = new System.Drawing.Point(12, 299);
            this.showPlanes.Name = "showPlanes";
            this.showPlanes.Size = new System.Drawing.Size(122, 36);
            this.showPlanes.TabIndex = 9;
            this.showPlanes.Text = "Показать все самолеты";
            this.showPlanes.UseVisualStyleBackColor = true;
            this.showPlanes.Click += new System.EventHandler(this.button4_Click);
            // 
            // showFlights
            // 
            this.showFlights.Location = new System.Drawing.Point(825, 299);
            this.showFlights.Name = "showFlights";
            this.showFlights.Size = new System.Drawing.Size(122, 36);
            this.showFlights.TabIndex = 10;
            this.showFlights.Text = "Показать все рейсы";
            this.showFlights.UseVisualStyleBackColor = true;
            this.showFlights.Click += new System.EventHandler(this.showFlights_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(344, 192);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 42);
            this.button4.TabIndex = 11;
            this.button4.Text = "Изменить данные самолета";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1276, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(514, 42);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(59, 239);
            this.id.TabIndex = 13;
            this.id.Text = "";
            this.id.TextChanged += new System.EventHandler(this.id_TextChanged);
            // 
            // disp
            // 
            this.disp.Location = new System.Drawing.Point(600, 42);
            this.disp.Name = "disp";
            this.disp.Size = new System.Drawing.Size(152, 239);
            this.disp.TabIndex = 15;
            this.disp.Text = "";
            this.disp.TextChanged += new System.EventHandler(this.disp_TextChanged);
            // 
            // arr
            // 
            this.arr.Location = new System.Drawing.Point(773, 42);
            this.arr.Name = "arr";
            this.arr.Size = new System.Drawing.Size(141, 239);
            this.arr.TabIndex = 16;
            this.arr.Text = "";
            this.arr.TextChanged += new System.EventHandler(this.arr_TextChanged);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(344, 265);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(108, 42);
            this.change.TabIndex = 17;
            this.change.TabStop = false;
            this.change.Text = "Изменить данные рейса";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(893, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Рейсы";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(939, 42);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(185, 239);
            this.date1.TabIndex = 19;
            this.date1.Text = "";
            this.date1.TextChanged += new System.EventHandler(this.date1_TextChanged);
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(1145, 42);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(185, 239);
            this.date2.TabIndex = 20;
            this.date2.Text = "";
            this.date2.TextChanged += new System.EventHandler(this.date2_TextChanged);
            // 
            // idplane
            // 
            this.idplane.Location = new System.Drawing.Point(12, 42);
            this.idplane.Name = "idplane";
            this.idplane.Size = new System.Drawing.Size(39, 239);
            this.idplane.TabIndex = 21;
            this.idplane.Text = "";
            // 
            // nameplane
            // 
            this.nameplane.Location = new System.Drawing.Point(62, 42);
            this.nameplane.Name = "nameplane";
            this.nameplane.Size = new System.Drawing.Size(110, 239);
            this.nameplane.TabIndex = 22;
            this.nameplane.Text = "";
            // 
            // companyplane
            // 
            this.companyplane.Location = new System.Drawing.Point(188, 42);
            this.companyplane.Name = "companyplane";
            this.companyplane.Size = new System.Drawing.Size(110, 239);
            this.companyplane.TabIndex = 23;
            this.companyplane.Text = "";
            // 
            // idplane1
            // 
            this.idplane1.Location = new System.Drawing.Point(198, 308);
            this.idplane1.Name = "idplane1";
            this.idplane1.Size = new System.Drawing.Size(100, 20);
            this.idplane1.TabIndex = 24;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 334);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 36);
            this.button3.TabIndex = 25;
            this.button3.Text = "Удалить самолет";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "IdPlane";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.idplane1);
            this.Controls.Add(this.companyplane);
            this.Controls.Add(this.nameplane);
            this.Controls.Add(this.idplane);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.change);
            this.Controls.Add(this.arr);
            this.Controls.Add(this.disp);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.showFlights);
            this.Controls.Add(this.showPlanes);
            this.Controls.Add(this.addPlaneBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button addPlaneBtn;
        private System.Windows.Forms.Button showPlanes;
        private System.Windows.Forms.Button showFlights;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.RichTextBox disp;
        private System.Windows.Forms.RichTextBox arr;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox date1;
        private System.Windows.Forms.RichTextBox date2;
        private System.Windows.Forms.RichTextBox idplane;
        private System.Windows.Forms.RichTextBox nameplane;
        private System.Windows.Forms.RichTextBox companyplane;
        private System.Windows.Forms.TextBox idplane1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
    }
}