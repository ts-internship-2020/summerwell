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
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
