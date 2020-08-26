using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class JoinConference : Form
    {
        public JoinConference()
        {
            InitializeComponent();
            webView1.Navigate("https://www.google.com");
        }
    }


    
}
