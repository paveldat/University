namespace WindowsFormsApp1
{
    partial class addWorker
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
            this.role_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.surnameUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passportUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loginUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.passwordUser = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Role_id";
            // 
            // role_id
            // 
            this.role_id.Location = new System.Drawing.Point(200, 9);
            this.role_id.Name = "role_id";
            this.role_id.Size = new System.Drawing.Size(154, 20);
            this.role_id.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name";
            // 
            // nameUser
            // 
            this.nameUser.Location = new System.Drawing.Point(200, 38);
            this.nameUser.Name = "nameUser";
            this.nameUser.Size = new System.Drawing.Size(154, 20);
            this.nameUser.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Surname";
            // 
            // surnameUser
            // 
            this.surnameUser.Location = new System.Drawing.Point(200, 69);
            this.surnameUser.Name = "surnameUser";
            this.surnameUser.Size = new System.Drawing.Size(154, 20);
            this.surnameUser.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Passport";
            // 
            // passportUser
            // 
            this.passportUser.Location = new System.Drawing.Point(200, 101);
            this.passportUser.Name = "passportUser";
            this.passportUser.Size = new System.Drawing.Size(154, 20);
            this.passportUser.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Login";
            // 
            // loginUser
            // 
            this.loginUser.Location = new System.Drawing.Point(200, 131);
            this.loginUser.Name = "loginUser";
            this.loginUser.Size = new System.Drawing.Size(154, 20);
            this.loginUser.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // passwordUser
            // 
            this.passwordUser.Location = new System.Drawing.Point(200, 162);
            this.passwordUser.Name = "passwordUser";
            this.passwordUser.Size = new System.Drawing.Size(154, 20);
            this.passwordUser.TabIndex = 12;
            // 
            // addWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 281);
            this.Controls.Add(this.passwordUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginUser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passportUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.surnameUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.role_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "addWorker";
            this.Text = "addWorker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox role_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox surnameUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passportUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox loginUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passwordUser;
    }
}