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
        private List<ConferenceModel> conferences;
        private List<ConferenceTypeModel> x;
        private List<DictionaryCityModel> cityList;
        private List<DictionaryCountyModel> countys;
        private List<LocationModel> location;
        protected MainForm formMain;
        int EditNew = 0;
        public AddEvent(int editnew,MainForm form,AddConferenceDetailModel addConferenceDetailModel, IGetSpeakerDetail GetSpeakerDetail,
            IConferenceTypeRepository ConferenceTypeRepository, IConferenceRepository ConferenceRepository,
            IDictionaryCityRepository dictionaryCityRepository, IDictionaryCountryRepository DictionaryCountryRepository,
            IDictionaryCountyRepository DictionaryCountyRepository, IDictionaryConferenceCategoryRepository DictionaryConferenceCategoryRepository,
            ILocationRepository locationRepository)
        {
            
            InitializeComponent();
            tabType.Hide();
            EditNew = editnew;

            AddConferenceDetailModel = new AddConferenceDetailModel();
            AddConferenceDetailModel = addConferenceDetailModel;

            eventDetails = new AddEventDetailModel();


            var_email = AddConferenceDetailModel.HostEmail;
            formMain = form;
            f = this; // Current form to use in New/Edit Form
            _DictionaryCountyRepository = DictionaryCountyRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            _DictionaryCountryRepository = DictionaryCountryRepository;
            _ConferenceRepository = ConferenceRepository;
            _DictionaryConferenceCategoryRepository = DictionaryConferenceCategoryRepository;
            List<SpeakerDetailModel> speakers = _GetSpeakerDetail.GetSpeakers();
            List<DictionaryCountryModel> countries = _DictionaryCountryRepository.GetDictionaryCountry();
            countys = _DictionaryCountyRepository.GetDictionaryCounty();
            List<DictionaryConferenceCategoryModel> categories = _DictionaryConferenceCategoryRepository.GetDictionaryCategory();
            _ConferenceTypeRepository = ConferenceTypeRepository;
            x = _ConferenceTypeRepository.GetConferenceType();
            conferences = _ConferenceRepository.GetConference();
            location = locationRepository.GetLocation();

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
            if (cityList == null || cityList.Count() == 0)
            {
                return;
            }

            
            if (x == null || x.Count() == 0)
            {
                return;
            }
            listView1_populate();

            eventDetails.HostEmail = var_email;
            eventDetails.StartDate = AddStartDate.Value;
            eventDetails.EndDate = AddEndDate.Value;

            if (editnew == 0)
            {
                //eventDetails.DictionaryCountryName = addConferenceDetailModel.CountryName;
                //eventDetails.DictionaryCountryName = addConferenceDetailModel.CountyName;
                eventDetails.DictionaryCityName = addConferenceDetailModel.Location;
                int locationid;
                foreach ( var c in conferences)
                {
                    if (c.ConferenceId == eventDetails.ConferenceId)
                        locationid = c.LocationId;
                }
                foreach (var c in loca)
                {
                    if(eventDetails.DictionaryCityId == c.DictionaryCountyId)
                    {
                        eventDetails.DictionaryCountyName = c.DictionaryCountyName;
                        eventDetails.DictionaryCountyCode = c.Code;
                        eventDetails.DictionaryCountryId = c.DictionaryCountryId;
                    }
                }
                foreach(var c in countries)
                {
                    if (eventDetails.DictionaryCountryId == c.DictionaryCountryId)
                    {
                        eventDetails.DictionaryCountryName = c.DictionaryCountryName;
                        eventDetails.DictionaryCountryCode = c.Code;
                    }
                }
                eventDetails.ConferenceName = addConferenceDetailModel.ConferenceName;
                eventDetails.ConferenceTypeName = addConferenceDetailModel.ConferenceTypeName;
                eventDetails.EndDate = addConferenceDetailModel.EndDate;
                eventDetails.StartDate = addConferenceDetailModel.StartDate;
                eventDetails.SpeakerName = addConferenceDetailModel.Speaker;
                eventDetails.DictionaryConferenceCategoryName = addConferenceDetailModel.ConferenceCategoryName;
                eventDetails.ConferenceId = addConferenceDetailModel.ConferenceId;
                eventDetails.LocationName = addConferenceDetailModel.Location;

                AddConferenceName.Text = eventDetails.ConferenceName;
                AddAddress.Text = eventDetails.LocationName;
                AddStartDate.Value = eventDetails.StartDate;
                AddEndDate.Value = eventDetails.EndDate;
                ToSelectItem();
            }
        }

        void ToSelectItem()
        {
            foreach (ListViewItem item in listView1.Items)
                if (item.SubItems[1].Text == eventDetails.ConferenceTypeName)
                {
                    listView1.Items[item.Index].Selected = true;
                    listView1.Select();
                    break;
                }

            MessageBox.Show(eventDetails.DictionaryCountryName);
            foreach (ListViewItem item in listView2.Items)
                if (item.SubItems[1].Text == eventDetails.DictionaryCountryName)
                {
                    MessageBox.Show(item.SubItems[1].Text);
                    listView2.Items[item.Index].Selected = true;
                    listView2.Select();
                    break;
                }

            foreach (ListViewItem item in listView3.Items)
                if (item.SubItems[1].Text == eventDetails.SpeakerName)
                {
                    listView3.Items[item.Index].Selected = true;
                    listView3.Select();
                    break;
                }
        }
        private void SetBalloonTip(string title, string text)
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.Visible = false;
        }

        private void populateCounty(List<DictionaryCountyModel> countys)
        {
            listView4.View = View.Details;
            listView4.FullRowSelect = true;
            listView4.GridLines = true;
            listView4.Columns.Add("Code");
            listView4.Columns.Add("County");
            foreach (var county in countys)
            {
                if (county.DictionaryCountryId == eventDetails.DictionaryCountryId)
                {
                    listView4.Items.Add(new ListViewItem(new string[] { county.Code.ToString(), county.DictionaryCountyName, county.DictionaryCountyId.ToString() }));
                
                }
            }
            DeleteCounty.Enabled = false;
            btnNext4.Enabled = false;
        }
        private void populateSpeakers(List<SpeakerDetailModel> speakers)
        {
            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.GridLines = true;
            listView3.Columns.Add("SpeakerName");
            listView3.Columns.Add("Rating");
            listView3.Columns.Add("Nationality");
            foreach (var speaker in speakers)
            {
                if(speaker.SpeakerId != 30)
                    listView3.Items.Add(new ListViewItem(new string[] { speaker.SpeakerName, speaker.Rating, speaker.Nationality, speaker.SpeakerId.ToString(),speaker.SpeakerEmail }));
            }
            DeleteSpeaker.Enabled = false;
            btnNext3.Enabled = false;
        }
        private void populateCountry(List<DictionaryCountryModel> countries)
        {
            listView2.View = View.Details;
            
            
            listView2.Columns.Add("Code");
            listView2.Columns.Add("CountryName");
            foreach (var country in countries)
            {
                if(country.DictionaryCountryId.ToString() != "32" && country.DictionaryCountryId.ToString() != "33")
                    listView2.Items.Add(new ListViewItem(new string[] { country.Code.ToString(), country.DictionaryCountryName, country.DictionaryCountryId.ToString() }));

            }
            listView2.GridLines = true;
            DeleteCountry.Enabled = false;
            btnNext2.Enabled = false;
        }
        private void populateCity(List<DictionaryCityModel> cities)
        {
            listView5.View = View.Details;
            listView5.FullRowSelect = true;
            listView5.GridLines = true;
            listView5.Columns.Add("Code");
            listView5.Columns.Add("CityName");
            foreach (var city in cities)
            {
                if (city.DictionaryCountyId == eventDetails.DictionaryCountyId)
                    listView5.Items.Add(new ListViewItem(new string[] { city.Code, city.Name , city.DictionaryCountyId.ToString(), city.DictionaryCityId.ToString() }));

            }
            DeleteCity.Enabled = false;
            btnNext5.Enabled = false;
        }
        private void populateCategory(List<DictionaryConferenceCategoryModel> categories)
        {
            listView6.View = View.Details;
            listView6.FullRowSelect = true;
            listView6.GridLines = true;
            listView6.Columns.Add("CategoryId");
            listView6.Columns.Add("CategoryName");
            foreach (var category in categories)
            {
                if(category.DictionaryConferenceCategoryId != 1)
                    listView6.Items.Add(new ListViewItem(new string[] { category.DictionaryConferenceCategoryId.ToString(), category.DictionaryConferenceCategoryName }));

            }
            DeleteCategory.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Visible = false;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!eventDetails.isRemote)
            {
                tabControl1.SelectTab(tabCountry);
                tabType.Enabled = false;
                tabCountry.Enabled = true; 
            }
            else
            {
                tabControl1.SelectTab(tabSpeaker);
                tabSpeaker.Enabled = true;
                tabCountry.Enabled = false;
                tabType.Enabled = false;
            }
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
            if (!eventDetails.isRemote)
            {
                tabControl1.SelectTab(tabCounty);
                tabCounty.Enabled = true;
                tabSpeaker.Enabled = false;
            }
            else
            {
                tabControl1.SelectTab(tabCategory);
                tabSpeaker.Enabled = false;
                tabCounty.Enabled = false;
                tabCity.Enabled = false;
                tabCategory.Enabled = true;
            }


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
            if(!eventDetails.isRemote) { AddAddress.Visible = true; label4.Visible = true; }
            tabControl1.SelectTab(tabCategory);
            tabCategory.Enabled = true;
            tabCity.Enabled = false;


        }
        private void btnSave_Click(object sender, EventArgs e)
        { if (AddStartDate.Value < System.DateTime.Now) { SetBalloonTip("Invalid Start Date", "Please select a Start Date after current date");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
            else if (AddEndDate.Value < AddStartDate.Value) { SetBalloonTip("Invalid End Date", "Please select a End Date after Start Date");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
            else if (AddConferenceName.Text == "" || AddConferenceName.Text == null) { SetBalloonTip("Please don't leave the Name empty", "Please enter a name for the conference");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
            else
            {
                try
                {
                    if (EditNew == 1)
                    {
                        eventDetails.ConferenceName = AddConferenceName.Text;
                        eventDetails.LocationName = AddAddress.Text;
                        eventDetails.StartDate = AddStartDate.Value;
                        eventDetails.EndDate = AddEndDate.Value;
                        _ConferenceRepository.AddConference(eventDetails);
                    }
                    else
                    {
                        eventDetails.StartDate = AddStartDate.Value;
                        eventDetails.EndDate = AddEndDate.Value;
                        _ConferenceRepository.EditConference(eventDetails, AddAddress.Text, AddConferenceName.Text);
                    }

                    string message = "Do you want a new Conference?";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                        formMain.AddEventNotEdit();
                    }
                    this.Close();
                }
                catch
                {
                    SetBalloonTip("Invalid entry", "Please enter a valid entry");
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(3000);
                }
            }
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
                eventDetails.isRemote = bool.Parse(selectedItem.SubItems[2].Text);
                DeleteType.Enabled = true;
                btnNext.Enabled = true;
                DeleteType.Enabled = true;
            }
        }

        private void listView1_populate()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Code");
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Is Remote");
            x.Clear();
            x = _ConferenceTypeRepository.GetConferenceType();
            foreach (var c in x)
            {
                if(c.ConferenceTypeId.ToString() != "30" && c.ConferenceTypeId.ToString() != "31")
                    listView1.Items.Add(new ListViewItem(new string[] { c.ConferenceTypeId.ToString(), c.Name, c.IsRemote.ToString() }));
            }
            listView1.GridLines = true;
            btnNext.Enabled = false;
            DeleteType.Enabled = false;
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = listView2.SelectedItems[0];
                eventDetails.DictionaryCountryCode = selectedItem.SubItems[0].Text;
                eventDetails.DictionaryCountryName = selectedItem.SubItems[1].Text;
                eventDetails.DictionaryCountryId = Int32.Parse(selectedItem.SubItems[2].Text);
                DeleteCountry.Enabled = true;
                btnNext2.Enabled = true;
                DeleteCountry.Enabled = true;
            }

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {

                ListViewItem selectedItem = listView3.SelectedItems[0];
                eventDetails.SpeakerName = selectedItem.SubItems[0].Text;
                eventDetails.SpeakerRating = selectedItem.SubItems[1].Text;
                eventDetails.SpeakerNationality = selectedItem.SubItems[2].Text;
                eventDetails.SpeakerId = Int32.Parse(selectedItem.SubItems[3].Text);
                eventDetails.SpeakerEmail = selectedItem.SubItems[4].Text;
                DeleteSpeaker.Enabled = true;
                btnNext3.Enabled = true;
                DeleteSpeaker.Enabled = true;
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
                DeleteCounty.Enabled = true;
                btnNext4.Enabled = true;
                DeleteCounty.Enabled = true;
            }

        }
        //bunasiuaaaaaaaaa
        private void PopulateListView()
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
                eventDetails.DictionaryCityId = Int32.Parse(selectedItem.SubItems[3].Text);
                DeleteCity.Enabled = true;
                btnNext5.Enabled = true;
                DeleteCity.Enabled = true;
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
                if (c.DictionaryCountyId == save_county)
                    listView5.Items.Add(new ListViewItem(new string[] { c.Code.ToString(), c.Name }));
            }
            listView5.GridLines = true;
            btnNext5.Enabled = false;
            DeleteCountry.Enabled = false;
        }
        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView6.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView6.SelectedItems[0];
                eventDetails.DictionaryConferenceCategoryId = Int32.Parse(selectedItem.SubItems[0].Text);
                eventDetails.DictionaryConferenceCategoryName = selectedItem.SubItems[1].Text;
                DeleteCategory.Enabled = true;
                btnSave.Visible = true;

            }
            DeleteCategory.Enabled = true;
            btnSave.Enabled = true;
            btnSave.Visible = true;

        }

        private void tabType_Click(object sender, EventArgs e)
        {

        }
        private void EditType_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryType", true);
            form5.Show();
        }
        private void EditCountry_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCountry", true);
            form5.Show();
        }
        private void EditCounty_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCounty", true);
            form5.Show();
        }
        private void EditSpeaker_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "Speaker", true);
            form5.Show();
        }
        private void EditCity_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCity", true);
            form5.Show();
        }
        private void EditCategory_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCategory", true);
            form5.Show();
        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryType", false);
            form5.Show();
        }
        private void btnAdd2_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCountry", false);
            form5.Show();
        }
        private void btnAdd3_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "Speaker", false);
            form5.Show();
        }
        private void btnAdd4_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCity", false);
            form5.Show();
        }
        private void btnAdd5_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCounty", false);
            form5.Show();
        }
        private void btnAdd6_Click(object sender, EventArgs e)
        {
            NewEditForm form5 = new NewEditForm(f, eventDetails, _ConferenceRepository, "DictionaryCategory", false);
            form5.Show();
        }
        public void RefreshLists(string dictionary)
        {
            if (dictionary == "DictionaryCounty") { listView4.Clear(); populateCounty(_DictionaryCountyRepository.GetDictionaryCounty()); }
            if (dictionary == "DictionaryCity") { listView5.Clear(); populateCity(_DictionaryCityRepository.GetCity()); }
            if (dictionary == "DictionaryType") { listView1.Clear(); listView1_populate(); }
            if (dictionary == "Speaker") { listView3.Clear(); populateSpeakers(_GetSpeakerDetail.GetSpeakers()); }
            if (dictionary == "DictionaryCountry") { listView2.Clear(); populateCountry(_DictionaryCountryRepository.GetDictionaryCountry()); }
            if (dictionary == "DictionaryCategory") { listView6.Clear(); populateCategory(_DictionaryConferenceCategoryRepository.GetDictionaryCategory()); }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            formMain.Enabled = true;
            formMain.PopulateMamam();
        }

       

        private void tabType_Click_1(object sender, EventArgs e)
        {

        }
        private void DeleteType_Click(object sender, EventArgs e)
        {
            
            bool hey =_ConferenceRepository.DeleteType(eventDetails.ConferenceTypeId, eventDetails.isRemote);
            if (!hey)
            {
                SetBalloonTip("You can't delete this","There is a conference with this type");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
            RefreshLists("DictionaryType");
            DeleteType.Enabled = false;
            btnNext.Enabled = false;
        }

        private void DeleteSpeaker_Click(object sender, EventArgs e)
        {
            _ConferenceRepository.DeleteSpeaker(eventDetails.SpeakerId);
            RefreshLists("Speaker");
            DeleteSpeaker.Enabled = false;
            btnNext3.Enabled = false;
        }

        private void DeleteCounty_Click(object sender, EventArgs e)
        {
            _ConferenceRepository.DeleteCounty(eventDetails.DictionaryCountyId, eventDetails.isRemote);
            RefreshLists("DictionaryCounty");
            DeleteCounty.Enabled = false;
            btnNext4.Enabled = false;
        }

        private void DeleteCity_Click(object sender, EventArgs e)
        {
            _ConferenceRepository.DeleteCity(eventDetails.DictionaryCityId, eventDetails.isRemote);
            RefreshLists("DictionaryCity");
            DeleteCity.Enabled = false;
            btnNext5.Enabled = false;
        }

        private void DeleteCategory_Click(object sender, EventArgs e)
        {
            bool hey =_ConferenceRepository.DeleteCategory(eventDetails.DictionaryConferenceCategoryId);
            if (!hey)
            {
                SetBalloonTip("You can't delete this", "There are conferences in this category");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
            RefreshLists("DictionaryCategory");
            DeleteCategory.Enabled = false;
            btnSave.Visible = false;
        }

        private void DeleteCountry_Click(object sender, EventArgs e)
        {
            _ConferenceRepository.DeleteCountry(eventDetails.DictionaryCountryId, eventDetails.isRemote);
            RefreshLists("DictionaryCountry");
            DeleteCountry.Enabled = false;
            btnNext2.Enabled = false;
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
                tabControl1.SelectTab(tabType);
                tabType.Enabled = true;
                tabCountry.Enabled = false;
        }
        private void btnBack3_Click(object sender, EventArgs e)
        {

        }
        private void btnBack4_Click(object sender, EventArgs e)
        {

        }
        private void btnBack5_Click(object sender, EventArgs e)
        {

        }
        private void btnBack6_Click(object sender, EventArgs e)
        {

        }
    }
}
