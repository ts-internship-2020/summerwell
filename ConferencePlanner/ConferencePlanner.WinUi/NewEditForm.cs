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
            _ConferenceRepository = ConferenceRepository;
            DetailEvent = EventDetail;
            form4 = f;
            EditOrSave = EditSave;
            if(dictionary == "Speaker") label1.Text = "Email";

            InitializeComponent();
            dictionar = dictionary;
            
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (EditOrSave == false )
            {
                if (dictionar == "DictionaryCountry")
                {
                    try { _ConferenceRepository.AddCountry(textBox1.Text, textBox2.Text); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("DictionaryCountry");
                    this.Close();
                }
                else if (dictionar == "Speaker")
                {
                    try { _ConferenceRepository.AddSpeaker(textBox1.Text, textBox2.Text); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("Speaker");
                    this.Close();
                }
                else if (dictionar == "DictionaryCounty")
                {
                    try { _ConferenceRepository.AddCounty(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountryId.ToString()); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("DictionaryCounty");
                    this.Close();
                }
                else if (dictionar == "DictionaryCity")
                {
                    try { _ConferenceRepository.AddCity(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountyId.ToString()); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("DictionaryCity");
                    this.Close();
                }
                else if (dictionar == "DictionaryCategory")
                {
                    try { _ConferenceRepository.AddCategory(textBox2.Text); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("DictionaryCategory");
                    this.Close();
                }
                else if (dictionar == "DictionaryType")
                {
                    try { _ConferenceRepository.AddType(textBox2.Text); }
                    catch { MessageBox.Show("Already Exists"); }
                    form4.RefreshLists("DictionaryType");
                    this.Close();
                }
                else
                {
                    if (dictionar == "DictionaryCountry")
                    {
                        try { _ConferenceRepository.EditCountry(textBox1.Text, textBox2.Text); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                    else if (dictionar == "Speaker")
                    {
                        try { _ConferenceRepository.EditSpeaker(textBox1.Text, textBox2.Text); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                    else if (dictionar == "DictionaryCounty")
                    {
                        try { _ConferenceRepository.EditCounty(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountryId.ToString()); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                    else if (dictionar == "DictionaryCity")
                    {
                        try { _ConferenceRepository.EditCity(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountyId.ToString()); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                    else if (dictionar == "DictionaryCategory")
                    {
                        try { _ConferenceRepository.EditCategory(textBox2.Text); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                    else if (dictionar == "DictionaryType")
                    {
                        try { _ConferenceRepository.EditType(textBox2.Text); }
                        catch { MessageBox.Show("Something's wrong"); }
                        this.Close();
                    }
                }
            }
        }
    }
}
