namespace WindowsFormsApp1
{
    partial class Booking
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
            this.id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.room = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Заселить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(189, 13);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(100, 20);
            this.id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "user_id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "room_id";
            // 
            // room
            // 
            this.room.Location = new System.Drawing.Point(189, 39);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(100, 20);
            this.room.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "date_arrival";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(189, 65);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(100, 20);
            this.date1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "date_departure";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(189, 91);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(100, 20);
            this.date2.TabIndex = 7;
            // 
            // Booking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 203);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.room);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.button1);
            this.Name = "Booking";
            this.Text = "Booking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox room;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox date1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox date2;
    }
}