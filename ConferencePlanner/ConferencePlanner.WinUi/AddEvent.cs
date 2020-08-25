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
using System.Linq;
using ConferencePlanner.Abstraction.Model;

namespace ConferencePlanner.WinUi
{
    public partial class AddEvent : Form
    {
        private string var_email = "";

        private readonly IDictionaryCountryRepository _DictionaryCountryRepository;
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        private IConferenceTypeRepository _ConferenceTypeRepository;
        private List<ConferenceTypeModel> x;
        public AddEvent(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository,
            IDictionaryCountryRepository DictionaryCountryRepository,
            string var_email,
            string ConferenceName,
            string ConferenceType,
            string ConferenceCategory,
            string ConferenceAddress,
            string ConferenceMainSpeaker,
            DateTime CoferenceStartDate,
            DateTime ConferenceEndDate
            )
        {
            InitializeComponent();
            _GetSpeakerDetail = GetSpeakerDetail;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _ConferenceRepository = ConferenceRepository;
            List<SpeakerDetailModel> speakers = _GetSpeakerDetail.GetSpeakers();
            List<DictionaryCountryModel> countries = _DictionaryCountryRepository.GetDictionaryCountry();
            if (ConferenceName != null)
            {
                AddConferenceName.Text = ConferenceName;
                AddStartDate.Value = CoferenceStartDate;
                AddEndDate.Value = ConferenceEndDate;
                AddAddress.Text = ConferenceAddress;
            }
            if (countries == null) { return; }
            else
            {
                listView2.View = View.Details;
                listView2.FullRowSelect = true;
                listView2.GridLines = true;
                listView2.Columns.Add("DictionaryCountryId", -2);
                listView2.Columns.Add("DictionaryCountryCity", -2);
                foreach (var country in countries)
                {
                   
                   listView2.Items.Add(new ListViewItem(new string[] { country.DictionaryCountryId.ToString(), country.DictionaryCountryName }));

                }
            }
            if (speakers == null)
            {
                return;
            }
           
            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Columns.Add("SpeakerName", -2);
            listView3.Columns.Add("Rating", -2);
            foreach (var speaker in speakers)
            { 
                listView3.Items.Add(new ListViewItem(new string[] { speaker.SpeakerName, speaker.Rating }));
                
                
            }
            
            
        


            _ConferenceTypeRepository = ConferenceTypeRepository;
            x = _ConferenceTypeRepository.GetConferenceType();
            if (x == null || x.Count() == 0)
            {
                return;
            }
            listView1_populate();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCountry);  
        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabSpeaker);
           
             
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCounty);
        
                
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCity);
           
                
        }
        private void btnNext5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCategory);
         
                
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                btnNext.Enabled = true;
        }

        private void listView1_populate()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Code");
            listView1.Columns.Add("Name");
            foreach (var c in x)
            {
                listView1.Items.Add(new ListViewItem(new string[] { c.ConferenceTypeId.ToString(), c.Name }));
            }
            listView1.GridLines = true;
            btnNext.Enabled = false;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                //btnNext2.Enabled = true;
            }
            
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
               // btnNext3.Enabled = true;
            }
            
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext4.Enabled = true;
            }
            
        }

        private void PopulateListView ()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Country Id");
            listView1.Columns.Add("Country Name");
           
        }
        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext5.Enabled = true;
            }
       
        }

        private void tabType_Click(object sender, EventArgs e)
        {

        }
    }
}
