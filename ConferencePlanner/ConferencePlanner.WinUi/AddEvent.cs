using ConferencePlanner.Abstraction.Repository;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConferencePlanner.Abstraction.Model;
using System.Data.SqlClient;
using Accessibility;
using ConferencePlanner.Repository.Ado.Repository;

namespace ConferencePlanner.WinUi
{
    public partial class AddEvent : Form
    { 
        private readonly IConferenceRepository _ConferenceRepository;

        private int totalEntries;
        private int currentOffset;
        private int startingPoint;
        private List<ConferenceDetailModel> x;
        private string currentUser;
        protected string currentConference;
        private string currentType;
        private string currentCategory;
        private string currentAddress;
        private string currentMainSpeaker;
        private DateTime currentStartDate;
        private DateTime currentEndDate;


        public AddEvent(IConferenceRepository ConferenceRepository, 
            string var_email,
            string ConferenceName, 
            string Type, 
            string Category,
            string Address, 
            string MainSpeaker, 
            DateTime StartDate, 
            DateTime EndDate)
        {
            InitializeComponent();

            currentConference = ConferenceName;

            _ConferenceRepository = ConferenceRepository;
            x = _ConferenceRepository.GetConferenceDetail();

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
                AddName.Text = currentConference;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
