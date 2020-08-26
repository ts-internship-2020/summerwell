using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class NewEditForm : Form
    {
        protected int EditOrSave = 1;
        public NewEditForm(string dictionary,string cod, string name)
        {

            InitializeComponent();
            if(cod!=null && name!= null && name!= "")
            {
                textBox1.Text = cod;
                textBox2.Text = name;
                try { int x = Int32.Parse(cod); textBox1.Enabled = false; }
                catch { }
                EditOrSave = 0;
            }
            
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
