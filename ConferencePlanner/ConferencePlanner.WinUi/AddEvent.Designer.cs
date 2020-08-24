namespace ConferencePlanner.WinUi
{
    partial class AddEvent
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddConferenceName = new System.Windows.Forms.TextBox();
            this.AddAddress = new System.Windows.Forms.TextBox();
            this.AddStartDate = new System.Windows.Forms.DateTimePicker();
            this.AddEndDate = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabType = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabCountry = new System.Windows.Forms.TabPage();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.tabSpeaker = new System.Windows.Forms.TabPage();
            this.btnNext3 = new System.Windows.Forms.Button();
            this.tabCounty = new System.Windows.Forms.TabPage();
            this.btnNext4 = new System.Windows.Forms.Button();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.btnNext5 = new System.Windows.Forms.Button();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabType.SuspendLayout();
            this.tabCountry.SuspendLayout();
            this.tabSpeaker.SuspendLayout();
            this.tabCounty.SuspendLayout();
            this.tabCity.SuspendLayout();
            this.tabCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(402, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conference Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(447, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // AddConferenceName
            // 
            this.AddConferenceName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddConferenceName.Location = new System.Drawing.Point(522, 25);
            this.AddConferenceName.Name = "AddConferenceName";
            this.AddConferenceName.Size = new System.Drawing.Size(200, 23);
            this.AddConferenceName.TabIndex = 4;
            // 
            // AddAddress
            // 
            this.AddAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddAddress.Location = new System.Drawing.Point(522, 145);
            this.AddAddress.Name = "AddAddress";
            this.AddAddress.Size = new System.Drawing.Size(200, 23);
            this.AddAddress.TabIndex = 5;
            // 
            // AddStartDate
            // 
            this.AddStartDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddStartDate.Location = new System.Drawing.Point(522, 61);
            this.AddStartDate.Name = "AddStartDate";
            this.AddStartDate.Size = new System.Drawing.Size(200, 23);
            this.AddStartDate.TabIndex = 6;
            // 
            // AddEndDate
            // 
            this.AddEndDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddEndDate.Location = new System.Drawing.Point(522, 106);
            this.AddEndDate.Name = "AddEndDate";
            this.AddEndDate.Size = new System.Drawing.Size(200, 23);
            this.AddEndDate.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabType);
            this.tabControl1.Controls.Add(this.tabCountry);
            this.tabControl1.Controls.Add(this.tabSpeaker);
            this.tabControl1.Controls.Add(this.tabCounty);
            this.tabControl1.Controls.Add(this.tabCity);
            this.tabControl1.Controls.Add(this.tabCategory);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 237);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabType
            // 
            this.tabType.Controls.Add(this.btnNext);
            this.tabType.Location = new System.Drawing.Point(4, 24);
            this.tabType.Name = "tabType";
            this.tabType.Padding = new System.Windows.Forms.Padding(3);
            this.tabType.Size = new System.Drawing.Size(364, 209);
            this.tabType.TabIndex = 0;
            this.tabType.Text = "Conference Type";
            this.tabType.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(268, 157);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(93, 49);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // tabCountry
            // 
            this.tabCountry.Controls.Add(this.btnNext2);
            this.tabCountry.Location = new System.Drawing.Point(4, 24);
            this.tabCountry.Name = "tabCountry";
            this.tabCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tabCountry.Size = new System.Drawing.Size(364, 209);
            this.tabCountry.TabIndex = 1;
            this.tabCountry.Text = "Country";
            this.tabCountry.UseVisualStyleBackColor = true;
            // 
            // btnNext2
            // 
            this.btnNext2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext2.Location = new System.Drawing.Point(268, 157);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(93, 49);
            this.btnNext2.TabIndex = 0;
            this.btnNext2.Text = "Next";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Visible = false;
            // 
            // tabSpeaker
            // 
            this.tabSpeaker.Controls.Add(this.btnNext3);
            this.tabSpeaker.Location = new System.Drawing.Point(4, 24);
            this.tabSpeaker.Name = "tabSpeaker";
            this.tabSpeaker.Size = new System.Drawing.Size(364, 209);
            this.tabSpeaker.TabIndex = 2;
            this.tabSpeaker.Text = "Speaker";
            // 
            // btnNext3
            // 
            this.btnNext3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext3.Location = new System.Drawing.Point(268, 157);
            this.btnNext3.Name = "btnNext3";
            this.btnNext3.Size = new System.Drawing.Size(93, 49);
            this.btnNext3.TabIndex = 0;
            this.btnNext3.Text = "Next";
            this.btnNext3.UseVisualStyleBackColor = true;
            // 
            // tabCounty
            // 
            this.tabCounty.Controls.Add(this.btnNext4);
            this.tabCounty.Location = new System.Drawing.Point(4, 24);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Size = new System.Drawing.Size(364, 209);
            this.tabCounty.TabIndex = 3;
            this.tabCounty.Text = "County";
            // 
            // btnNext4
            // 
            this.btnNext4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext4.Location = new System.Drawing.Point(268, 157);
            this.btnNext4.Name = "btnNext4";
            this.btnNext4.Size = new System.Drawing.Size(93, 49);
            this.btnNext4.TabIndex = 0;
            this.btnNext4.Text = "Next";
            this.btnNext4.UseVisualStyleBackColor = true;
            // 
            // tabCity
            // 
            this.tabCity.Controls.Add(this.btnNext5);
            this.tabCity.Location = new System.Drawing.Point(4, 24);
            this.tabCity.Name = "tabCity";
            this.tabCity.Size = new System.Drawing.Size(364, 209);
            this.tabCity.TabIndex = 4;
            this.tabCity.Text = "City";
            // 
            // btnNext5
            // 
            this.btnNext5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext5.Location = new System.Drawing.Point(268, 157);
            this.btnNext5.Name = "btnNext5";
            this.btnNext5.Size = new System.Drawing.Size(93, 49);
            this.btnNext5.TabIndex = 0;
            this.btnNext5.Text = "Next";
            this.btnNext5.UseVisualStyleBackColor = true;
            // 
            // tabCategory
            // 
            this.tabCategory.Controls.Add(this.btnSave);
            this.tabCategory.Location = new System.Drawing.Point(4, 24);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Size = new System.Drawing.Size(364, 209);
            this.tabCategory.TabIndex = 5;
            this.tabCategory.Text = "Category";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(268, 157);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 49);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNew.Location = new System.Drawing.Point(629, 200);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(93, 49);
            this.btnSaveNew.TabIndex = 11;
            this.btnSaveNew.Text = "Save and New";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.AddEndDate);
            this.Controls.Add(this.AddStartDate);
            this.Controls.Add(this.AddAddress);
            this.Controls.Add(this.AddConferenceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(804, 381);
            this.Name = "AddEvent";
            this.Text = "AddEvent";
            this.tabControl1.ResumeLayout(false);
            this.tabType.ResumeLayout(false);
            this.tabCountry.ResumeLayout(false);
            this.tabSpeaker.ResumeLayout(false);
            this.tabCounty.ResumeLayout(false);
            this.tabCity.ResumeLayout(false);
            this.tabCategory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AddConferenceName;
        private System.Windows.Forms.TextBox AddAddress;
        private System.Windows.Forms.DateTimePicker AddStartDate;
        private System.Windows.Forms.DateTimePicker AddEndDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabType;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tabCountry;
        private System.Windows.Forms.TabPage tabSpeaker;
        private System.Windows.Forms.TabPage tabCounty;
        private System.Windows.Forms.TabPage tabCity;
        private System.Windows.Forms.TabPage tabCategory;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnNext2;
        private System.Windows.Forms.Button btnNext3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNext4;
        private System.Windows.Forms.Button btnNext5;
    }
}