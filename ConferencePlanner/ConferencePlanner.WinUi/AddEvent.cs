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
using Windows.Media.Capture.Core;

namespace ConferencePlanner.WinUi
{
    public partial class AddEvent : Form
    {
        private string var_email = "";
        private int IndexCountry;

        private readonly IDictionaryCountryRepository _DictionaryCountryRepository;
        private readonly IDictionaryConferenceCategoryRepository _DictionaryConferenceCategoryRepository;
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        private IConferenceTypeRepository _ConferenceTypeRepository;
        private readonly IDictionaryCountyRepository _DictionaryCountyRepository;
        private List<ConferenceTypeModel> x;
        public AddEvent(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository,
            IDictionaryCountryRepository DictionaryCountryRepository, IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository,
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
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _ConferenceRepository = ConferenceRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
            List<SpeakerDetailModel> speakers = _GetSpeakerDetail.GetSpeakers();
            List<DictionaryCountryModel> countries = _DictionaryCountryRepository.GetDictionaryCountry();
            List<DictionaryCountyModel> countys = _DictionaryCountyRepository.GetDictionaryCounty();
            List<DictionaryConferenceCategoryModel> categories = _DictionaryConferenceCategoryRepository.GetDictionaryCategory();

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
                    IndexCountry = country.DictionaryCountryId;
                   listView2.Items.Add(new ListViewItem(new string[] { country.DictionaryCountryId.ToString(), country.DictionaryCountryName }));

                }
            }
            if (categories == null) { return; }
            else
            {
                listView6.View = View.Details;
                listView6.FullRowSelect = true;
                listView6.GridLines = true;
                listView6.Columns.Add("DictionaryConferenceCategoryId", -2);
                listView6.Columns.Add("DictionaryConferenceCategoryName", -2);
                foreach (var category in categories)
                {

                    listView6.Items.Add(new ListViewItem(new string[] { category.DictionaryConferenceCategoryId.ToString(), category.DictionaryConferenceCategoryName }));

                }
            }
            if (speakers == null)
            {
                return;
            }

            if (countys == null) { return; }
           
            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Columns.Add("SpeakerName", -2);
            listView3.Columns.Add("Rating", -2);

            listView4.View = View.Details;
            listView4.FullRowSelect = true;
            listView4.GridLines = true;
            listView4.Columns.Add("Id", -2);
            listView4.Columns.Add("County", -2);

           



            foreach (var speaker in speakers)
            { 
                listView3.Items.Add(new ListViewItem(new string[] { speaker.SpeakerName, speaker.Rating }));
                
                
            }
            foreach (var county in countys)
            {

                    if (IndexCountry == county.DictionaryCountyId)
                    {
                        listView4.Items.Add(new ListViewItem(new string[] { county.DictionaryCountyId.ToString(), county.DictionaryCountyName }));
                    }


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
            tabCountry.Enabled = true;
        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabSpeaker);
            tabSpeaker.Enabled = true;
           
             
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCounty);
            tabCounty.Enabled = true;
            tabSpeaker.Enabled = false;
        
                
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCity);
            tabCity.Enabled = true;
           
                
        }
        private void btnNext5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCategory);
            tabCategory.Enabled = true;
         
                
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
                btnNext2.Enabled = true;
            }
            
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                btnNext3.Enabled = true;
            }
            
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count != 0)
            {
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
