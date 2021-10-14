namespace WindowsFormsApp1
{
    partial class Administrator
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
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.pspDelete = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.maxPrice = new System.Windows.Forms.RichTextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.reis = new System.Windows.Forms.RichTextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.dateDisp = new System.Windows.Forms.TextBox();
            this.month = new System.Windows.Forms.RichTextBox();
            this.companyplane = new System.Windows.Forms.RichTextBox();
            this.nameplane = new System.Windows.Forms.RichTextBox();
            this.idplane = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.userId = new System.Windows.Forms.RichTextBox();
            this.role = new System.Windows.Forms.RichTextBox();
            this.nameUser = new System.Windows.Forms.RichTextBox();
            this.surnameUser = new System.Windows.Forms.RichTextBox();
            this.passUser = new System.Windows.Forms.RichTextBox();
            this.date2 = new System.Windows.Forms.RichTextBox();
            this.date1 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.arr = new System.Windows.Forms.RichTextBox();
            this.disp = new System.Windows.Forms.RichTextBox();
            this.id = new System.Windows.Forms.RichTextBox();
            this.showFlights = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить работника";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Работники";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(828, 285);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 45);
            this.button3.TabIndex = 8;
            this.button3.Text = "Вывести всех работников";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1521, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Выход";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(828, 350);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(146, 38);
            this.button6.TabIndex = 14;
            this.button6.Text = "Уволить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // pspDelete
            // 
            this.pspDelete.Location = new System.Drawing.Point(651, 368);
            this.pspDelete.Name = "pspDelete";
            this.pspDelete.Size = new System.Drawing.Size(146, 20);
            this.pspDelete.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Passport для увольнения";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1428, 53);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 34);
            this.button7.TabIndex = 17;
            this.button7.Text = "Месячный доход";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // maxPrice
            // 
            this.maxPrice.Location = new System.Drawing.Point(1217, 128);
            this.maxPrice.Name = "maxPrice";
            this.maxPrice.Size = new System.Drawing.Size(140, 87);
            this.maxPrice.TabIndex = 18;
            this.maxPrice.Text = "";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1217, 221);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(139, 34);
            this.button8.TabIndex = 19;
            this.button8.Text = "Самый дорогой билет";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // reis
            // 
            this.reis.Location = new System.Drawing.Point(1428, 128);
            this.reis.Name = "reis";
            this.reis.Size = new System.Drawing.Size(140, 87);
            this.reis.TabIndex = 20;
            this.reis.Text = "";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(1428, 221);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(139, 34);
            this.button9.TabIndex = 21;
            this.button9.Text = "Самый частый рейс";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1217, 317);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(139, 36);
            this.button10.TabIndex = 22;
            this.button10.Text = "Показать рейсы";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dateDisp
            // 
            this.dateDisp.Location = new System.Drawing.Point(1217, 285);
            this.dateDisp.Multiline = true;
            this.dateDisp.Name = "dateDisp";
            this.dateDisp.Size = new System.Drawing.Size(139, 26);
            this.dateDisp.TabIndex = 23;
            this.dateDisp.TabStop = false;
            this.dateDisp.Text = "Дату вылета";
            // 
            // month
            // 
            this.month.Location = new System.Drawing.Point(1216, 31);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(140, 87);
            this.month.TabIndex = 24;
            this.month.Text = "";
            // 
            // companyplane
            // 
            this.companyplane.Location = new System.Drawing.Point(189, 31);
            this.companyplane.Name = "companyplane";
            this.companyplane.Size = new System.Drawing.Size(110, 239);
            this.companyplane.TabIndex = 32;
            this.companyplane.Text = "";
            // 
            // nameplane
            // 
            this.nameplane.Location = new System.Drawing.Point(63, 31);
            this.nameplane.Name = "nameplane";
            this.nameplane.Size = new System.Drawing.Size(110, 239);
            this.nameplane.TabIndex = 31;
            this.nameplane.Text = "";
            // 
            // idplane
            // 
            this.idplane.Location = new System.Drawing.Point(13, 31);
            this.idplane.Name = "idplane";
            this.idplane.Size = new System.Drawing.Size(39, 239);
            this.idplane.TabIndex = 30;
            this.idplane.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Самолеты";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(67, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 39);
            this.button2.TabIndex = 28;
            this.button2.Text = "Вывести все самолеты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // userId
            // 
            this.userId.Location = new System.Drawing.Point(413, 31);
            this.userId.Name = "userId";
            this.userId.Size = new System.Drawing.Size(41, 239);
            this.userId.TabIndex = 33;
            this.userId.Text = "";
            // 
            // role
            // 
            this.role.Location = new System.Drawing.Point(472, 31);
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(110, 239);
            this.role.TabIndex = 34;
            this.role.Text = "";
            // 
            // nameUser
            // 
            this.nameUser.Location = new System.Drawing.Point(601, 31);
            this.nameUser.Name = "nameUser";
            this.nameUser.Size = new System.Drawing.Size(110, 239);
            this.nameUser.TabIndex = 35;
            this.nameUser.Text = "";
            // 
            // surnameUser
            // 
            this.surnameUser.Location = new System.Drawing.Point(731, 31);
            this.surnameUser.Name = "surnameUser";
            this.surnameUser.Size = new System.Drawing.Size(110, 239);
            this.surnameUser.TabIndex = 36;
            this.surnameUser.Text = "";
            // 
            // passUser
            // 
            this.passUser.Location = new System.Drawing.Point(864, 31);
            this.passUser.Name = "passUser";
            this.passUser.Size = new System.Drawing.Size(110, 239);
            this.passUser.TabIndex = 37;
            this.passUser.Text = "";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(995, 457);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(185, 239);
            this.date2.TabIndex = 45;
            this.date2.Text = "";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(789, 457);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(185, 239);
            this.date1.TabIndex = 44;
            this.date1.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(713, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Рейсы";
            // 
            // arr
            // 
            this.arr.Location = new System.Drawing.Point(623, 457);
            this.arr.Name = "arr";
            this.arr.Size = new System.Drawing.Size(141, 239);
            this.arr.TabIndex = 42;
            this.arr.Text = "";
            // 
            // disp
            // 
            this.disp.Location = new System.Drawing.Point(450, 457);
            this.disp.Name = "disp";
            this.disp.Size = new System.Drawing.Size(152, 239);
            this.disp.TabIndex = 41;
            this.disp.Text = "";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(364, 457);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(59, 239);
            this.id.TabIndex = 40;
            this.id.Text = "";
            // 
            // showFlights
            // 
            this.showFlights.Location = new System.Drawing.Point(675, 714);
            this.showFlights.Name = "showFlights";
            this.showFlights.Size = new System.Drawing.Size(122, 36);
            this.showFlights.TabIndex = 38;
            this.showFlights.Text = "Показать все рейсы";
            this.showFlights.UseVisualStyleBackColor = true;
            this.showFlights.Click += new System.EventHandler(this.showFlights_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(413, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 45);
            this.button4.TabIndex = 46;
            this.button4.Text = "Изменить данные работника";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1602, 797);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.arr);
            this.Controls.Add(this.disp);
            this.Controls.Add(this.id);
            this.Controls.Add(this.showFlights);
            this.Controls.Add(this.passUser);
            this.Controls.Add(this.surnameUser);
            this.Controls.Add(this.nameUser);
            this.Controls.Add(this.role);
            this.Controls.Add(this.userId);
            this.Controls.Add(this.companyplane);
            this.Controls.Add(this.nameplane);
            this.Controls.Add(this.idplane);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.month);
            this.Controls.Add(this.dateDisp);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.reis);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.maxPrice);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pspDelete);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Administrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox pspDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox maxPrice;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.RichTextBox reis;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox dateDisp;
        private System.Windows.Forms.RichTextBox month;
        private System.Windows.Forms.RichTextBox companyplane;
        private System.Windows.Forms.RichTextBox nameplane;
        private System.Windows.Forms.RichTextBox idplane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox userId;
        private System.Windows.Forms.RichTextBox role;
        private System.Windows.Forms.RichTextBox nameUser;
        private System.Windows.Forms.RichTextBox surnameUser;
        private System.Windows.Forms.RichTextBox passUser;
        private System.Windows.Forms.RichTextBox date2;
        private System.Windows.Forms.RichTextBox date1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox arr;
        private System.Windows.Forms.RichTextBox disp;
        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.Button showFlights;
        private System.Windows.Forms.Button button4;
    }
}