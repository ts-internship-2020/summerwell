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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpForm));
            this.button1 = new System.Windows.Forms.Button();
            this.EmailBoss = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            titlu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titlu
            // 
            titlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            titlu.AutoSize = true;
            titlu.BackColor = System.Drawing.Color.Transparent;
            titlu.Font = new System.Drawing.Font("Century Schoolbook", 28F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            titlu.ForeColor = System.Drawing.Color.LightSlateGray;
            titlu.Location = new System.Drawing.Point(205, 32);
            titlu.Name = "titlu";
            titlu.Size = new System.Drawing.Size(399, 44);
            titlu.TabIndex = 2;
            titlu.Text = "TOTALSOFTZOOM";
            titlu.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.LightSlateGray;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.SlateGray;
            this.button1.Location = new System.Drawing.Point(301, 266);
            this.button1.MinimumSize = new System.Drawing.Size(187, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 72);
            this.button1.TabIndex = 0;
            this.button1.Text = "JOIN";
            this.button1.UseMnemonic = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailBoss
            // 
            this.EmailBoss.AccessibleDescription = "";
            this.EmailBoss.AccessibleName = "";
            this.EmailBoss.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailBoss.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmailBoss.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.EmailBoss.ForeColor = System.Drawing.Color.LightSlateGray;
            this.EmailBoss.Location = new System.Drawing.Point(223, 163);
            this.EmailBoss.Margin = new System.Windows.Forms.Padding(4);
            this.EmailBoss.Name = "EmailBoss";
            this.EmailBoss.PlaceholderText = "TYPE AN EMAIL";
            this.EmailBoss.Size = new System.Drawing.Size(341, 29);
            this.EmailBoss.TabIndex = 1;
            this.EmailBoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.EmailLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.BackColor = System.Drawing.Color.FloralWhite;
            this.EmailLabel.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EmailLabel.ForeColor = System.Drawing.Color.LightSlateGray;
            this.EmailLabel.Location = new System.Drawing.Point(323, 209);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(162, 19);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Please Insert An Email";
            this.EmailLabel.Visible = false;
            this.EmailLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(845, 387);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(titlu);
            this.Controls.Add(this.EmailBoss);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(859, 343);
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