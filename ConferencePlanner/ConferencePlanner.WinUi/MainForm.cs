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
using ConferencePlanner.Abstraction.Model;
using System.Data.SqlClient;
using Accessibility;

namespace ConferencePlanner.WinUi
{

    public partial class MainForm : Form
    {
        private readonly IConferenceRepository _ConferenceRepository;

        private int totalEntries;
        private int currentOffset;
        private int startingPoint;
        private List<ConferenceDetailModel> x;
        private string var_email;

        public MainForm(IConferenceRepository ConferenceRepository, string var_email)
        {
            InitializeComponent();
            _ConferenceRepository = ConferenceRepository;
            x = _ConferenceRepository.GetConferenceDetail();
            var_email = var_email;

            totalEntries = x.Count;
            currentOffset = 5;
            startingPoint = 0;

            if (x == null || x.Count() == 0)
            {
                return;
            }
            /*      
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
              */

            populateGridView(startingPoint, currentOffset);
            changeColor();
        }


        private void populateGridView(int startingPoint, int endingPoint)
        {
            for (int i = startingPoint; i < endingPoint; i++)
            {
                dataGridView1.Rows.Add(x[i].ConferenceName, x[i].StartDate,
                                        x[i].DictionaryConferenceTypeName,
                                        x[i].DictionaryConferenceCategoryName,
                                        x[i].DictionaryCityName,
                                        x[i].SpeakerName);
                if (x[i].HostEmail == var_email)
                {
                    dataGridView2.Rows.Add(x[i].ConferenceName, x[i].StartDate,
                                            x[i].DictionaryConferenceTypeName,
                                            x[i].DictionaryConferenceCategoryName,
                                            x[i].DictionaryCityName,
                                            x[i].SpeakerName);
                }
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
                int colindex = senderGrid.CurrentCell.ColumnIndex;
                if(colindex.ToString().Equals("6") && isAttend== false)
                {
                    ConferenceAudienceModel _conferenceAudienceModel = new ConferenceAudienceModel();
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    //_conferenceAudienceModel.ConferenceId = dataGridView1.Rows[e.RowIndex].Cells[0] 
                    InitTimer(sender, e.RowIndex, e.ColumnIndex);

                }
                if (colindex.ToString().Equals("7") && isJoin == false)
                {
                    isJoin = true;
                    pressButtonGreen(sender,e.RowIndex, e.ColumnIndex);
                }
                if (colindex.ToString().Equals("8") && inWithdraw == false)
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
            try {
                if (!(senderGrid.Rows[row] == null | senderGrid.Rows[row].Cells[1].Value.ToString().Equals("")))
                {
                    DateTime startDate = DateTime.ParseExact(senderGrid.Rows[row].Cells[1].Value.ToString(), "dd.MM.yyyy HH:mm:ss", null);
                    DateTime now = DateTime.Now;
                    MessageBox.Show(now.ToString());
                    if (now.AddMinutes(5) >= startDate)
                    {
                        makeButtonGreen(datagrid, row, col + 1);
                    }
                    if (startDate.AddMinutes(5) <= now)
                    {
                        makeButtonGreen(datagrid, row, col + 2);
                        Timer timer = (Timer)sender;
                        timer.Stop();
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                Timer timer = (Timer)sender;
                timer.Stop();
                System.Environment.Exit(1);
            }
        }

        private void changeColor()
        {
            // 
            // Button color
            // 
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[6]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = System.Drawing.Color.Green;
                bc.Style.ForeColor = System.Drawing.Color.DarkGreen;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[7]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = System.Drawing.Color.Red;
                bc.Style.ForeColor = System.Drawing.Color.DarkRed;

                DataGridViewButtonCell bc1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells[8]);
                bc1.FlatStyle = FlatStyle.Flat;
                bc1.Style.BackColor = System.Drawing.Color.Red;
                bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
            }
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

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            {

                if (dataGridView2.CurrentCell == null)
                {

                    MessageBox.Show("namdate??");
                    //textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                    // textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                }
                try
                { 


                    MainSpeakerDetails mf = new MainSpeakerDetails();
                    mf.textBox1.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    mf.textBox2.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    mf.textBox3.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    mf.textBox4.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
                    mf.textBox5.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
                    mf.textBox6.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();

                  
                 
                    mf.ShowDialog();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("You cannot process an empty cell");
                }
            }


        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            

            if (dataGridView1.CurrentCell == null)
            {

                MessageBox.Show("namdate??");
                //textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
               // textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            }
            try
            {

                string rating = "";
                string nationality = "";

                SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("Select Rating, Nationality from Speaker where SpeakerName=@name", conn);
                command.Parameters.AddWithValue("@name", this.dataGridView1.CurrentRow.Cells[5].Value.ToString());
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rating = String.Format("{0}", reader["Rating"]);
                        nationality = String.Format("{0}", reader["Nationality"]);

                    }
                }

                conn.Close();


                MainSpeakerDetails mf = new MainSpeakerDetails();
                mf.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                mf.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                mf.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                mf.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                mf.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                mf.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                mf.textBox7.Text = rating;
                mf.textBox8.Text = nationality;
                mf.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You cannot process an empty cell");
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void previousPage(object sender, EventArgs e)
        {


            if ((currentOffset - 5) > 0)
            {

                startingPoint -= 5;
                currentOffset -= 5;

            }

            else if (startingPoint <= 0)
            {
                return;

            }

        

            dataGridView1.Rows.Clear();

            populateGridView(startingPoint, currentOffset);


        }

        private void nextPage(object sender, EventArgs e)
        {

            if((currentOffset + 5) <= totalEntries)
            {

                startingPoint = currentOffset;
                currentOffset += 5;

            }

            else if(currentOffset >= totalEntries)
            {
                return;

            }

            else{

                startingPoint = currentOffset;
                currentOffset += totalEntries - currentOffset;

            }

            dataGridView1.Rows.Clear();

            populateGridView(startingPoint, currentOffset);


        }
    }


}
