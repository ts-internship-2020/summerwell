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
        private readonly IDictionaryConferenceCategoryRepository _DictionaryConferenceCategoryRepository;
        public StartUpForm(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository, IDictionaryCountryRepository DictionaryCountryRepository, IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository)
        {
            _GetSpeakerDetail = GetSpeakerDetail;
            _ConferenceRepository = ConferenceRepository;
            _ConferenceTypeRepository = ConferenceTypeRepository;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
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

                MainForm form2 = new MainForm(_GetSpeakerDetail, _ConferenceTypeRepository, _ConferenceRepository, _DictionaryCountryRepository, _DictionaryCountyRepository,_DictionaryConferenceCategoryRepository,var_email);
                form2.Tag = this;
                form2.Show(this);
                this.Hide();
            }
            


        }

        public bool IsValid(string emailBoss)
        {
            Regex check = new Regex(@"^\w+[\w-\.]+\@\w{5}\.[a-z]{2,3}$");
            bool valid;
            valid = check.IsMatch(emailBoss);
            if (valid == true)
                return true;
            else
            {
                EmailLabel.Show();
                return false;
            }
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
    }
}
