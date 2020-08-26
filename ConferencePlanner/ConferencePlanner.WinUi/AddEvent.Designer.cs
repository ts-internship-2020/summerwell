using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabCountry = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.tabSpeaker = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.btnNext3 = new System.Windows.Forms.Button();
            this.tabCounty = new System.Windows.Forms.TabPage();
            this.listView4 = new System.Windows.Forms.ListView();
            this.btnNext4 = new System.Windows.Forms.Button();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.listView5 = new System.Windows.Forms.ListView();
            this.btnNext5 = new System.Windows.Forms.Button();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.listView6 = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
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
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
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
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabType
            // 
            this.tabType.AllowDrop = true;
            this.tabType.Controls.Add(this.listView1);
            this.tabType.Controls.Add(this.btnNext);
            this.tabType.Location = new System.Drawing.Point(4, 27);
            this.tabType.Name = "tabType";
            this.tabType.Padding = new System.Windows.Forms.Padding(3);
            this.tabType.Size = new System.Drawing.Size(364, 206);
            this.tabType.TabIndex = 0;
            this.tabType.Text = "Conference Type";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(206, 163);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.EditType_Click);
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
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabCountry
            // 
            this.tabCountry.Controls.Add(this.listView2);
            this.tabCountry.Controls.Add(this.btnNext2);
            this.tabCountry.Location = new System.Drawing.Point(4, 27);
            this.tabCountry.Name = "tabCountry";
            this.tabCountry.Padding = new System.Windows.Forms.Padding(3);
            this.tabCountry.Size = new System.Drawing.Size(364, 206);
            this.tabCountry.TabIndex = 1;
            this.tabCountry.Text = "Country";
            this.tabCountry.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(22, 25);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(206, 163);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.DoubleClick += new System.EventHandler(this.EditCountry_Click);
            // 
            // btnNext2
            // 
            this.btnNext2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext2.Enabled = false;
            this.btnNext2.Location = new System.Drawing.Point(268, 157);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(93, 49);
            this.btnNext2.TabIndex = 0;
            this.btnNext2.Text = "Next";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // tabSpeaker
            // 
            this.tabSpeaker.BackColor = System.Drawing.SystemColors.Control;
            this.tabSpeaker.Controls.Add(this.listView3);
            this.tabSpeaker.Controls.Add(this.btnNext3);
            this.tabSpeaker.Enabled = false;
            this.tabSpeaker.Location = new System.Drawing.Point(4, 27);
            this.tabSpeaker.Name = "tabSpeaker";
            this.tabSpeaker.Size = new System.Drawing.Size(364, 206);
            this.tabSpeaker.TabIndex = 2;
            this.tabSpeaker.Text = "Speaker";
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(22, 25);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(206, 163);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            this.listView3.DoubleClick += new System.EventHandler(this.EditSpeaker_Click);
            // 
            // btnNext3
            // 
            this.btnNext3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext3.Enabled = false;
            this.btnNext3.Location = new System.Drawing.Point(268, 157);
            this.btnNext3.Name = "btnNext3";
            this.btnNext3.Size = new System.Drawing.Size(93, 49);
            this.btnNext3.TabIndex = 0;
            this.btnNext3.Text = "Next";
            this.btnNext3.UseVisualStyleBackColor = true;
            this.btnNext3.Click += new System.EventHandler(this.btnNext3_Click);
            // 
            // tabCounty
            // 
            this.tabCounty.BackColor = System.Drawing.SystemColors.Control;
            this.tabCounty.Controls.Add(this.listView4);
            this.tabCounty.Controls.Add(this.btnNext4);
            this.tabCounty.Location = new System.Drawing.Point(4, 27);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Size = new System.Drawing.Size(364, 206);
            this.tabCounty.TabIndex = 3;
            this.tabCounty.Text = "County";
            // 
            // listView4
            // 
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(22, 25);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(206, 163);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            this.listView4.DoubleClick += new System.EventHandler(this.EditCounty_Click);
            // 
            // btnNext4
            // 
            this.btnNext4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext4.Enabled = false;
            this.btnNext4.Location = new System.Drawing.Point(269, 155);
            this.btnNext4.Margin = new System.Windows.Forms.Padding(2);
            this.btnNext4.Name = "btnNext4";
            this.btnNext4.Size = new System.Drawing.Size(93, 49);
            this.btnNext4.TabIndex = 0;
            this.btnNext4.Text = "Next";
            this.btnNext4.UseVisualStyleBackColor = true;
            this.btnNext4.Click += new System.EventHandler(this.btnNext4_Click);
            // 
            // tabCity
            // 
            this.tabCity.BackColor = System.Drawing.SystemColors.Control;
            this.tabCity.Controls.Add(this.listView5);
            this.tabCity.Controls.Add(this.btnNext5);
            this.tabCity.Location = new System.Drawing.Point(4, 27);
            this.tabCity.Name = "tabCity";
            this.tabCity.Size = new System.Drawing.Size(364, 206);
            this.tabCity.TabIndex = 4;
            this.tabCity.Text = "City";
            // 
            // listView5
            // 
            this.listView5.FullRowSelect = true;
            this.listView5.HideSelection = false;
            this.listView5.Location = new System.Drawing.Point(22, 25);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(206, 163);
            this.listView5.TabIndex = 1;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.SelectedIndexChanged += new System.EventHandler(this.listView5_SelectedIndexChanged);
            this.listView5.DoubleClick += new System.EventHandler(this.EditCity_Click);
            // 
            // btnNext5
            // 
            this.btnNext5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext5.Enabled = false;
            this.btnNext5.Location = new System.Drawing.Point(268, 157);
            this.btnNext5.Name = "btnNext5";
            this.btnNext5.Size = new System.Drawing.Size(93, 49);
            this.btnNext5.TabIndex = 0;
            this.btnNext5.Text = "Next";
            this.btnNext5.UseVisualStyleBackColor = true;
            this.btnNext5.Click += new System.EventHandler(this.btnNext5_Click);
            // 
            // tabCategory
            // 
            this.tabCategory.BackColor = System.Drawing.SystemColors.Control;
            this.tabCategory.Controls.Add(this.listView6);
            this.tabCategory.Controls.Add(this.btnSave);
            this.tabCategory.Location = new System.Drawing.Point(4, 27);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Size = new System.Drawing.Size(364, 206);
            this.tabCategory.TabIndex = 5;
            this.tabCategory.Text = "Category";
            // 
            // listView6
            // 
            this.listView6.HideSelection = false;
            this.listView6.Location = new System.Drawing.Point(22, 25);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(206, 163);
            this.listView6.TabIndex = 11;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.SelectedIndexChanged += new System.EventHandler(this.listView6_SelectedIndexChanged);
            this.listView6.DoubleClick += new System.EventHandler(this.EditCategory_Click);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // AddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 342);
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
            this.MinimumSize = new System.Drawing.Size(802, 374);
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
        private System.Windows.Forms.Button btnNext4;
        private System.Windows.Forms.Button btnNext5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ListView listView5;
        private System.Windows.Forms.ListView listView6;
        private ListView listView1;
    }
}