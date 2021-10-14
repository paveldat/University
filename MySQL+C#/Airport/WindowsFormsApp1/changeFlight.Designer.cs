namespace WindowsFormsApp1
{
    partial class changeFlight
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
            this.flight_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.plane_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pilot_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.disp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.arr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flight_id
            // 
            this.flight_id.Location = new System.Drawing.Point(311, 26);
            this.flight_id.Name = "flight_id";
            this.flight_id.Size = new System.Drawing.Size(141, 20);
            this.flight_id.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Flight_id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Plane_id";
            // 
            // plane_id
            // 
            this.plane_id.Location = new System.Drawing.Point(311, 58);
            this.plane_id.Name = "plane_id";
            this.plane_id.Size = new System.Drawing.Size(141, 20);
            this.plane_id.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pilot_id";
            // 
            // pilot_id
            // 
            this.pilot_id.Location = new System.Drawing.Point(311, 91);
            this.pilot_id.Name = "pilot_id";
            this.pilot_id.Size = new System.Drawing.Size(141, 20);
            this.pilot_id.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Аэропорт вылета";
            // 
            // disp
            // 
            this.disp.Location = new System.Drawing.Point(311, 122);
            this.disp.Name = "disp";
            this.disp.Size = new System.Drawing.Size(141, 20);
            this.disp.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Аэропорт посадки";
            // 
            // arr
            // 
            this.arr.Location = new System.Drawing.Point(311, 153);
            this.arr.Name = "arr";
            this.arr.Size = new System.Drawing.Size(141, 20);
            this.arr.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(112, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дата вылета";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(311, 183);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(141, 20);
            this.date1.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Дата посадки";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(311, 217);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(141, 20);
            this.date2.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // changeFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 334);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.arr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.disp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pilot_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.plane_id);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flight_id);
            this.Controls.Add(this.button1);
            this.Name = "changeFlight";
            this.Text = "changeFlight";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox flight_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox plane_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pilot_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox disp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox arr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox date1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox date2;
        private System.Windows.Forms.Button button1;
    }
}