namespace WindowsFormsApp1
{
    partial class Client
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
            this.infoClient = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.nameServ = new System.Windows.Forms.RichTextBox();
            this.costServ = new System.Windows.Forms.RichTextBox();
            this.nameServUse = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.idServ = new System.Windows.Forms.RichTextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoClient
            // 
            this.infoClient.Location = new System.Drawing.Point(12, 29);
            this.infoClient.Name = "infoClient";
            this.infoClient.Size = new System.Drawing.Size(264, 31);
            this.infoClient.TabIndex = 0;
            this.infoClient.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Показать инфо о себе";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 521);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Показать все улуги";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nameServ
            // 
            this.nameServ.Location = new System.Drawing.Point(77, 189);
            this.nameServ.Name = "nameServ";
            this.nameServ.Size = new System.Drawing.Size(117, 326);
            this.nameServ.TabIndex = 3;
            this.nameServ.Text = "";
            // 
            // costServ
            // 
            this.costServ.Location = new System.Drawing.Point(200, 189);
            this.costServ.Name = "costServ";
            this.costServ.Size = new System.Drawing.Size(68, 326);
            this.costServ.TabIndex = 4;
            this.costServ.Text = "";
            // 
            // nameServUse
            // 
            this.nameServUse.Location = new System.Drawing.Point(391, 29);
            this.nameServUse.Name = "nameServUse";
            this.nameServUse.Size = new System.Drawing.Size(170, 163);
            this.nameServUse.TabIndex = 5;
            this.nameServUse.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(424, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Заказанные услуги";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(391, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 42);
            this.button4.TabIndex = 7;
            this.button4.Text = "Заказать уборку номера";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // idServ
            // 
            this.idServ.Location = new System.Drawing.Point(3, 189);
            this.idServ.Name = "idServ";
            this.idServ.Size = new System.Drawing.Size(68, 326);
            this.idServ.TabIndex = 8;
            this.idServ.Text = "";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(136, 521);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(50, 20);
            this.id.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(200, 521);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 37);
            this.button5.TabIndex = 10;
            this.button5.Text = "Заказать услугу";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 576);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.id);
            this.Controls.Add(this.idServ);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.nameServUse);
            this.Controls.Add(this.costServ);
            this.Controls.Add(this.nameServ);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoClient);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox infoClient;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox nameServ;
        private System.Windows.Forms.RichTextBox costServ;
        private System.Windows.Forms.RichTextBox nameServUse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox idServ;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button button5;
    }
}