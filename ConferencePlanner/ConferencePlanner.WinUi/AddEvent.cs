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

            currentUser = var_email;

            AddName.Text = ConferenceName;
            AddType.SelectedItem = Type;
            AddCategory.SelectedItem = Category;
            AddMainSpeaker.SelectedItem = MainSpeaker;
            AddStartDate.Value = StartDate;
            AddEndDate.Value = EndDate;
            if (ConferenceName != null) { btnEdit.Visible = true; }
            else btnAdd.Visible = true;
            


            _ConferenceRepository = ConferenceRepository;
            x = _ConferenceRepository.GetConferenceDetail();

            
        }

        private void Form3_Activated(object sender, System.EventArgs e)
        {
            AddName.Text = "string";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }
        private void btnNext1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }
        private void btnNext5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage8");
        }
        private void btnNext6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage9");
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage1");
        }
        private void btnBack3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage2");
        }
        private void btnBack4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage3");
        }
        private void btnBack5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage6");
        }
        private void btnBack6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage7");
        }
        private void btnBack7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage8");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void AddMainSpeaker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage4");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage7");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("tabPage5");
        }
    }
}
