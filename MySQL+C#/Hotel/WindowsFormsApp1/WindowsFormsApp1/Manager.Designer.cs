namespace WindowsFormsApp1
{
    partial class Manager
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
            this.idServ = new System.Windows.Forms.RichTextBox();
            this.costServ = new System.Windows.Forms.RichTextBox();
            this.nameServ = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.idCl = new System.Windows.Forms.RichTextBox();
            this.nameCl = new System.Windows.Forms.RichTextBox();
            this.surnameCl = new System.Windows.Forms.RichTextBox();
            this.passport = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.newId = new System.Windows.Forms.TextBox();
            this.newCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.delCl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idServ
            // 
            this.idServ.Location = new System.Drawing.Point(12, 12);
            this.idServ.Name = "idServ";
            this.idServ.Size = new System.Drawing.Size(68, 326);
            this.idServ.TabIndex = 14;
            this.idServ.Text = "";
            // 
            // costServ
            // 
            this.costServ.Location = new System.Drawing.Point(209, 12);
            this.costServ.Name = "costServ";
            this.costServ.Size = new System.Drawing.Size(68, 326);
            this.costServ.TabIndex = 13;
            this.costServ.Text = "";
            // 
            // nameServ
            // 
            this.nameServ.Location = new System.Drawing.Point(86, 12);
            this.nameServ.Name = "nameServ";
            this.nameServ.Size = new System.Drawing.Size(117, 326);
            this.nameServ.TabIndex = 12;
            this.nameServ.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(86, 344);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 11;
            this.button2.Text = "Показать все улуги";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // idCl
            // 
            this.idCl.Location = new System.Drawing.Point(360, 12);
            this.idCl.Name = "idCl";
            this.idCl.Size = new System.Drawing.Size(49, 326);
            this.idCl.TabIndex = 15;
            this.idCl.Text = "";
            // 
            // nameCl
            // 
            this.nameCl.Location = new System.Drawing.Point(415, 12);
            this.nameCl.Name = "nameCl";
            this.nameCl.Size = new System.Drawing.Size(83, 326);
            this.nameCl.TabIndex = 16;
            this.nameCl.Text = "";
            // 
            // surnameCl
            // 
            this.surnameCl.Location = new System.Drawing.Point(504, 12);
            this.surnameCl.Name = "surnameCl";
            this.surnameCl.Size = new System.Drawing.Size(81, 326);
            this.surnameCl.TabIndex = 17;
            this.surnameCl.Text = "";
            // 
            // passport
            // 
            this.passport.Location = new System.Drawing.Point(591, 12);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(84, 326);
            this.passport.TabIndex = 18;
            this.passport.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 37);
            this.button1.TabIndex = 19;
            this.button1.Text = "Информация о клиентах";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(147, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // newId
            // 
            this.newId.Location = new System.Drawing.Point(134, 405);
            this.newId.Name = "newId";
            this.newId.Size = new System.Drawing.Size(100, 20);
            this.newId.TabIndex = 21;
            // 
            // newCost
            // 
            this.newCost.Location = new System.Drawing.Point(134, 431);
            this.newCost.Name = "newCost";
            this.newCost.Size = new System.Drawing.Size(100, 20);
            this.newCost.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 431);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cost";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(360, 396);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 37);
            this.button4.TabIndex = 25;
            this.button4.Text = "Добавить нового клиента";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(576, 384);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 37);
            this.button5.TabIndex = 26;
            this.button5.Text = "Удалить клиента";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // delCl
            // 
            this.delCl.Location = new System.Drawing.Point(576, 358);
            this.delCl.Name = "delCl";
            this.delCl.Size = new System.Drawing.Size(100, 20);
            this.delCl.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Id";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(360, 443);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 37);
            this.button6.TabIndex = 29;
            this.button6.Text = "Заселить клиента";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 553);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delCl);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newCost);
            this.Controls.Add(this.newId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passport);
            this.Controls.Add(this.surnameCl);
            this.Controls.Add(this.nameCl);
            this.Controls.Add(this.idCl);
            this.Controls.Add(this.idServ);
            this.Controls.Add(this.costServ);
            this.Controls.Add(this.nameServ);
            this.Controls.Add(this.button2);
            this.Name = "Manager";
            this.Text = "Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox idServ;
        private System.Windows.Forms.RichTextBox costServ;
        private System.Windows.Forms.RichTextBox nameServ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox idCl;
        private System.Windows.Forms.RichTextBox nameCl;
        private System.Windows.Forms.RichTextBox surnameCl;
        private System.Windows.Forms.RichTextBox passport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox newId;
        private System.Windows.Forms.TextBox newCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox delCl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
    }
}