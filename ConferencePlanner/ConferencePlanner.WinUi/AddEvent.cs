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

namespace ConferencePlanner.WinUi
{
    public partial class AddEvent : Form
    {
        string var_email = "";
        
     
        private readonly IConferenceRepository _ConferenceRepository;
        public AddEvent(IConferenceRepository ConferenceRepository, 
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
            if (ConferenceName != null)
            {
                AddConferenceName.Text = ConferenceName;
                AddStartDate.Value = CoferenceStartDate;
                AddEndDate.Value = ConferenceEndDate;
                AddAddress.Text = ConferenceAddress;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
            tabControl1.SelectTab(tabCountry);
           
            

        }
        private void btnNext2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabSpeaker);
           
             
        }
        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCounty);
        
                
        }
        private void btnNext4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCity);
           
                
        }
        private void btnNext5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabCategory);
         
                
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
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext.Enabled = true;
            }
            
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext2.Enabled = true;
            }
            
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext3.Enabled = true;
            }
            
        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext4.Enabled = true;
            }
            
        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count != 0)
            {
                MessageBox.Show("Please Select At least one Column");
                btnNext5.Enabled = true;
            }
       
        }
    }
}
