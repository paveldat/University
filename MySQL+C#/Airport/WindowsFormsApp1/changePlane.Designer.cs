namespace WindowsFormsApp1
{
    partial class changePlane
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
            this.idPlane = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.namePlane = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Изменить данные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "plane_id";
            // 
            // idPlane
            // 
            this.idPlane.Location = new System.Drawing.Point(249, 12);
            this.idPlane.Name = "idPlane";
            this.idPlane.Size = new System.Drawing.Size(127, 20);
            this.idPlane.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название самолета";
            // 
            // namePlane
            // 
            this.namePlane.Location = new System.Drawing.Point(249, 45);
            this.namePlane.Name = "namePlane";
            this.namePlane.Size = new System.Drawing.Size(127, 20);
            this.namePlane.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Компания";
            // 
            // company
            // 
            this.company.Location = new System.Drawing.Point(249, 80);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(127, 20);
            this.company.TabIndex = 6;
            // 
            // changePlane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 298);
            this.Controls.Add(this.company);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.namePlane);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idPlane);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "changePlane";
            this.Text = "changePlane";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idPlane;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox namePlane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox company;
    }
}