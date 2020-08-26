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
using ConferencePlanner.Repository.Ado.Repository;

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
        private readonly IConferenceTypeRepository _ConferenceTypeRepository;
        private readonly IDictionaryCountyRepository _DictionaryCountyRepository;
        private AddEventDetailModel eventDetails;
        private readonly IDictionaryCityRepository _DictionaryCityRepository;
        private List<ConferenceTypeModel> x;
        private List<DictionaryCityModel> cityList;
        private string selectedCounty;
        public AddEvent(IGetSpeakerDetail GetSpeakerDetail, IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository, IDictionaryCityRepository dictionaryCityRepository,
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
            eventDetails = new AddEventDetailModel();
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
                listView2.Columns.Add("DictionaryCountryName", -2);
                foreach (var country in countries)
                {
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
                        listView4.Items.Add(new ListViewItem(new string[] { county.DictionaryCountyId.ToString(), county.DictionaryCountyName }));

            }

            _DictionaryCityRepository = dictionaryCityRepository;
            cityList = _DictionaryCityRepository.GetCity();
            if(cityList == null || cityList.Count() == 0)
            {
                return;
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
            selectedCounty = listView4.SelectedItems[0].Text;
            listView5_populate();
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
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                eventDetails.ConferenceTypeId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.ConferenceTypeName = selectedItem.SubItems[1].Text;
                btnNext.Enabled = true;
            }
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
            if (listView2.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = listView2.SelectedItems[0];
                eventDetails.DictionaryCountryId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.DictionaryCountryCity = selectedItem.SubItems[1].Text;
                btnNext2.Enabled = true;
            }
            
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = listView3.SelectedItems[0];
                eventDetails.SpeakerName = selectedItem.SubItems[0].Text;
                eventDetails.SpeakerRating = selectedItem.SubItems[1].Text;
                btnNext3.Enabled = true;
            }

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView4.SelectedItems[0];
                eventDetails.DictionaryCountyId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.DictionaryCountyName = selectedItem.SubItems[1].Text;
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
            if (listView5.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView5.SelectedItems[0];
                eventDetails.DictionaryCityId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.DictionaryCityName = selectedItem.SubItems[1].Text;
                btnNext5.Enabled = true;
            }
                
        }

        private void listView5_populate()
        {
            listView5.View = View.Details;
            listView5.Columns.Add("Code");
            listView5.Columns.Add("Name");
            foreach (var c in cityList)
            {
                if(selectedCounty !=null && c.DictionaryCountyId.ToString().Equals(selectedCounty))
                    listView5.Items.Add(new ListViewItem(new string[] { c.DictionaryCityId.ToString(), c.Name }));
            }
            listView5.GridLines = true;
            btnNext5.Enabled = false;
        }
        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView6.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView6.SelectedItems[0];
                eventDetails.DictionaryConferenceCategoryId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.DictionaryConferenceCategoryName = selectedItem.SubItems[1].Text;
                btnSave.Visible = true;
                
            }

        }

        private void tabType_Click(object sender, EventArgs e)
        {

        }
    }
}
