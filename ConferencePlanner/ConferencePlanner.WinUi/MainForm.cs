using ConferencePlanner.Abstraction.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        private readonly IConferenceRepository _ConferenceRepository;
        public MainForm(IConferenceRepository ConferenceRepository,string var_email)
        {
            InitializeComponent();
            _ConferenceRepository = ConferenceRepository;
            var x = _ConferenceRepository.GetConferenceDetail();
            if (x == null || x.Count() == 0)
            {
                return;
            }
                
            foreach(var c in x)
            {
                dataGridView1.Rows.Add(c.ConferenceName, c.StartDate,
                                        c.DictionaryConferenceTypeName,
                                        c.DictionaryConferenceCategoryName,
                                        c.DictionaryCityName,
                                        c.SpeakerName);
                if (c.HostEmail == var_email) {
                    dataGridView2.Rows.Add(c.ConferenceName, c.StartDate,
                                            c.DictionaryConferenceTypeName,
                                            c.DictionaryConferenceCategoryName,
                                            c.DictionaryCityName,
                                            c.SpeakerName); }
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                bool isAttend = false;
                bool isJoin = false;
                bool inWithdraw = false;
                int rowindex = senderGrid.CurrentCell.ColumnIndex;
                if(rowindex.ToString().Equals("6") && isAttend== false)
                {
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    InitTimer(sender,e, e.RowIndex, e.ColumnIndex);
                }
                if (rowindex.ToString().Equals("7") && isAttend == false)
                {
                    isJoin = true;
                    pressButtonGreen(sender,e.RowIndex, e.ColumnIndex);
                }
                if (rowindex.ToString().Equals("8") && isAttend == false)
                {
                    inWithdraw = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
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
        public void InitTimer(object sender, EventArgs e, int row, int col)
        {
            timer1 = new Timer();
            timer1.Tick += (sender,e) => timer1_Tick(sender, e, row, col);
            timer1.Interval = 10000; // 10 seconds / 10000 MillSecs
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e, int row, int col)
        {
            var senderGrid = (DataGridView)sender;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
