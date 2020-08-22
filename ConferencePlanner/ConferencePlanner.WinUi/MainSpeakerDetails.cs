using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConferencePlanner.WinUi
{
    public partial class MainSpeakerDetails : Form
    {
        public MainSpeakerDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {   /*
            if(textBox7.Text!="")
            { 
            SqlCommand cmd = new SqlCommand("Select Rating,Nationality from Speaker");
            cmd.Parameters.AddWithValue("@Rating", string.Parse(textBox7.Text));
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                textBox8.Text = da.GetValue(0).ToString();
                //textBox9.Text = da.GetValue(1).ToString();
            }
            }
            */
        }
            
    }
}
