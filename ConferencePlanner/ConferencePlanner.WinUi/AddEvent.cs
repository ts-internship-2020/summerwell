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
using System.Windows.Forms.Design;

namespace ConferencePlanner.WinUi
{
    public partial class AddEvent : Form
    {
        private string var_email = "";

        private readonly IDictionaryCountryRepository _DictionaryCountryRepository;
        private readonly IDictionaryConferenceCategoryRepository _DictionaryConferenceCategoryRepository;
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        private readonly IConferenceTypeRepository _ConferenceTypeRepository;
        private readonly IDictionaryCountyRepository _DictionaryCountyRepository;
        protected AddEvent f;
        private AddEventDetailModel eventDetails;
        private AddConferenceDetailModel AddConferenceDetailModel;
        private readonly IDictionaryCityRepository _DictionaryCityRepository;
        private List<ConferenceTypeModel> x;
        private List<DictionaryCityModel> cityList;
        private List<DictionaryCountyModel> countys;
        string ConferenceName = "";
        DateTime CoferenceStartDate = DateTime.Now;
        DateTime ConferenceEndDate = DateTime.Now;
        string ConferenceAddress = "";
        public AddEvent(AddConferenceDetailModel addConferenceDetailModel, IGetSpeakerDetail GetSpeakerDetail, 
            IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository, 
            IDictionaryCityRepository dictionaryCityRepository, IDictionaryCountryRepository DictionaryCountryRepository, 
            IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository)
        {
           
            InitializeComponent();

            AddConferenceDetailModel = addConferenceDetailModel;
            if (AddConferenceDetailModel != null)
            {
                eventDetails.DictionaryCityName = addConferenceDetailModel.Location;
                eventDetails.ConferenceName = addConferenceDetailModel.ConferenceName;
                eventDetails.ConferenceTypeName = addConferenceDetailModel.ConferenceTypeName;
                eventDetails.EndDate = addConferenceDetailModel.EndDate;
                eventDetails.StartDate = addConferenceDetailModel.StartDate;
                eventDetails.SpeakerName = addConferenceDetailModel.Speaker;
                eventDetails.DictionaryConferenceCategoryName = addConferenceDetailModel.ConferenceCategoryName;
                eventDetails.ConferenceId = addConferenceDetailModel.ConferenceId;
            }
            var_email = AddConferenceDetailModel.HostEmail;

            

            f = this; // Current form to use in New/Edit Form
            eventDetails = new AddEventDetailModel();
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _ConferenceRepository = ConferenceRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
            List<SpeakerDetailModel> speakers = _GetSpeakerDetail.GetSpeakers();
            List<DictionaryCountryModel> countries = _DictionaryCountryRepository.GetDictionaryCountry();
            countys = _DictionaryCountyRepository.GetDictionaryCounty();
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
                populateCountry(countries);
                
            }
            if (categories == null) { return; }
            else
            {
                populateCategory(categories);
            }
            if (speakers == null)
            {
                return;
            }

            if (countys == null) { return; }

            populateSpeakers(speakers);

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

            eventDetails.HostEmail = var_email;
            eventDetails.StartDate = AddStartDate.Value;
            eventDetails.EndDate = AddEndDate.Value;
            
        }

