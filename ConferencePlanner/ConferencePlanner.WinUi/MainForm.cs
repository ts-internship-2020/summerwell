using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                bool isAttend = false;
                bool isJoin = false;
                bool inWithdraw = false;
                int colindex = senderGrid.CurrentCell.ColumnIndex;
                if(colindex.ToString().Equals("7") && isAttend== false)
                {
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    InitTimer(sender, e.RowIndex, e.ColumnIndex);
                }
                if (colindex.ToString().Equals("8") && isJoin == false)
                {
                    isJoin = true;
                    pressButtonGreen(sender,e.RowIndex, e.ColumnIndex);
                }
                if (colindex.ToString().Equals("9") && inWithdraw == false)
                {
                    inWithdraw = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex-2);
                }
            }
        }

        private void pressButtonGreen(object sender,int row, int col)
        {
            var senderGrid = (DataGridView)sender;
            DataGridViewButtonCell bc = ((DataGridViewButtonCell)senderGrid.Rows[row].Cells[col]);
            bc.FlatStyle = FlatStyle.Flat;
            bc.Style.BackColor = Color.Red;
            bc.Style.ForeColor = Color.DarkRed;
        }

        private void makeButtonGreen(object datagrid, int row, int col)
        {
            var senderGrid = (DataGridView)datagrid;
            DataGridViewButtonCell bc = ((DataGridViewButtonCell)senderGrid.Rows[row].Cells[col]);
            bc.FlatStyle = FlatStyle.Flat;
            bc.Style.BackColor = Color.Green;
            bc.Style.ForeColor = Color.DarkGreen;
        }

        private Timer timer1;
        public void InitTimer(object datagrid, int row, int col)
        {
            timer1 = new Timer();
            timer1.Tick += (sender,e) => timer1_Tick(sender, e, datagrid, row, col);
            timer1.Interval = 10000; // 10 seconds / 10000 MillSecs
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e, object datagrid, int row, int col)
        {
            var senderGrid = (DataGridView)datagrid;
            if(!(senderGrid.Rows[row].Cells[1].Value.ToString().Equals("") || senderGrid.Rows[row].Cells[1]==null))
            {
                DateTime startDate = DateTime.ParseExact(senderGrid.Rows[row].Cells[1].Value.ToString(), "dd.MM.yyyy HH:mm:ss", null);
                DateTime now = DateTime.Now;
                if(startDate.AddMinutes(5) >= now)
                {
                    makeButtonGreen(datagrid, row, col+1);
                }
                if(DateTime.Now >= now.AddMinutes(5))
                {
                    makeButtonGreen(datagrid, row, col + 2);
                }
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
