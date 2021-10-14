namespace WindowsFormsApp1
{
    partial class Cleaning
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
            this.id = new System.Windows.Forms.RichTextBox();
            this.floor = new System.Windows.Forms.RichTextBox();
            this.room = new System.Windows.Forms.RichTextBox();
            this.status = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.idClean = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(12, 12);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(48, 310);
            this.id.TabIndex = 0;
            this.id.Text = "";
            // 
            // floor
            // 
            this.floor.Location = new System.Drawing.Point(66, 12);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(61, 310);
            this.floor.TabIndex = 1;
            this.floor.Text = "";
            // 
            // room
            // 
            this.room.Location = new System.Drawing.Point(133, 12);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(61, 310);
            this.room.TabIndex = 2;
            this.room.Text = "";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(200, 12);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(124, 310);
            this.status.TabIndex = 3;
            this.status.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(86, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Показать все невыполненные заказы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idClean
            // 
            this.idClean.Location = new System.Drawing.Point(501, 30);
            this.idClean.Name = "idClean";
            this.idClean.Size = new System.Drawing.Size(105, 28);
            this.idClean.TabIndex = 5;
            this.idClean.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(488, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 49);
            this.button2.TabIndex = 6;
            this.button2.Text = "Уборка выполнена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Cleaning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 412);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.idClean);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.room);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.id);
            this.Name = "Cleaning";
            this.Text = "Cleaning";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox id;
        private System.Windows.Forms.RichTextBox floor;
        private System.Windows.Forms.RichTextBox room;
        private System.Windows.Forms.RichTextBox status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox idClean;
        private System.Windows.Forms.Button button2;
    }
}