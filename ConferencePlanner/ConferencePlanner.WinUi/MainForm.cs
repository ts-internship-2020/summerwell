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

namespace ConferencePlanner.WinUi
{
    public partial class MainForm : Form
    {
        private readonly IConferenceRepository _ConferenceRepository;
        public MainForm(IConferenceRepository ConferenceRepository)
        {
            InitializeComponent();
            _ConferenceRepository = ConferenceRepository;
            var x = _ConferenceRepository.GetConferenceDetail();
            if (x == null || x.Count() == 0)
            {
                return;
            }
                
            foreach(var c in x)
            {
                ConferenceGrid.Rows.Add(c.ConferenceName, c.StartDate,
                                        c.DictionaryConferenceTypeName,
                                        c.DictionaryConferenceCategoryName,
                                        c.DictionaryCityName,
                                        c.SpeakerName);
            }
            
        }
    }
}
