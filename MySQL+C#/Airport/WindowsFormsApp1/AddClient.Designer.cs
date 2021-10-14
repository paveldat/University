namespace WindowsFormsApp1
{
    partial class AddClient
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flight_id = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.passport = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.seat = new System.Windows.Forms.TextBox();
            this.enable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "flight_id";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Фамилия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Паспорт";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Цена";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Место";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "enable";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Добавить пассажира";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flight_id
            // 
            this.flight_id.Location = new System.Drawing.Point(234, 24);
            this.flight_id.Name = "flight_id";
            this.flight_id.Size = new System.Drawing.Size(211, 20);
            this.flight_id.TabIndex = 8;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(234, 57);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(211, 20);
            this.name.TabIndex = 9;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(234, 88);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(211, 20);
            this.surname.TabIndex = 10;
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(234, 120);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(211, 20);
            this.passport.TabIndex = 11;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(234, 153);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(211, 20);
            this.price.TabIndex = 12;
            // 
            // seat
            // 
            this.seat.Location = new System.Drawing.Point(234, 187);
            this.seat.Name = "seat";
            this.seat.Size = new System.Drawing.Size(211, 20);
            this.seat.TabIndex = 13;
            // 
            // enable
            // 
            this.enable.Location = new System.Drawing.Point(234, 220);
            this.enable.Name = "enable";
            this.enable.Size = new System.Drawing.Size(211, 20);
            this.enable.TabIndex = 14;
            // 
            // AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 398);
            this.Controls.Add(this.enable);
            this.Controls.Add(this.seat);
            this.Controls.Add(this.price);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.name);
            this.Controls.Add(this.flight_id);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddClient";
            this.Text = "AddClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox flight_id;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox passport;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox seat;
        private System.Windows.Forms.TextBox enable;
    }
}