        private void populateCounty(List<DictionaryCountyModel> countys)
        {
            listView4.View = View.Details;
            listView4.FullRowSelect = true;
            listView4.GridLines = true;
            listView4.Columns.Add("Code", -2);
            listView4.Columns.Add("County", -2);
            foreach (var county in countys)
            {
                if (county.DictionaryCountryId == eventDetails.DictionaryCountryId)
                    listView4.Items.Add(new ListViewItem(new string[] { county.Code.ToString(), county.DictionaryCountyName, county.DictionaryCountyId.ToString() }));
            }
        }
        private void populateSpeakers(List<SpeakerDetailModel> speakers)
        {
            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Columns.Add("SpeakerName", -2);
            listView3.Columns.Add("Rating", -2);

            foreach (var speaker in speakers)
            {
                listView3.Items.Add(new ListViewItem(new string[] { speaker.SpeakerName, speaker.Rating, speaker.SpeakerId.ToString() }));
            }
        }
        private void populateCountry(List<DictionaryCountryModel> countries)
        {
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Columns.Add("Code", -2);
            listView2.Columns.Add("CountryName", -2);
            foreach (var country in countries)
            {

                listView2.Items.Add(new ListViewItem(new string[] { country.Code.ToString(), country.DictionaryCountryName, country.DictionaryCountryId.ToString() }));

            }
        }
        private void populateCity(List<DictionaryCityModel> cities)
        {
            listView5.View = View.Details;
            listView5.FullRowSelect = true;
            listView5.GridLines = true;
            listView5.Columns.Add("Code", -2);
            listView5.Columns.Add("CityName", -2);
            foreach (var city in cities)
            {
                if (city.DictionaryCountyId == eventDetails.DictionaryCountyId)
                    listView5.Items.Add(new ListViewItem(new string[] { city.Code, city.Name , city.DictionaryCountyId.ToString() }));

            }
        }
        private void populateCategory(List<DictionaryConferenceCategoryModel> categories)
        {
            listView6.View = View.Details;
            listView6.FullRowSelect = true;
            listView6.GridLines = true;
            listView6.Columns.Add("CategoryId", -2);
            listView6.Columns.Add("CategoryName", -2);
            foreach (var category in categories)
            {

                listView6.Items.Add(new ListViewItem(new string[] { category.DictionaryConferenceCategoryId.ToString(), category.DictionaryConferenceCategoryName }));

            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCountry);
            tabType.Enabled = false;
            tabCountry.Enabled = true;
        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabSpeaker);
            tabSpeaker.Enabled = true;
            tabCountry.Enabled = false;
            populateCounty(_DictionaryCountyRepository.GetDictionaryCounty());


        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCounty);
            tabCounty.Enabled = true;
            tabSpeaker.Enabled = false;
        
                
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            //listView5_populate();
            populateCity(_DictionaryCityRepository.GetCity());
            tabControl1.SelectTab(tabCity);
            tabCity.Enabled = true;
            tabCounty.Enabled = false;
        }
        private void btnNext5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCategory);
            tabCategory.Enabled = true;
            tabCity.Enabled = false;
         
                
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            eventDetails.ConferenceName = AddConferenceName.Text;
            eventDetails.StartDate = AddStartDate.Value;
            eventDetails.EndDate = AddEndDate.Value;
            _ConferenceRepository.AddConference(eventDetails);
            this.Close();
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
                eventDetails.DictionaryCountryCode = selectedItem.SubItems[0].Text;
                eventDetails.DictionaryCountryName = selectedItem.SubItems[1].Text;
                eventDetails.DictionaryCountryId = Int32.Parse(selectedItem.SubItems[2].Text);
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
                eventDetails.SpeakerId = Int32.Parse(selectedItem.SubItems[2].Text);
                btnNext3.Enabled = true;
            }

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView4.SelectedItems[0];
                eventDetails.DictionaryCountyCode = selectedItem.SubItems[0].Text;
                eventDetails.DictionaryCountyName = selectedItem.SubItems[1].Text;
                eventDetails.DictionaryCountyId = Int32.Parse(selectedItem.SubItems[2].Text);
                btnNext4.Enabled = true;
            }
            
        }
        //bunasiuaaaaaaaaa
        private void PopulateListView ()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Code");
            listView1.Columns.Add("Country Name");
           
        }//aseurarejrwe
        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView5.SelectedItems[0];
                eventDetails.DictionaryCityCode = selectedItem.SubItems[0].Text;
                eventDetails.DictionaryCityName = selectedItem.SubItems[1].Text;
                btnNext5.Enabled = true;
            }
                
        }
        private void listView5_populate()
        {
            listView5.View = View.Details;
            listView5.Columns.Add("Code");
            listView5.Columns.Add("Name");
            int save_county = 0;
            foreach (var ind in countys)
                if (ind.DictionaryCountyId.Equals(eventDetails.DictionaryCountyId))
                    save_county = ind.DictionaryCountyId;
            foreach (var c in cityList)
            {
                if(c.DictionaryCountyId == save_county)
                    listView5.Items.Add(new ListViewItem(new string[] { c.Code.ToString(), c.Name }));
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
        private void EditType_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails,_ConferenceRepository,"DictionaryType",true);
            form5.Show();
        }
        private void EditCountry_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCountry", true);
            form5.Show();
        }
        private void EditCounty_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCounty", true);
            form5.Show();
        }
        private void EditSpeaker_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"Speaker", true);
            form5.Show();
        }
        private void EditCity_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCity", true);
            form5.Show();
        }
        private void EditCategory_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCategory", true);
            form5.Show();
        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryType", false);
            form5.Show();
        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCountry", false);
            form5.Show();
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"Speaker", false);
            form5.Show();
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCity", false);
            form5.Show();
        }
        private void btnAdd5_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCounty", false);
            form5.Show();
        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f,eventDetails, _ConferenceRepository,"DictionaryCategory", false);
            form5.Show();
        }
        public void RefreshLists(string dictionary) 
        {
            if (dictionary == "DictionaryCounty") { listView4.Clear(); populateCounty(_DictionaryCountyRepository.GetDictionaryCounty());}
            else if (dictionary == "DictionaryCity") { listView5.Clear(); populateCity(_DictionaryCityRepository.GetCity()); }
            else if (dictionary == "DictionaryType") { listView1.Clear(); listView1_populate(); }
            else if (dictionary == "Speaker") { listView3.Clear();  populateSpeakers(_GetSpeakerDetail.GetSpeakers()); }
            else if (dictionary == "DictionaryCountry") { listView2.Clear(); populateCountry(_DictionaryCountryRepository.GetDictionaryCountry()); }
            else if (dictionary == "DictionaryCategory") { listView6.Clear();populateCategory(_DictionaryConferenceCategoryRepository.GetDictionaryCategory()); }
        }
    }
}
