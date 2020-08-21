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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ConferenceName;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Adress;
        private DataGridViewTextBoxColumn MainSpeaker;
        private DataGridViewTextBoxColumn AttendButton;
        private DataGridViewTextBoxColumn JoinButton;
        private DataGridViewTextBoxColumn WithdrawButton;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private TabPage tabPage2;
    }
}