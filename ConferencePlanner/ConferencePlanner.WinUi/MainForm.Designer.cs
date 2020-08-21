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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.HostConferenceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostMainSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConferenceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainSpeaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttendButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.JoinButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.WithdrawButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 453);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage1.BackgroundImage")));
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConferenceName,
            this.StartTime,
            this.Type,
            this.Category,
            this.Adress,
            this.MainSpeaker,
            this.AttendButton,
            this.JoinButton,
            this.WithdrawButton});
            this.dataGridView1.Location = new System.Drawing.Point(3, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(790, 248);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conferences";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(668, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 36);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(49, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(352, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(101, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(394, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.dateTimePicker4);
            this.tabPage2.Controls.Add(this.dateTimePicker3);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Host";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HostConferenceName,
            this.HostStartDate,
            this.HostEndDate,
            this.HostType,
            this.HostCategory,
            this.HostAddress,
            this.HostMainSpeaker});
            this.dataGridView2.Location = new System.Drawing.Point(3, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(790, 248);
            this.dataGridView2.TabIndex = 5;
            this.dataGridView2.Text = "dataGridView2";
            // 
            // HostConferenceName
            // 
            this.HostConferenceName.HeaderText = "Conference Name";
            this.HostConferenceName.Name = "HostConferenceName";
            // 
            // HostStartDate
            // 
            this.HostStartDate.HeaderText = "Start Date";
            this.HostStartDate.Name = "HostStartDate";
            // 
            // HostEndDate
            // 
            this.HostEndDate.HeaderText = "End Date";
            this.HostEndDate.Name = "HostEndDate";
            // 
            // HostType
            // 
            this.HostType.HeaderText = "Type";
            this.HostType.Name = "HostType";
            // 
            // HostCategory
            // 
            this.HostCategory.HeaderText = "Category";
            this.HostCategory.Name = "HostCategory";
            // 
            // HostAddress
            // 
            this.HostAddress.HeaderText = "Address";
            this.HostAddress.Name = "HostAddress";
            // 
            // HostMainSpeaker
            // 
            this.HostMainSpeaker.HeaderText = "Main Speaker";
            this.HostMainSpeaker.Name = "HostMainSpeaker";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Location = new System.Drawing.Point(501, 32);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker4.TabIndex = 4;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(101, 32);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(459, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(49, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // ConferenceName
            // 
            this.ConferenceName.HeaderText = "ConferenceName";
            this.ConferenceName.Name = "ConferenceName";
            this.ConferenceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.Name = "StartTime";
            this.StartTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Adress
            // 
            this.Adress.HeaderText = "Adress";
            this.Adress.Name = "Adress";
            this.Adress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainSpeaker
            // 
            this.MainSpeaker.HeaderText = "MainSpeaker";
            this.MainSpeaker.Name = "MainSpeaker";
            this.MainSpeaker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AttendButton
            // 
            this.AttendButton.HeaderText = "AttendButton";
            this.AttendButton.Name = "AttendButton";
            this.AttendButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AttendButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // JoinButton
            // 
            this.JoinButton.HeaderText = "JoinButton";
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.HeaderText = "WithdrawButton";
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Home";
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        private void changeColor()
        {
            // 
            // Button color
            // 
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[7]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = System.Drawing.Color.Green;
                bc.Style.ForeColor = System.Drawing.Color.DarkGreen;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[8]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = System.Drawing.Color.Red;
                bc.Style.ForeColor = System.Drawing.Color.DarkRed;

                DataGridViewButtonCell bc1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[9]);
                bc1.FlatStyle = FlatStyle.Flat;
                bc1.Style.BackColor = System.Drawing.Color.Red;
                bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostConferenceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostType;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostMainSpeaker;
        private Button button3;
        private DataGridViewTextBoxColumn ConferenceName;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Adress;
        private DataGridViewTextBoxColumn MainSpeaker;
        private DataGridViewButtonColumn AttendButton;
        private DataGridViewButtonColumn JoinButton;
        private DataGridViewButtonColumn WithdrawButton;
    }

}