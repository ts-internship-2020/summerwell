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
using ConferencePlanner.Repository.Ado.Repository;
using System.Drawing.Text;
using Windows.UI.Xaml.Documents;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConferencePlanner.WinUi
{

    public partial class MainForm : Form
    {
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IConferenceTypeRepository _ConferenceTypeRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        private readonly IDictionaryCountryRepository _DictionaryCountryRepository;
        private readonly IDictionaryCountyRepository _DictionaryCountyRepository;
        private readonly IDictionaryCityRepository _DictionaryCityRepository;
        private readonly IDictionaryConferenceCategoryRepository _DictionaryConferenceCategoryRepository;
        private AddConferenceDetailModel addConferenceDetailModel;
        private System.Windows.Forms.Timer reloadData;
        private int totalEntries;
        private int startingPoint;
        private int HosttotalEntries;
        private int HoststartingPoint;
        private List<ConferenceDetailAttendFirstModel> x;
        private List<ConferenceDetailModel> y;
        private List<ConferenceAudienceModel> conferencesCurrentUserAttends;
        protected string currentUser;
        protected MainForm f;
        private int nr_row;

        public MainForm(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository conferenceTypeRepository, IConferenceRepository ConferenceRepository, IDictionaryCountryRepository DictionaryCountryRepository, IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryCityRepository dictionaryCityRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository, string var_email)
        {

            InitializeComponent();
            nr_row = dataGridView1.Size.Height / 40;
            f = this;
            _ConferenceTypeRepository = conferenceTypeRepository;
            _ConferenceRepository = ConferenceRepository;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _DictionaryCityRepository = dictionaryCityRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
            currentUser = var_email;
            conferencesCurrentUserAttends = _ConferenceRepository.GetConferenceAudience(currentUser);
            reloadData = new System.Windows.Forms.Timer();
            reloadData.Tick += new EventHandler(timerReloadData_Tick);
            reloadData.Interval = 10000;
            reloadData.Start();
            x = _ConferenceRepository.GetAttendedConferencesFirst(conferencesCurrentUserAttends, dateTimePicker2.Value, dateTimePicker1.Value);

            y = _ConferenceRepository.GetConferenceDetailForHost(currentUser, dateTimePicker4.Value, dateTimePicker3.Value);

            totalEntries = x.Count;
            startingPoint = 0;
            HoststartingPoint = 0;
            HosttotalEntries = y.Count;

            addConferenceDetailModel = new AddConferenceDetailModel();

            addConferenceDetailModel.HostEmail = currentUser;

            if (x == null || x.Count() == 0)
            {
                return;
            }

            if (totalEntries < nr_row)
            {
                populateConferenceGridViewByDate(0, totalEntries, dateTimePicker2.Value, dateTimePicker1.Value);
                changeColor();
            }
            else { populateConferenceGridViewByDate(0, nr_row, dateTimePicker2.Value, dateTimePicker1.Value); changeColor(); }

            if (y == null || y.Count() == 0)
            {
                return;
            }
            if (HosttotalEntries < nr_row) { populateHostGridViewByDate(0, HosttotalEntries, dateTimePicker4.Value, dateTimePicker3.Value);
                btnBackHost.Enabled = false;
                btnNextHost.Enabled = false; }

            else populateHostGridViewByDate(0, nr_row, dateTimePicker4.Value, dateTimePicker3.Value);
            
        }

        private void populateConferenceGridViewByDate(int startingPoint, int endingPoint, DateTime StartDate, DateTime EndDate)
        {
            for (int i = startingPoint; i < endingPoint; i++)
            {
                if (x[i].StartDate > StartDate && x[i].StartDate < EndDate)
                {
                    dataGridView1.Rows.Add(x[i].ConferenceName, x[i].StartDate, x[i].DictionaryConferenceTypeName,
                                       x[i].DictionaryConferenceCategoryName,
                                       x[i].LocationStreet,
                                       x[i].SpeakerName,x[i].IsRemote,
                                       null, null, null, x[i].ConferenceId);
                }
            }

        }
        private void populateHostGridViewByDate(int startingPoint, int endingPoint,DateTime StartDate, DateTime EndDate)
            {   
                for (int i = startingPoint; i < endingPoint; i++)
                {
                    if (y[i].StartDate > StartDate && y[i].StartDate < EndDate)
                    {
                        dataGridView2.Rows.Add(y[i].ConferenceName, y[i].StartDate,y[i].EndDate, y[i].DictionaryConferenceTypeName,
                                  y[i].DictionaryConferenceCategoryName,
                                  y[i].LocationStreet,
                                  y[i].SpeakerName, y[i].IsRemote,
                                  null,  y[i].ConferenceId);
                    }
                }


        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            int rowHeight = dataGridView1.Size.Height  / 40;
            if (rowHeight > 0)
            {
                nr_row = rowHeight;
                dataGridView1.Rows.Clear();
                if (totalEntries < nr_row)
                {
                    populateConferenceGridViewByDate(0, totalEntries, dateTimePicker2.Value, dateTimePicker1.Value);
                    changeColor();
                }
                else { populateConferenceGridViewByDate(0, nr_row, dateTimePicker2.Value, dateTimePicker1.Value); 
                    changeColor(); 
                }
            }
        }
        private void dataGridView2_SizeChanged(object sender, EventArgs e)
        {
            int rowHeight = dataGridView2.Size.Height / 40;
            if (rowHeight > 0)
            {
                nr_row = rowHeight;
                dataGridView2.Rows.Clear();
                if (HosttotalEntries < nr_row)
                {
                    populateHostGridViewByDate(0, HosttotalEntries, dateTimePicker4.Value, dateTimePicker3.Value);
                }

                else
                {
                    populateHostGridViewByDate(0, nr_row, dateTimePicker4.Value, dateTimePicker3.Value);
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
                if (senderGrid.CurrentCell.OwningColumn.Name.ToString().Equals("AttendButton") && isAttend == false)
                {
                    ConferenceAudienceModel _conferenceAudienceModel = new ConferenceAudienceModel();
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    _conferenceAudienceModel.ConferenceId = (int)dataGridView1.Rows[e.RowIndex].Cells["ConferenceId"].Value;
                    _conferenceAudienceModel.ConferenceName = (string)dataGridView1.Rows[e.RowIndex].Cells["ConferenceName"].Value;
                    _conferenceAudienceModel.Participant = currentUser;
                    _conferenceAudienceModel.ConferenceStatusId = 3;
                    _conferenceAudienceModel.UniqueParticipantCode = _ConferenceRepository.GetUniqueParticipantCode();
                   
                    try
                    {
                        _ConferenceRepository.AddParticipant(_conferenceAudienceModel);
                        Thread thread = new Thread(() => _ConferenceRepository.GetQRCodeUniqueParticipantCode(_conferenceAudienceModel));
                        thread.Start();
                    }
                    catch (SqlException ex)
                    {
                        _ConferenceRepository.UpdateParticipant(_conferenceAudienceModel);
                    }
                    conferencesCurrentUserAttends.Clear();
                    conferencesCurrentUserAttends = _ConferenceRepository.GetConferenceAudience(currentUser);
                    changeColorForSingleButton(e.RowIndex);
                    changeColorForJoinButtons();
                    //InitTimer(sender, e.RowIndex, e.ColumnIndex);

                }
                if (senderGrid.CurrentCell.OwningColumn.Name.ToString().Equals("JoinButton") && isJoin == false)
                {
                    isJoin = true;
                    DateTime startDate = (DateTime)dataGridView1.Rows[e.RowIndex].Cells["StartDate"].Value;
                    DateTime currentTime = DateTime.Now;
                    if (currentTime.AddMinutes(5) >= startDate)
                    {
                        ConferenceAudienceModel _conferenceAudienceModel = new ConferenceAudienceModel();
                        _conferenceAudienceModel.ConferenceId = (int)dataGridView1.Rows[e.RowIndex].Cells["ConferenceId"].Value;
                        _conferenceAudienceModel.Participant = currentUser;
                        _conferenceAudienceModel.ConferenceStatusId = 1;
                        int rows_affected = _ConferenceRepository.UpdateParticipantToJoin(_conferenceAudienceModel);
                        if (rows_affected > 0)
                        {
                            JoinConference jc = new JoinConference();
                            jc.Show(this);
                            pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                        }
                        else
                        {
                            MessageBox.Show("You have to attend before you can join!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("You can't join the conference yet!");
                    }
                }
                if (senderGrid.CurrentCell.OwningColumn.Name.ToString().Equals("WithdrawButton") && inWithdraw == false)
                {
                    ConferenceAudienceModel _conferenceAudienceModel = new ConferenceAudienceModel();
                    _conferenceAudienceModel.ConferenceId = (int)dataGridView1.Rows[e.RowIndex].Cells["ConferenceId"].Value;
                    _conferenceAudienceModel.Participant = currentUser;
                    _conferenceAudienceModel.ConferenceStatusId = 2;
                    int rows_affected = _ConferenceRepository.UpdateParticipant(_conferenceAudienceModel);
                    if (rows_affected <= 0)
                        MessageBox.Show("You have to attend before you can withdraw!");
                    inWithdraw = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex);
                    isAttend = true;
                    pressButtonGreen(sender, e.RowIndex, e.ColumnIndex - 2);
                    conferencesCurrentUserAttends.Clear();
                    conferencesCurrentUserAttends = _ConferenceRepository.GetConferenceAudience(currentUser);
                    changeColorForSingleButton(e.RowIndex);
                    changeColorForJoinButtons();

                }
            }

        }

        private void pressButtonGreen(object sender, int row, int col)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)senderGrid.Rows[row].Cells[col]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = Color.DarkRed;
                bc.Style.ForeColor = Color.DarkRed;
            }
            catch { MessageBox.Show("Please press again!"); }
        }

        private void makeButtonGreen(object datagrid, int row, int col)
        {
            try
            {
                var senderGrid = (DataGridView)datagrid;
                DataGridViewButtonCell bc = ((DataGridViewButtonCell)senderGrid.Rows[row].Cells[col]);
                bc.FlatStyle = FlatStyle.Flat;
                bc.Style.BackColor = Color.DarkGreen;
                bc.Style.ForeColor = Color.DarkGreen;
            } catch { MessageBox.Show("Please press again!"); }
        }

        private System.Windows.Forms.Timer timer1;
        public void InitTimer(object datagrid, int row, int col)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += (sender, e) => timer1_Tick(sender, e, datagrid, row, col);
            timer1.Interval = 10000; // 10 seconds / 10000 MillSecs
            timer1.Start();
        }
        private void timerReloadData_Tick(object sender, EventArgs e)
        {
            x.Clear();
            x = _ConferenceRepository.GetAttendedConferencesFirst(conferencesCurrentUserAttends, dateTimePicker2.Value, dateTimePicker1.Value);
            totalEntries = x.Count();
            changeColorForJoinButtons();
        }
        private void timer1_Tick(object sender, EventArgs e, object datagrid, int row, int col)
        {
            var senderGrid = (DataGridView)datagrid;
            try {
                if (!(senderGrid.Rows[row] == null | senderGrid.Rows[row].Cells[1].Value.ToString().Equals("")))
                {
                    DateTime startDate = DateTime.ParseExact(senderGrid.Rows[row].Cells[1].Value.ToString(), "dd/MM/yyyy HH:mm:ss", null);
                    DateTime now = DateTime.Now;
                    //MessageBox.Show(now.ToString());
                    if (now.AddMinutes(5) >= startDate)
                    {
                        makeButtonGreen(datagrid, row, col + 1);

                    }
                    if (startDate.AddMinutes(5) <= now)
                    {
                        makeButtonGreen(datagrid, row, col + 2);
                        System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
                        timer.Stop();
                    }
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                System.Windows.Forms.Timer timer = (System.Windows.Forms.Timer)sender;
                timer.Stop();
                System.Environment.Exit(1);
            }
        }
        private void changeColorForJoinButtons()
        {
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells["JoinButton"]);
                    bc.FlatStyle = FlatStyle.Flat;
                    if (conferencesCurrentUserAttends.Exists(currentConference =>
                                         currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[i].Cells["ConferenceId"].Value.ToString())
                                         && currentConference.ConferenceStatusId == 3)
                                         && DateTime.Now.AddMinutes(5) >= (DateTime)dataGridView1.Rows[i].Cells["StartDate"].Value)

                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkGreen;
                        bc.Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Nothing to see here");
            }
        }
        private void changeColorForSingleButton(int row)
        {
            // 
            // Button color
            // 
            try
            {
                
                    DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[row].Cells["AttendButton"]);
                    bc.FlatStyle = FlatStyle.Flat;
                    if (conferencesCurrentUserAttends.Exists(currentConference =>
                                         currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[row].Cells["ConferenceId"].Value.ToString())
                                         && currentConference.ConferenceStatusId == 3))

                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkGreen;
                        bc.Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                

                    DataGridViewButtonCell bc1 = ((DataGridViewButtonCell)dataGridView1.Rows[row].Cells["WithdrawButton"]);
                    bc1.FlatStyle = FlatStyle.Flat;
                    if (conferencesCurrentUserAttends.Exists(currentConference =>
                                         currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[row].Cells["ConferenceId"].Value.ToString())
                                         && currentConference.ConferenceStatusId == 2))
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (!conferencesCurrentUserAttends.Exists(currentConference =>
                                          currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[row].Cells["ConferenceId"].Value.ToString())))
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkGreen;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                
            }
            catch { }
        }
        private void changeColor()
        {
            // 
            // Button color
            // 
            try
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewButtonCell bc = (DataGridViewButtonCell)dataGridView1.Rows[i].Cells["AttendButton"];
                    bc.FlatStyle = FlatStyle.Flat;
                    if (conferencesCurrentUserAttends.Exists(currentConference =>
                                         currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[i].Cells["ConferenceId"].Value.ToString())
                                         && currentConference.ConferenceStatusId == 3))

                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        bc.Style.BackColor = System.Drawing.Color.DarkGreen;
                        bc.Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewButtonCell bc = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells["JoinButton"]);
                    bc.FlatStyle = FlatStyle.Flat;
                    bc.Style.BackColor = System.Drawing.Color.DarkRed;
                    bc.Style.ForeColor = System.Drawing.Color.DarkRed;

                    DataGridViewButtonCell bc1 = ((DataGridViewButtonCell)dataGridView1.Rows[i].Cells["WithdrawButton"]);
                    bc1.FlatStyle = FlatStyle.Flat;
                    if (conferencesCurrentUserAttends.Exists(currentConference =>
                                         currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[i].Cells["ConferenceId"].Value.ToString())
                                         && currentConference.ConferenceStatusId == 2))
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (!conferencesCurrentUserAttends.Exists(currentConference =>
                                          currentConference.ConferenceId == Int32.Parse(dataGridView1.Rows[i].Cells["ConferenceId"].Value.ToString())))
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkRed;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        bc1.Style.BackColor = System.Drawing.Color.DarkGreen;
                        bc1.Style.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                }
            }
            catch { }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //com
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (senderGrid.CurrentCell.OwningColumn.Name.ToString().Equals("HostEditButton"))
                    {
                        addConferenceDetailModel.ConferenceId = (int)dataGridView2.Rows[e.RowIndex].Cells["HostConferenceId"].Value;
                        addConferenceDetailModel.ConferenceName = (string)dataGridView2.Rows[e.RowIndex].Cells["HostConferenceName"].Value;
                        addConferenceDetailModel.ConferenceTypeName = (string)dataGridView2.Rows[e.RowIndex].Cells["HostType"].Value;
                        addConferenceDetailModel.ConferenceCategoryName = (string)dataGridView2.Rows[e.RowIndex].Cells["HostCategory"].Value;
                        addConferenceDetailModel.Location = (string)dataGridView2.Rows[e.RowIndex].Cells["HostAddress"].Value;
                        addConferenceDetailModel.Speaker = (string)dataGridView2.Rows[e.RowIndex].Cells["HostMainSpeaker"].Value;
                        addConferenceDetailModel.StartDate = (DateTime)dataGridView2.Rows[e.RowIndex].Cells["HostStartDate"].Value;
                        addConferenceDetailModel.EndDate = (DateTime)dataGridView2.Rows[e.RowIndex].Cells["HostEndDate"].Value;

                        AddEvent form3 = new AddEvent(0, f, addConferenceDetailModel, _GetSpeakerDetail,
                            _ConferenceTypeRepository, _ConferenceRepository,
                            _DictionaryCityRepository, _DictionaryCountryRepository,
                            _DictionaryCountyRepository, _DictionaryConferenceCategoryRepository);
                        this.Enabled = false;
                        form3.Tag = this;
                        form3.Show(this);
                    }
                }
            }
            catch { MessageBox.Show("Press again!"); }

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
               /* try
                {


                    MainSpeakerDetails mf = new MainSpeakerDetails(_ConferenceRepository, _GetSpeakerDetail, dataGridView2.CurrentRow.Cells["HostMainSpeaker"].Value.ToString());
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
               */
            }


        }


        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



            if (dataGridView1.CurrentCell != null & (dataGridView1.CurrentCell.ColumnIndex.ToString().Equals("5")))

                try
                {

                    string rating = "";
                    string nationality = "";
                    string picture = "";
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("Select Rating, Nationality, SpeakerImage from Speaker where SpeakerName=@name", conn);
                    command.Parameters.AddWithValue("@name", this.dataGridView1.CurrentRow.Cells[5].Value.ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rating = String.Format("{0}", reader["Rating"]);
                            nationality = String.Format("{0}", reader["Nationality"]);
                            picture = String.Format("{0}", reader["SpeakerImage"]);

                        }
                    }

                    conn.Close();


                    MainSpeakerDetails mf = new MainSpeakerDetails(_ConferenceRepository, _GetSpeakerDetail, dataGridView1.CurrentRow.Cells["MainSpeaker"].Value.ToString());
                    mf.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    mf.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    mf.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    mf.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    mf.textBox5.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    mf.textBox6.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                    mf.textBox7.Text = rating;
                    mf.textBox8.Text = nationality;
                    mf.ShowDialog();
                    mf.Enabled = false;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("You cannot process an empty cell");
                }
        }
        public void AddEventNotEdit()
        {
            AddEvent form3 = new AddEvent(1, f, addConferenceDetailModel, _GetSpeakerDetail, _ConferenceTypeRepository,
                        _ConferenceRepository, _DictionaryCityRepository, _DictionaryCountryRepository,
                        _DictionaryCountyRepository, _DictionaryConferenceCategoryRepository);
            this.Enabled = false;
            form3.Tag = this;
            form3.Show(this);
        }
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            AddEventNotEdit();
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void btnHostSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                y.Clear();
                y = _ConferenceRepository.GetConferenceDetailForHost(currentUser, dateTimePicker4.Value, dateTimePicker3.Value);
                HosttotalEntries = y.Count;
                populateHostGridViewByDate(0, 5, dateTimePicker4.Value, dateTimePicker3.Value);
            }
            catch { MessageBox.Show("No conferences"); }

        }

        private void previousPage(object sender, EventArgs e)
        {
            try
            {
                nr_row = dataGridView1.Size.Height / 40;
                if (startingPoint > nr_row)
                {
                    startingPoint -= nr_row;
                    dataGridView1.Rows.Clear();
                    populateConferenceGridViewByDate(startingPoint, startingPoint + nr_row, dateTimePicker2.Value, dateTimePicker1.Value);
                    changeColor();

                }

                else if (startingPoint > 0)
                {
                    startingPoint = 0;
                    dataGridView1.Rows.Clear();
                    populateConferenceGridViewByDate(startingPoint, startingPoint + nr_row, dateTimePicker2.Value, dateTimePicker1.Value);
                    changeColor();

                }

                else
                {
                    return;
                }
            }
            catch { MessageBox.Show("No more conferences"); }
        }



        private void nextPage(object sender, EventArgs e)
        {
            try
            {
                nr_row = dataGridView1.Size.Height / 40;
                if (startingPoint < totalEntries - nr_row)
                {
                    startingPoint += nr_row;
                    dataGridView1.Rows.Clear();
                    if (startingPoint + nr_row < totalEntries)
                    {
                        populateConferenceGridViewByDate(startingPoint, startingPoint + nr_row, dateTimePicker2.Value, dateTimePicker1.Value);
                        changeColor();
                    }

                    else
                    {
                        populateConferenceGridViewByDate(startingPoint, totalEntries, dateTimePicker2.Value, dateTimePicker1.Value);
                        changeColor();
                    }
                }

                else if (startingPoint == totalEntries)

                {
                    Refresh();
                    return;
                }


            }
            catch { MessageBox.Show("No more conferences"); }


        }
        private void btnNextHost_Click(object sender, EventArgs e)
        {
            try
            {
                nr_row = dataGridView2.Size.Height / 40;
                if (HoststartingPoint <= HosttotalEntries - nr_row)
                {
                    HoststartingPoint += nr_row;
                    dataGridView2.Rows.Clear();
                    if (HoststartingPoint + nr_row < HosttotalEntries)
                    {
                        populateHostGridViewByDate(HoststartingPoint, HoststartingPoint + nr_row, dateTimePicker4.Value, dateTimePicker3.Value);
                    }

                    else
                    {
                        populateHostGridViewByDate(HoststartingPoint, HosttotalEntries, dateTimePicker4.Value, dateTimePicker3.Value);
                    }
                }
                else if (HoststartingPoint == HosttotalEntries)
                {
                    Refresh();
                    return;
                }
            }
            catch { MessageBox.Show("No more conferences"); }

        }

        private void btnBackHost_Click(object sender, EventArgs e)
        {
            try
            {
                nr_row = dataGridView2.Size.Height / 40;
                if (HoststartingPoint >= nr_row)
                {
                    HoststartingPoint -= nr_row;
                    dataGridView2.Rows.Clear();
                    populateHostGridViewByDate(HoststartingPoint, HoststartingPoint + nr_row, dateTimePicker4.Value, dateTimePicker3.Value);

                }

                else if (HoststartingPoint > 0)
                {
                    HoststartingPoint = 0;
                    dataGridView2.Rows.Clear();
                    populateHostGridViewByDate(HoststartingPoint, HoststartingPoint + nr_row, dateTimePicker4.Value, dateTimePicker3.Value);

                }

                else
                {
                    return;
                }
            }
            catch { MessageBox.Show("No more conferences"); }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                x.Clear();
                x = _ConferenceRepository.GetAttendedConferencesFirst(conferencesCurrentUserAttends, dateTimePicker2.Value, dateTimePicker1.Value);
                totalEntries = x.Count;
                if (totalEntries >= nr_row)
                {
                    populateConferenceGridViewByDate(0, nr_row, dateTimePicker2.Value, dateTimePicker1.Value);
                }
                else
                {
                    populateConferenceGridViewByDate(0, totalEntries, dateTimePicker2.Value, dateTimePicker1.Value);
                }
                changeColor();
            }
            catch { MessageBox.Show("No conferences"); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void PopulateMamam()
        {
            try {
                dataGridView2.Rows.Clear();
                y = _ConferenceRepository.GetConferenceDetailForHost(currentUser, dateTimePicker4.Value, dateTimePicker3.Value);
                HosttotalEntries = y.Count;

                if (HosttotalEntries < nr_row)
                {

                    populateHostGridViewByDate(0, HosttotalEntries, dateTimePicker4.Value, dateTimePicker3.Value);
                    btnBackHost.Enabled = false;
                    btnNextHost.Enabled = false;
                }

                else populateHostGridViewByDate(0, nr_row, dateTimePicker4.Value, dateTimePicker3.Value);
            }
            catch { MessageBox.Show("No more conferences"); }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

