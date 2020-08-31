using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ado.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (EditOrSave == false)
            {
                if (dictionar == "DictionaryCountry")
                {
                    try { _ConferenceRepository.AddCountry(textBox1.Text, textBox2.Text); }
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
                    try { _ConferenceRepository.AddSpeaker(textBox1.Text, textBox2.Text, textBox3.Text); }
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
                    try { _ConferenceRepository.AddCounty(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountryId.ToString()); }
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
                    try { _ConferenceRepository.AddCity(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountyId.ToString()); }
                    catch {
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
                    try { _ConferenceRepository.AddCategory(textBox2.Text); }
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
                    try { _ConferenceRepository.AddType(textBox2.Text, checkBox1.Checked); }
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
                    try { _ConferenceRepository.EditCountry(DetailEvent.DictionaryCountryId, textBox1.Text, textBox2.Text);  }
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
                    try { _ConferenceRepository.EditSpeaker(textBox1.Text, textBox2.Text, DetailEvent.SpeakerId, textBox3.Text); }
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
                    try { _ConferenceRepository.EditCounty(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountyId); }
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
                    try { _ConferenceRepository.EditCity(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCityId); }
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
                    try { _ConferenceRepository.EditCategory(DetailEvent.DictionaryConferenceCategoryId, textBox2.Text); }
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
                    try { _ConferenceRepository.EditType(DetailEvent.ConferenceTypeId, textBox2.Text, checkBox1.Checked); }
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
    }
}
