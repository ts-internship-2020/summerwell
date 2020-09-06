using System;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ConferenceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRemote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JoinButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WithdrawButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ConferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnHostSearch = new System.Windows.Forms.Button();
            this.btnBackHost = new System.Windows.Forms.Button();
            this.btnNextHost = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.HostConferenceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostMainSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostIsRemote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostEditButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.HostConferenceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 499);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conferences";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker2.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(77, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(250, 26);
            this.dateTimePicker2.TabIndex = 2;
            this.dateTimePicker2.Value = new System.DateTime(1960, 7, 14, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 3;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(666, 395);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 50);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.nextPage);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(181, 395);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 50);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.previousPage);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(731, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 60);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 64;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConferenceName,
            this.StartDate,
            this.Type,
            this.Category,
            this.Location,
            this.MainSpeaker,
            this.IsRemote,
            this.AttendButton,
            this.JoinButton,
            this.WithdrawButton,
            this.ConferenceId});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(-4, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(909, 287);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.SizeChanged += dataGridView1_SizeChanged;
            // 
            // ConferenceName
            // 
            this.ConferenceName.HeaderText = "Conference Name";
            this.ConferenceName.MinimumWidth = 8;
            this.ConferenceName.Name = "ConferenceName";
            this.ConferenceName.ReadOnly = true;
            this.ConferenceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "Start Date";
            this.StartDate.MinimumWidth = 8;
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 8;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.MinimumWidth = 8;
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            this.Location.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainSpeaker
            // 
            this.MainSpeaker.HeaderText = "Main Speaker";
            this.MainSpeaker.MinimumWidth = 8;
            this.MainSpeaker.Name = "MainSpeaker";
            this.MainSpeaker.ReadOnly = true;
            this.MainSpeaker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // IsRemote
            // 
            this.IsRemote.HeaderText = "IsRemote";
            this.IsRemote.Name = "IsRemote";
            this.IsRemote.ReadOnly = true;
            this.IsRemote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AttendButton
            // 
            this.AttendButton.HeaderText = "Attend Button";
            this.AttendButton.MinimumWidth = 8;
            this.AttendButton.Name = "AttendButton";
            this.AttendButton.ReadOnly = true;
            this.AttendButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AttendButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // JoinButton
            // 
            this.JoinButton.HeaderText = "Join Button";
            this.JoinButton.MinimumWidth = 8;
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.ReadOnly = true;
            this.JoinButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.HeaderText = "Withdraw Button";
            this.WithdrawButton.MinimumWidth = 8;
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.ReadOnly = true;
            this.WithdrawButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ConferenceId
            // 
            this.ConferenceId.HeaderText = "ConferenceId";
            this.ConferenceId.MinimumWidth = 8;
            this.ConferenceId.Name = "ConferenceId";
            this.ConferenceId.ReadOnly = true;
            this.ConferenceId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ConferenceId.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Book Antiqua", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(379, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker1.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(430, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(246, 26);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2100, 6, 16, 0, 0, 0, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(175)))), ((int)(((byte)(235)))));
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.Controls.Add(this.btnHostSearch);
            this.tabPage2.Controls.Add(this.btnBackHost);
            this.tabPage2.Controls.Add(this.btnNextHost);
            this.tabPage2.Controls.Add(this.btnAddEvent);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.dateTimePicker4);
            this.tabPage2.Controls.Add(this.dateTimePicker3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Host";
            // 
            // btnHostSearch
            // 
            this.btnHostSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHostSearch.BackColor = System.Drawing.Color.White;
            this.btnHostSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHostSearch.BackgroundImage")));
            this.btnHostSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHostSearch.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHostSearch.Location = new System.Drawing.Point(731, 15);
            this.btnHostSearch.Name = "btnHostSearch";
            this.btnHostSearch.Size = new System.Drawing.Size(171, 60);
            this.btnHostSearch.TabIndex = 9;
            this.btnHostSearch.UseVisualStyleBackColor = false;
            this.btnHostSearch.Click += new System.EventHandler(this.btnHostSearch_Click);
            // 
            // btnBackHost
            // 
            this.btnBackHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackHost.BackColor = System.Drawing.Color.Transparent;
            this.btnBackHost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBackHost.BackgroundImage")));
            this.btnBackHost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackHost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBackHost.FlatAppearance.BorderSize = 3;
            this.btnBackHost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackHost.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBackHost.ForeColor = System.Drawing.Color.Transparent;
            this.btnBackHost.Location = new System.Drawing.Point(181, 395);
            this.btnBackHost.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackHost.Name = "btnBackHost";
            this.btnBackHost.Size = new System.Drawing.Size(85, 50);
            this.btnBackHost.TabIndex = 8;
            this.btnBackHost.UseVisualStyleBackColor = false;
            this.btnBackHost.Click += new System.EventHandler(this.btnBackHost_Click);
            // 
            // btnNextHost
            // 
            this.btnNextHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextHost.BackColor = System.Drawing.Color.Transparent;
            this.btnNextHost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNextHost.BackgroundImage")));
            this.btnNextHost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNextHost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNextHost.FlatAppearance.BorderSize = 3;
            this.btnNextHost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNextHost.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNextHost.ForeColor = System.Drawing.Color.White;
            this.btnNextHost.Location = new System.Drawing.Point(666, 395);
            this.btnNextHost.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextHost.Name = "btnNextHost";
            this.btnNextHost.Size = new System.Drawing.Size(85, 50);
            this.btnNextHost.TabIndex = 7;
            this.btnNextHost.UseVisualStyleBackColor = false;
            this.btnNextHost.Click += new System.EventHandler(this.btnNextHost_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddEvent.BackColor = System.Drawing.Color.White;
            this.btnAddEvent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddEvent.BackgroundImage")));
            this.btnAddEvent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEvent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEvent.Location = new System.Drawing.Point(365, 395);
            this.btnAddEvent.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(191, 49);
            this.btnAddEvent.TabIndex = 6;
            this.btnAddEvent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddEvent.UseVisualStyleBackColor = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HostConferenceName,
            this.HostStartDate,
            this.HostEndDate,
            this.HostType,
            this.HostCategory,
            this.HostAddress,
            this.HostMainSpeaker,
            this.HostIsRemote,
            this.HostEditButton,
            this.HostConferenceId});
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.Location = new System.Drawing.Point(6, 83);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(896, 287);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.Text = "dataGridView2";
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentDoubleClick);
            this.dataGridView2.SizeChanged += dataGridView2_SizeChanged;
            // 
            // HostConferenceName
            // 
            this.HostConferenceName.HeaderText = "Conference Name";
            this.HostConferenceName.MinimumWidth = 8;
            this.HostConferenceName.Name = "HostConferenceName";
            this.HostConferenceName.ReadOnly = true;
            this.HostConferenceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostStartDate
            // 
            this.HostStartDate.HeaderText = "Start Date";
            this.HostStartDate.MinimumWidth = 8;
            this.HostStartDate.Name = "HostStartDate";
            this.HostStartDate.ReadOnly = true;
            this.HostStartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostEndDate
            // 
            this.HostEndDate.HeaderText = "End Date";
            this.HostEndDate.MinimumWidth = 8;
            this.HostEndDate.Name = "HostEndDate";
            this.HostEndDate.ReadOnly = true;
            this.HostEndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostType
            // 
            this.HostType.HeaderText = "Type";
            this.HostType.MinimumWidth = 8;
            this.HostType.Name = "HostType";
            this.HostType.ReadOnly = true;
            this.HostType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostCategory
            // 
            this.HostCategory.HeaderText = "Category";
            this.HostCategory.MinimumWidth = 8;
            this.HostCategory.Name = "HostCategory";
            this.HostCategory.ReadOnly = true;
            this.HostCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostAddress
            // 
            this.HostAddress.HeaderText = "Address";
            this.HostAddress.MinimumWidth = 8;
            this.HostAddress.Name = "HostAddress";
            this.HostAddress.ReadOnly = true;
            this.HostAddress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostMainSpeaker
            // 
            this.HostMainSpeaker.HeaderText = "Main Speaker";
            this.HostMainSpeaker.MinimumWidth = 8;
            this.HostMainSpeaker.Name = "HostMainSpeaker";
            this.HostMainSpeaker.ReadOnly = true;
            this.HostMainSpeaker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostIsRemote
            // 
            this.HostIsRemote.HeaderText = "IsRemote";
            this.HostIsRemote.Name = "HostIsRemote";
            this.HostIsRemote.ReadOnly = true;
            this.HostIsRemote.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // HostEditButton
            // 
            this.HostEditButton.HeaderText = "Edit";
            this.HostEditButton.MinimumWidth = 8;
            this.HostEditButton.Name = "HostEditButton";
            this.HostEditButton.ReadOnly = true;
            this.HostEditButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HostEditButton.Text = "Edit";
            // 
            // HostConferenceId
            // 
            this.HostConferenceId.HeaderText = "HostConferenceId";
            this.HostConferenceId.MinimumWidth = 8;
            this.HostConferenceId.Name = "HostConferenceId";
            this.HostConferenceId.ReadOnly = true;
            this.HostConferenceId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HostConferenceId.Visible = false;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker4.CalendarTitleBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dateTimePicker4.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(77, 32);
            this.dateTimePicker4.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(250, 26);
            this.dateTimePicker4.TabIndex = 4;
            this.dateTimePicker4.Value = new System.DateTime(1921, 3, 4, 0, 0, 0, 0);
            this.dateTimePicker4.ValueChanged += new System.EventHandler(this.dateTimePicker4_ValueChanged);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dateTimePicker3.CalendarTitleBackColor = System.Drawing.Color.White;
            this.dateTimePicker3.CustomFormat = "dd\'/\'MM\'/\'yyyy hh\':\'mm tt";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(430, 32);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(250, 26);
            this.dateTimePicker3.TabIndex = 3;
            this.dateTimePicker3.Value = new System.DateTime(2100, 7, 16, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(378, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(5, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 499);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(770, 370);
            this.Name = "MainForm";
            this.Text = "Home";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private Button button3;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn Adress;
        private Button btnAddEvent;
        private Button button2;
        private Button button1;
        private Button btnBackHost;
        private Button btnNextHost;
        private Button btnHostSearch;
        private DataGridViewTextBoxColumn ConferenceName;
        private DataGridViewTextBoxColumn StartDate;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Location;
        private DataGridViewTextBoxColumn MainSpeaker;
        private DataGridViewTextBoxColumn IsRemote;
        private DataGridViewButtonColumn AttendButton;
        private DataGridViewButtonColumn JoinButton;
        private DataGridViewButtonColumn WithdrawButton;
        private DataGridViewTextBoxColumn ConferenceId;
        private DataGridViewTextBoxColumn HostConferenceName;
        private DataGridViewTextBoxColumn HostStartDate;
        private DataGridViewTextBoxColumn HostEndDate;
        private DataGridViewTextBoxColumn HostType;
        private DataGridViewTextBoxColumn HostCategory;
        private DataGridViewTextBoxColumn HostAddress;
        private DataGridViewTextBoxColumn HostMainSpeaker;
        private DataGridViewTextBoxColumn HostIsRemote;
        private DataGridViewButtonColumn HostEditButton;
        private DataGridViewTextBoxColumn HostConferenceId;
        private NotifyIcon notifyIcon1;
    }

}