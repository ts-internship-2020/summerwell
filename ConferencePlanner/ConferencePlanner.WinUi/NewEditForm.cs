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
        protected AddEventDetailModel DetailEvent;
        private readonly IConferenceRepository _ConferenceRepository;
        public NewEditForm(AddEventDetailModel EventDetail,IConferenceRepository ConferenceRepository, string dictionary, bool EditSave)
        {
            _ConferenceRepository = ConferenceRepository;
            DetailEvent = EventDetail;
            EditOrSave = EditSave;

            InitializeComponent();
            dictionar = dictionary;
            
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (EditOrSave == false )
            {
                if (dictionar == "DictionaryCountry")
                {
                    _ConferenceRepository.AddCountry(textBox1.Text, textBox2.Text);
                    this.Close();
                }
                else if (dictionar == "Speaker")
                {
                    label1.Text = "Email";
                    _ConferenceRepository.AddSpeaker(textBox1.Text, textBox2.Text);
                    label1.Text = "Cod";
                    this.Close();
                }
                else if (dictionar == "DictionaryCounty")
                {
                    _ConferenceRepository.AddCounty(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountryId.ToString());
                    this.Close();
                }
                else if (dictionar == "DictionaryCity")
                {
                    _ConferenceRepository.AddCity(textBox1.Text, textBox2.Text, DetailEvent.DictionaryCountyId.ToString());
                    this.Close();
                }
                else if (dictionar == "DictionaryCategory")
                {
                    _ConferenceRepository.AddCategory(textBox2.Text);
                    this.Close();
                }
                else if (dictionar == "DictionaryType")
                {
                    _ConferenceRepository.AddType(textBox2.Text);
                    this.Close();
                }
                else MessageBox.Show("N-am gasti ecran");
            }
        }
    }
}
