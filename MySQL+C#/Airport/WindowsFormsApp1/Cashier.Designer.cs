namespace WindowsFormsApp1
{
    partial class Cashier
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
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.passportCl = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.RichTextBox();
            this.surname = new System.Windows.Forms.RichTextBox();
            this.name = new System.Windows.Forms.RichTextBox();
            this.passport = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Продать билет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Возврат билета";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Пассажиры всех рейсов";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 43);
            this.button4.TabIndex = 5;
            this.button4.Text = "Показать список пассажиров";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // passportCl
            // 
            this.passportCl.Location = new System.Drawing.Point(23, 137);
            this.passportCl.Name = "passportCl";
            this.passportCl.Size = new System.Drawing.Size(100, 20);
            this.passportCl.TabIndex = 7;
            this.passportCl.Text = "Write passport";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(489, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Выход";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(196, 47);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(47, 253);
            this.id.TabIndex = 9;
            this.id.Text = "";
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(261, 47);
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(98, 253);
            this.surname.TabIndex = 10;
            this.surname.Text = "";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(377, 47);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(98, 253);
            this.name.TabIndex = 11;
            this.name.Text = "";
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(489, 47);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(98, 253);
            this.passport.TabIndex = 12;
            this.passport.Text = "";
            // 
            // Cashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.name);
            this.Controls.Add(this.surname);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.passportCl);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Cashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cashier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox passportCl;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.RichTextBox surname;
        private System.Windows.Forms.RichTextBox name;
        private System.Windows.Forms.RichTextBox passport;
    }
}