namespace WindowsFormsApp1
{
    partial class AddFlight
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
            this.plane_id = new System.Windows.Forms.Label();
            this.idPlane = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idPilot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dispAiroport = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.arvAiroport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.departDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.arvDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить рейс";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plane_id
            // 
            this.plane_id.AutoSize = true;
            this.plane_id.Location = new System.Drawing.Point(271, 15);
            this.plane_id.Name = "plane_id";
            this.plane_id.Size = new System.Drawing.Size(48, 13);
            this.plane_id.TabIndex = 1;
            this.plane_id.Text = "Plane_id";
            // 
            // idPlane
            // 
            this.idPlane.Location = new System.Drawing.Point(409, 12);
            this.idPlane.Name = "idPlane";
            this.idPlane.Size = new System.Drawing.Size(139, 20);
            this.idPlane.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pilot_id";
            // 
            // idPilot
            // 
            this.idPilot.Location = new System.Drawing.Point(409, 42);
            this.idPilot.Name = "idPilot";
            this.idPilot.Size = new System.Drawing.Size(139, 20);
            this.idPilot.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Аэропорт вылета";
            // 
            // dispAiroport
            // 
            this.dispAiroport.Location = new System.Drawing.Point(409, 69);
            this.dispAiroport.Name = "dispAiroport";
            this.dispAiroport.Size = new System.Drawing.Size(139, 20);
            this.dispAiroport.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Аэропорт посадки";
            // 
            // arvAiroport
            // 
            this.arvAiroport.Location = new System.Drawing.Point(409, 99);
            this.arvAiroport.Name = "arvAiroport";
            this.arvAiroport.Size = new System.Drawing.Size(139, 20);
            this.arvAiroport.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Дата вылета";
            // 
            // departDate
            // 
            this.departDate.Location = new System.Drawing.Point(409, 127);
            this.departDate.Name = "departDate";
            this.departDate.Size = new System.Drawing.Size(139, 20);
            this.departDate.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Дата посадки";
            // 
            // arvDate
            // 
            this.arvDate.Location = new System.Drawing.Point(409, 154);
            this.arvDate.Name = "arvDate";
            this.arvDate.Size = new System.Drawing.Size(139, 20);
            this.arvDate.TabIndex = 12;
            // 
            // AddFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 324);
            this.Controls.Add(this.arvDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.departDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.arvAiroport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dispAiroport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idPilot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idPlane);
            this.Controls.Add(this.plane_id);
            this.Controls.Add(this.button1);
            this.Name = "AddFlight";
            this.Text = "AddFlight";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label plane_id;
        private System.Windows.Forms.TextBox idPlane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idPilot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dispAiroport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox arvAiroport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox departDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox arvDate;
    }
}