using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ConferencePlanner.Abstraction.Repository;
using System.Data.SqlClient;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.WinUi
{
    
    public partial class StartUpForm : Form
    {
        string var_email = "";
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IConferenceTypeRepository _ConferenceTypeRepository;
        private readonly IDictionaryCountryRepository _DictionaryCountryRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        private readonly IDictionaryCountyRepository _DictionaryCountyRepository;
        private readonly IDictionaryCityRepository _DictionaryCityRepository;
        private readonly IDictionaryConferenceCategoryRepository _DictionaryConferenceCategoryRepository;
        private readonly ILocationRepository _LocationRepository;
        public StartUpForm(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository, IDictionaryCountryRepository DictionaryCountryRepository, IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryCityRepository dictionaryCityRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository, ILocationRepository locationRepository)
        {
            _DictionaryCityRepository = dictionaryCityRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            _ConferenceRepository = ConferenceRepository;
            _ConferenceTypeRepository = ConferenceTypeRepository;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
            _LocationRepository = locationRepository;
            InitializeComponent();
        }

        private void StartUpForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           bool em=IsValid(EmailBoss.Text);
            if (em==true)
            {

                //MessageBox.Show("Welcome");
                //buton ok
                var_email = EmailBoss.Text;
                //MessageBox.Show(var_email);
                MainForm form2 = new MainForm(_GetSpeakerDetail, _ConferenceTypeRepository, _ConferenceRepository, _DictionaryCountryRepository, _DictionaryCountyRepository, _DictionaryCityRepository, _DictionaryConferenceCategoryRepository, _LocationRepository, var_email);
                form2.Tag = this;
                form2.Show(this);

                this.Hide();
            }




        }
       /* private void SetBalloonTip()
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Balloon Tip Title";
            notifyIcon1.BalloonTipText = "Balloon Tip Text.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            this.Click += new EventHandler(Form1_Click);
        }

        void Form1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);
        } */

        public bool IsValid(string emailBoss)
        {
            Regex check = new Regex(@"^\w+[\w-\.]+\@\w{5}\.[a-z]{2,3}$");
            bool valid;
            valid = check.IsMatch(emailBoss);
            if (valid == true)
                return true;
            else
            {
                SetBalloonTip();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(30);

                EmailLabel.Show();
                return false;
            }
        }
        private void SetBalloonTip()
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Invalid Email";
            notifyIcon1.BalloonTipText = "Please insert a valid Email";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            this.Click += new EventHandler(Form1_Click);
        }

        void Form1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(30000);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void freeTrialMessage1_Click(object sender, EventArgs e)
        {

        }

        private void freeTrialMessage2_Click(object sender, EventArgs e)
        {

        }

        private void box3_Click(object sender, EventArgs e)
        {

        }

        private void box1_Click(object sender, EventArgs e)
        {

        }
    }
}
