namespace ConferencePlanner.WinUi
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
            this.button1 = new System.Windows.Forms.Button();
            this.EmailBoss = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            titlu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titlu
            // 
            titlu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            titlu.AutoSize = true;
            titlu.BackColor = System.Drawing.Color.Transparent;
            titlu.Font = new System.Drawing.Font("Rockwell", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            titlu.ForeColor = System.Drawing.Color.IndianRed;
            titlu.Location = new System.Drawing.Point(110, 60);
            titlu.Name = "titlu";
            titlu.Size = new System.Drawing.Size(332, 42);
            titlu.TabIndex = 2;
            titlu.Text = "TOTALSOFTZOOM";
            titlu.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(168, 238);
            this.button1.MinimumSize = new System.Drawing.Size(187, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 72);
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
            this.EmailBoss.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EmailBoss.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.EmailBoss.ForeColor = System.Drawing.Color.DimGray;
            this.EmailBoss.Location = new System.Drawing.Point(161, 141);
            this.EmailBoss.Name = "EmailBoss";
            this.EmailBoss.PlaceholderText = "TYPE AN EMAIL";
            this.EmailBoss.Size = new System.Drawing.Size(208, 29);
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
            // EmailLabel
            // 
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(208, 173);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(104, 15);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Please Insert Email";
            this.EmailLabel.Visible = false;
            this.EmailLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(572, 387);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(titlu);
            this.Controls.Add(this.EmailBoss);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(588, 426);
            this.Name = "StartUpForm";
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.StartUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EmailBoss;
        private System.Windows.Forms.Label titlu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label EmailLabel;
    }
}