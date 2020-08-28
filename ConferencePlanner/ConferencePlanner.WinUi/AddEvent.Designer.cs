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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEvent));
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
            this.btnAdd1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabCountry = new System.Windows.Forms.TabPage();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.btnNext2 = new System.Windows.Forms.Button();
            this.tabSpeaker = new System.Windows.Forms.TabPage();
            this.btnAdd3 = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.btnNext3 = new System.Windows.Forms.Button();
            this.tabCounty = new System.Windows.Forms.TabPage();
            this.btnAdd5 = new System.Windows.Forms.Button();
            this.listView4 = new System.Windows.Forms.ListView();
            this.btnNext4 = new System.Windows.Forms.Button();
            this.tabCity = new System.Windows.Forms.TabPage();
            this.btnAdd4 = new System.Windows.Forms.Button();
            this.listView5 = new System.Windows.Forms.ListView();
            this.btnNext5 = new System.Windows.Forms.Button();
            this.tabCategory = new System.Windows.Forms.TabPage();
            this.btnAdd6 = new System.Windows.Forms.Button();
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
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(590, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conference Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(676, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(683, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "End Date";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(694, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            this.label4.Visible = false;
            // 
            // AddConferenceName
            // 
            this.AddConferenceName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddConferenceName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddConferenceName.Location = new System.Drawing.Point(806, 53);
            this.AddConferenceName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddConferenceName.Name = "AddConferenceName";
            this.AddConferenceName.Size = new System.Drawing.Size(284, 30);
            this.AddConferenceName.TabIndex = 4;
            // 
            // AddAddress
            // 
            this.AddAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddAddress.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddAddress.Location = new System.Drawing.Point(806, 202);
            this.AddAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddAddress.Name = "AddAddress";
            this.AddAddress.Size = new System.Drawing.Size(284, 30);
            this.AddAddress.TabIndex = 5;
            this.AddAddress.Visible = false;
            // 
            // AddStartDate
            // 
            this.AddStartDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddStartDate.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.AddStartDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddStartDate.Location = new System.Drawing.Point(806, 102);
            this.AddStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddStartDate.Name = "AddStartDate";
            this.AddStartDate.Size = new System.Drawing.Size(284, 30);
            this.AddStartDate.TabIndex = 6;
            // 
            // AddEndDate
            // 
            this.AddEndDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddEndDate.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.AddEndDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AddEndDate.Location = new System.Drawing.Point(806, 152);
            this.AddEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddEndDate.Name = "AddEndDate";
            this.AddEndDate.Size = new System.Drawing.Size(284, 30);
            this.AddEndDate.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabType);
            this.tabControl1.Controls.Add(this.tabCountry);
            this.tabControl1.Controls.Add(this.tabSpeaker);
            this.tabControl1.Controls.Add(this.tabCounty);
            this.tabControl1.Controls.Add(this.tabCity);
            this.tabControl1.Controls.Add(this.tabCategory);
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(19, 20);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 395);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabType
            // 
            this.tabType.AllowDrop = true;
            this.tabType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabType.Controls.Add(this.btnAdd1);
            this.tabType.Controls.Add(this.listView1);
            this.tabType.Controls.Add(this.btnNext);
            this.tabType.Location = new System.Drawing.Point(4, 5);
            this.tabType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabType.Name = "tabType";
            this.tabType.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabType.Size = new System.Drawing.Size(523, 386);
            this.tabType.TabIndex = 0;
            this.tabType.Text = "Conference Type";
            // 
            // btnAdd1
            // 
            this.btnAdd1.BackColor = System.Drawing.Color.White;
            this.btnAdd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd1.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd1.Location = new System.Drawing.Point(447, 177);
            this.btnAdd1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(43, 38);
            this.btnAdd1.TabIndex = 11;
            this.btnAdd1.Text = "+";
            this.btnAdd1.UseVisualStyleBackColor = false;
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(31, 42);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(293, 269);
            this.listView1.TabIndex = 10;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.EditType_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext.Location = new System.Drawing.Point(383, 262);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(133, 82);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabCountry
            // 
            this.tabCountry.BackColor = System.Drawing.Color.White;
            this.tabCountry.Controls.Add(this.btnAdd2);
            this.tabCountry.Controls.Add(this.listView2);
            this.tabCountry.Controls.Add(this.btnNext2);
            this.tabCountry.Location = new System.Drawing.Point(4, 5);
            this.tabCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCountry.Name = "tabCountry";
            this.tabCountry.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCountry.Size = new System.Drawing.Size(523, 386);
            this.tabCountry.TabIndex = 1;
            this.tabCountry.Text = "Country";
            // 
            // btnAdd2
            // 
            this.btnAdd2.BackColor = System.Drawing.Color.White;
            this.btnAdd2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd2.Location = new System.Drawing.Point(447, 177);
            this.btnAdd2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(43, 38);
            this.btnAdd2.TabIndex = 2;
            this.btnAdd2.Text = "+";
            this.btnAdd2.UseVisualStyleBackColor = false;
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
            // 
            // listView2
            // 
            this.listView2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(31, 42);
            this.listView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(293, 269);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.DoubleClick += new System.EventHandler(this.EditCountry_Click);
            // 
            // btnNext2
            // 
            this.btnNext2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext2.Enabled = false;
            this.btnNext2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext2.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext2.Location = new System.Drawing.Point(383, 262);
            this.btnNext2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext2.Name = "btnNext2";
            this.btnNext2.Size = new System.Drawing.Size(133, 82);
            this.btnNext2.TabIndex = 0;
            this.btnNext2.Text = "Next";
            this.btnNext2.UseVisualStyleBackColor = true;
            this.btnNext2.Click += new System.EventHandler(this.btnNext2_Click);
            // 
            // tabSpeaker
            // 
            this.tabSpeaker.BackColor = System.Drawing.Color.White;
            this.tabSpeaker.Controls.Add(this.btnAdd3);
            this.tabSpeaker.Controls.Add(this.listView3);
            this.tabSpeaker.Controls.Add(this.btnNext3);
            this.tabSpeaker.Enabled = false;
            this.tabSpeaker.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabSpeaker.Location = new System.Drawing.Point(4, 5);
            this.tabSpeaker.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.tabSpeaker.Name = "tabSpeaker";
            this.tabSpeaker.Size = new System.Drawing.Size(523, 386);
            this.tabSpeaker.TabIndex = 2;
            this.tabSpeaker.Text = "Speaker";
            // 
            // btnAdd3
            // 
            this.btnAdd3.BackColor = System.Drawing.Color.White;
            this.btnAdd3.Location = new System.Drawing.Point(447, 177);
            this.btnAdd3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd3.Name = "btnAdd3";
            this.btnAdd3.Size = new System.Drawing.Size(43, 38);
            this.btnAdd3.TabIndex = 2;
            this.btnAdd3.Text = "+";
            this.btnAdd3.UseVisualStyleBackColor = false;
            this.btnAdd3.Click += new System.EventHandler(this.btnAdd3_Click);
            // 
            // listView3
            // 
            this.listView3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(31, 42);
            this.listView3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(293, 269);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            this.listView3.DoubleClick += new System.EventHandler(this.EditSpeaker_Click);
            // 
            // btnNext3
            // 
            this.btnNext3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext3.Enabled = false;
            this.btnNext3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext3.Location = new System.Drawing.Point(383, 262);
            this.btnNext3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext3.Name = "btnNext3";
            this.btnNext3.Size = new System.Drawing.Size(133, 82);
            this.btnNext3.TabIndex = 0;
            this.btnNext3.Text = "Next";
            this.btnNext3.UseVisualStyleBackColor = true;
            this.btnNext3.Click += new System.EventHandler(this.btnNext3_Click);
            // 
            // tabCounty
            // 
            this.tabCounty.BackColor = System.Drawing.SystemColors.Control;
            this.tabCounty.Controls.Add(this.btnAdd5);
            this.tabCounty.Controls.Add(this.listView4);
            this.tabCounty.Controls.Add(this.btnNext4);
            this.tabCounty.Location = new System.Drawing.Point(4, 5);
            this.tabCounty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCounty.Name = "tabCounty";
            this.tabCounty.Size = new System.Drawing.Size(523, 386);
            this.tabCounty.TabIndex = 3;
            this.tabCounty.Text = "County";
            // 
            // btnAdd5
            // 
            this.btnAdd5.Location = new System.Drawing.Point(447, 177);
            this.btnAdd5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd5.Name = "btnAdd5";
            this.btnAdd5.Size = new System.Drawing.Size(43, 38);
            this.btnAdd5.TabIndex = 2;
            this.btnAdd5.Text = "+";
            this.btnAdd5.UseVisualStyleBackColor = true;
            this.btnAdd5.Click += new System.EventHandler(this.btnAdd5_Click);
            // 
            // listView4
            // 
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(31, 42);
            this.listView4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(293, 269);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            this.listView4.DoubleClick += new System.EventHandler(this.EditCounty_Click);
            // 
            // btnNext4
            // 
            this.btnNext4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext4.Enabled = false;
            this.btnNext4.Location = new System.Drawing.Point(384, 258);
            this.btnNext4.Name = "btnNext4";
            this.btnNext4.Size = new System.Drawing.Size(133, 82);
            this.btnNext4.TabIndex = 0;
            this.btnNext4.Text = "Next";
            this.btnNext4.UseVisualStyleBackColor = true;
            this.btnNext4.Click += new System.EventHandler(this.btnNext4_Click);
            // 
            // tabCity
            // 
            this.tabCity.BackColor = System.Drawing.Color.White;
            this.tabCity.Controls.Add(this.btnAdd4);
            this.tabCity.Controls.Add(this.listView5);
            this.tabCity.Controls.Add(this.btnNext5);
            this.tabCity.Location = new System.Drawing.Point(4, 5);
            this.tabCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCity.Name = "tabCity";
            this.tabCity.Size = new System.Drawing.Size(523, 386);
            this.tabCity.TabIndex = 4;
            this.tabCity.Text = "City";
            // 
            // btnAdd4
            // 
            this.btnAdd4.BackColor = System.Drawing.Color.White;
            this.btnAdd4.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd4.Location = new System.Drawing.Point(447, 177);
            this.btnAdd4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd4.Name = "btnAdd4";
            this.btnAdd4.Size = new System.Drawing.Size(43, 38);
            this.btnAdd4.TabIndex = 2;
            this.btnAdd4.Text = "+";
            this.btnAdd4.UseVisualStyleBackColor = false;
            this.btnAdd4.Click += new System.EventHandler(this.btnAdd4_Click);
            // 
            // listView5
            // 
            this.listView5.FullRowSelect = true;
            this.listView5.HideSelection = false;
            this.listView5.Location = new System.Drawing.Point(31, 42);
            this.listView5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(293, 269);
            this.listView5.TabIndex = 1;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.SelectedIndexChanged += new System.EventHandler(this.listView5_SelectedIndexChanged);
            this.listView5.DoubleClick += new System.EventHandler(this.EditCity_Click);
            // 
            // btnNext5
            // 
            this.btnNext5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext5.BackColor = System.Drawing.Color.White;
            this.btnNext5.Enabled = false;
            this.btnNext5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext5.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNext5.Location = new System.Drawing.Point(383, 262);
            this.btnNext5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext5.Name = "btnNext5";
            this.btnNext5.Size = new System.Drawing.Size(133, 82);
            this.btnNext5.TabIndex = 0;
            this.btnNext5.Text = "Next";
            this.btnNext5.UseVisualStyleBackColor = false;
            this.btnNext5.Click += new System.EventHandler(this.btnNext5_Click);
            // 
            // tabCategory
            // 
            this.tabCategory.BackColor = System.Drawing.Color.White;
            this.tabCategory.Controls.Add(this.btnAdd6);
            this.tabCategory.Controls.Add(this.listView6);
            this.tabCategory.Controls.Add(this.btnSave);
            this.tabCategory.Location = new System.Drawing.Point(4, 5);
            this.tabCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.Size = new System.Drawing.Size(523, 386);
            this.tabCategory.TabIndex = 5;
            this.tabCategory.Text = "Category";
            // 
            // btnAdd6
            // 
            this.btnAdd6.BackColor = System.Drawing.Color.White;
            this.btnAdd6.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdd6.Location = new System.Drawing.Point(447, 177);
            this.btnAdd6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd6.Name = "btnAdd6";
            this.btnAdd6.Size = new System.Drawing.Size(43, 38);
            this.btnAdd6.TabIndex = 12;
            this.btnAdd6.Text = "+";
            this.btnAdd6.UseVisualStyleBackColor = false;
            this.btnAdd6.Click += new System.EventHandler(this.btnAdd6_Click);
            // 
            // listView6
            // 
            this.listView6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView6.HideSelection = false;
            this.listView6.Location = new System.Drawing.Point(31, 42);
            this.listView6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(293, 269);
            this.listView6.TabIndex = 11;
            this.listView6.UseCompatibleStateImageBehavior = false;
            this.listView6.SelectedIndexChanged += new System.EventHandler(this.listView6_SelectedIndexChanged);
            this.listView6.DoubleClick += new System.EventHandler(this.EditCategory_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(383, 262);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 82);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveNew.BackColor = System.Drawing.Color.White;
            this.btnSaveNew.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSaveNew.Location = new System.Drawing.Point(843, 288);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(216, 92);
            this.btnSaveNew.TabIndex = 11;
            this.btnSaveNew.Text = "Save and New";
            this.btnSaveNew.UseVisualStyleBackColor = false;
            this.btnSaveNew.Visible = false;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // AddEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1126, 570);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1133, 574);
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
        private Button btnAdd1;
        private Button btnAdd2;
        private Button btnAdd3;
        private Button btnAdd5;
        private Button btnAdd4;
        private Button btnAdd6;
    }
}