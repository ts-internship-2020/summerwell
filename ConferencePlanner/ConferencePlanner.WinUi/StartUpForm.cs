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

namespace ConferencePlanner.WinUi
{
    
    public partial class StartUpForm : Form
    {
        string var_email = "";
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void StartUpForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           bool em=IsValid(EmailBoss.Text);
            if (em==true)
            {

                //MessageBox.Show("Bine ai venit boss");
                //buton ok
                var_email = EmailBoss.Text;
                MessageBox.Show(var_email);
                MainForm form2 = new MainForm();
                form2.Tag = this;
                form2.Show(this);
                this.Hide();
            }


        }

        public bool IsValid(string emailBoss)
        {
            Regex check = new Regex(@"^\w+[\w-\.]+\@\w{5}\.[a-z]{2,3}$");
            bool valid;
            valid = check.IsMatch(emailBoss);
            if (valid == true)
                return true;
            else
            {
                MessageBox.Show("Email gresit boss");
                return false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
