﻿namespace ConferencePlanner.WinUi
{
    partial class StartUpForm
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
            System.Windows.Forms.Label titlu;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpForm));
            this.button1 = new System.Windows.Forms.Button();
            this.EmailBoss = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            titlu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titlu
            // 
            titlu.AutoSize = true;
            titlu.BackColor = System.Drawing.Color.Transparent;
            titlu.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            titlu.ForeColor = System.Drawing.Color.Tomato;
            titlu.Location = new System.Drawing.Point(64, 9);
            titlu.Name = "titlu";
            titlu.Size = new System.Drawing.Size(442, 50);
            titlu.TabIndex = 2;
            titlu.Text = "TOTALSOFTZOOM";
            titlu.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GhostWhite;
            this.button1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button1.Location = new System.Drawing.Point(182, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailBoss
            // 
            this.EmailBoss.AccessibleDescription = "";
            this.EmailBoss.AccessibleName = "";
            this.EmailBoss.ForeColor = System.Drawing.Color.DimGray;
            this.EmailBoss.Location = new System.Drawing.Point(171, 141);
            this.EmailBoss.Name = "EmailBoss";
            this.EmailBoss.PlaceholderText = "TYPE AN EMAIL";
            this.EmailBoss.Size = new System.Drawing.Size(198, 23);
            this.EmailBoss.TabIndex = 1;
            this.EmailBoss.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Invalid E-mail";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(518, 355);
            this.Controls.Add(this.label1);
            this.Controls.Add(titlu);
            this.Controls.Add(this.EmailBoss);
            this.Controls.Add(this.button1);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.Load += new System.EventHandler(this.StartUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EmailBoss;
        private System.Windows.Forms.Label titlu;
        private System.Windows.Forms.Label label1;
    }
}