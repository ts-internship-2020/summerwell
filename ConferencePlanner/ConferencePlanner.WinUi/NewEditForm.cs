using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Model.FromBodyModels;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.ApplicationModel.Activation;
using Windows.Security.EnterpriseData;

namespace ConferencePlanner.WinUi
{
    public partial class NewEditForm : Form
    {
        protected bool EditOrSave = false;
        protected string dictionar;
        protected AddEvent form4;
        protected AddEventDetailModel DetailEvent;
        private readonly IConferenceRepository _ConferenceRepository;
        public NewEditForm(AddEvent f,AddEventDetailModel EventDetail,IConferenceRepository ConferenceRepository, string dictionary, bool EditSave)
        {


            InitializeComponent();
            _ConferenceRepository = ConferenceRepository;
            DetailEvent = EventDetail;
            form4 = f;
            form4.Enabled = false;
            EditOrSave = EditSave;
            dictionar = dictionary;

            if (dictionary.ToString() == "Speaker") { label1.Text = "Email";label3.Visible = true; textBox3.Visible = true; }
            if (dictionary.ToString() == "DictionaryCategory") { label1.Visible = false; textBox1.Visible = false; }
            if (dictionary.ToString() == "DictionaryType") { label1.Visible = false; textBox1.Visible = false; checkBox1.Visible = true; }
            if (EditOrSave)
            {
                if (dictionary.ToString() == "Speaker") { textBox1.Text = DetailEvent.SpeakerEmail; textBox2.Text = EventDetail.SpeakerName ; textBox3.Text = DetailEvent.SpeakerNationality; }
                if (dictionary.ToString() == "DictionaryCategory") { textBox2.Text = EventDetail.DictionaryConferenceCategoryName; }
                if (dictionary.ToString() == "DictionaryType") { textBox2.Text = EventDetail.ConferenceTypeName; checkBox1.Checked = EventDetail.isRemote; }
                if (dictionary.ToString() == "DictionaryCity") { textBox1.Text = EventDetail.DictionaryCityCode; textBox2.Text = EventDetail.DictionaryCityName; }
                if (dictionary.ToString() == "DictionaryCountry") { textBox1.Text = EventDetail.DictionaryCountryCode; textBox2.Text = EventDetail.DictionaryCountryName; }
                if (dictionary.ToString() == "DictionaryCounty") { textBox1.Text = EventDetail.DictionaryCountyCode; textBox2.Text = EventDetail.DictionaryCountyName; }
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
        private async void BtnSave_ClickAsync(object sender, EventArgs e)
        {
            if (EditOrSave == false)
            {
                if (dictionar == "DictionaryCountry")
                {
                    try {
                        AddCountry obj = new AddCountry
                        {
                            Code = textBox1.Text,
                            Name = textBox2.Text
                        }; await AddCountry(obj); }
                    catch
                    {
                        SetBalloonTip("Already Exists", "There is a Country with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }

                    form4.RefreshLists("DictionaryCountry");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "Speaker")
                {
                    try
                    {
                        AddSpeaker obj = new AddSpeaker
                        {
                            Email = textBox1.Text,
                            Name = textBox2.Text,
                            Nationality = textBox3.Text
                        }; await AddSpeaker(obj);

                    }
                    catch
                    {
                        SetBalloonTip("Already Exists", "There is a Speaker with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("Speaker");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCounty")
                {
                    try
                    {
                        AddCounty obj = new AddCounty
                        {
                            Code = textBox1.Text,
                            Name = textBox2.Text,
                            country = textBox3.Text
                        }; await AddCounty(obj);
                    } 
                    catch {
                        SetBalloonTip("Already Exists", "There is a County with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCounty");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCity")
                {
                    try
                    {
                        AddCity obj = new AddCity
                        {
                            Code = textBox1.Text,
                            Name = textBox2.Text,
                            county = DetailEvent.DictionaryCountyId.ToString()
                        }; await AddCity(obj);
                    }
                    catch
                    {
                        SetBalloonTip("Already Exists", "There is a City with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCity");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCategory")
                {
                    try { await AddCategory(textBox2.Text);}
                    catch {
                        SetBalloonTip("Already Exists", "There is a Category with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCategory");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryType")
                {
                    try
                    {
                        AddType obj = new AddType
                        {
                            Name = textBox1.Text,
                            isRemote = checkBox1.Checked
                        }; await AddType(obj);
                    }
                    catch {
                        SetBalloonTip("Already Exists", "There is a Type with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryType");
                    form4.Enabled = true;
                    this.Close();
                }
            }
            else if(EditOrSave == true)
            {
                if (dictionar == "DictionaryCountry")
                {
                    try {
                        EditCountry obj = new EditCountry { 
                            Id = DetailEvent.DictionaryCountryId,
                            Code = textBox1.Text, Name = textBox2.Text 
                        }; await EditCountry(obj);}
                    catch {
                        SetBalloonTip("Already Exists", "There is a Country with this name");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCountry");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "Speaker")
                {
                    try {
                        EditSpeaker obj = new EditSpeaker { Name = textBox2.Text, 
                            Email = textBox1.Text, 
                            Id = DetailEvent.SpeakerId ,
                            Nationality = textBox3.Text};
                        await EditSpeaker(obj); 
                    }
                    catch {
                        SetBalloonTip("Please insert a valid mail", "Invalid Email");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("Speaker");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCounty")
                {
                    try { EditCounty obj = new EditCounty { Name = textBox2.Text, 
                        Code = textBox1.Text,
                        Id = DetailEvent.DictionaryCountyId }; await EditCounty(obj); 
                    }
                    catch {
                        SetBalloonTip("Error", "There was a problem");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCounty");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCity")
                {
                    try
                    {
                        EditCity obj = new EditCity
                        {
                            Name = textBox2.Text,
                            Code = textBox1.Text,
                            Id = DetailEvent.DictionaryCityId};
                        await EditCity(obj);
                    }
                    catch {
                        SetBalloonTip("Error", "There was a problem");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCity");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryCategory")
                {
                    try { EditCategory obj = new EditCategory { id = DetailEvent.DictionaryConferenceCategoryId, 
                        Name = textBox2.Text };
                        await EditCategory(obj); 
                    }
                    catch {
                        SetBalloonTip("Error", "There was a problem");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryCategory");
                    form4.Enabled = true;
                    this.Close();
                }
                else if (dictionar == "DictionaryType")
                {
                    try { EditType obj = new EditType { Name = textBox2.Text,
                        id = DetailEvent.ConferenceTypeId, 
                        isRemote = checkBox1.Checked }; await EditType(obj);
                        }
                    catch {
                        SetBalloonTip("Error", "There was a problem");
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    form4.RefreshLists("DictionaryType");
                    form4.Enabled = true;
                    this.Close();
                }
            }
            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            form4.Enabled = true;
        }
        static async Task AddCategory(string text1)
        {   
            var json = JsonConvert.SerializeObject(text1);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryCategory/AddCategory", httpContent);
        }
        static async Task AddCountry(AddCountry obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/AddCountry", httpContent);
        }
        static async Task AddSpeaker(AddSpeaker obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/Speaker/AddSpeaker", httpContent);
        }
        static async Task AddCounty(AddCounty obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryCounty/AddCounty", httpContent);
        }
        static async Task AddCity(AddCity obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/AddCity", httpContent);
        }
        static async Task AddType(AddType obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryConferenceType/AddType", httpContent);
        }
        static async Task EditCountry(EditCountry obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/EditCountry", httpContent);
        }
        static async Task EditSpeaker(EditSpeaker obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/Speaker/EditSpeaker", httpContent);
        }
        static async Task EditCounty(EditCounty obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryCounty/EditCounty", httpContent);
        }
        static async Task EditCity(EditCity obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/EditCity", httpContent);
        }
        static async Task EditCategory(EditCategory obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryCategory/EditCategory", httpContent);
        }
        static async Task EditType(EditType obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:2794/DictionaryConferenceType/EditType", httpContent);
        }
    }

}
