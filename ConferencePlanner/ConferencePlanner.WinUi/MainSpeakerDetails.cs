using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Windows.ApplicationModel.Preview.Notes;

namespace ConferencePlanner.WinUi
{
    public partial class MainSpeakerDetails : Form
    {
        private readonly IConferenceRepository _ConferenceRepository;
        private readonly IGetSpeakerDetail _GetSpeakerDetail;
        protected string speakerName;
        public MainSpeakerDetails(IConferenceRepository ConferenceRepository, IGetSpeakerDetail GetSpeakerDetail, string SpeakerName)
        {

            InitializeComponent();
            _ConferenceRepository = ConferenceRepository;
            _GetSpeakerDetail = GetSpeakerDetail;
            pictureBox1.ImageLocation = Base64Decode(_GetSpeakerDetail.GetSpeakerImage(SpeakerName));
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
            speakerName = SpeakerName;

        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnRate_Click(object sender, EventArgs e)
        {
            try
            {
                int Nota = int.Parse(textBox9.Text);
                if (Nota <= 5 && Nota >= 1)
                {
                    _ConferenceRepository.RatingChange(Nota, speakerName);
                }
                else
                {
                    SetBalloonTip("Wrong input", "Please insert a number raging from 1 to 5");
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(30);
                }
            }
            catch
            {
                SetBalloonTip("Wrong input", "Please insert a number raging from 1 to 5");
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(30);
            }
            btnRate.Enabled = false;
            textBox7.Text = _GetSpeakerDetail.GetSpeakerRating(speakerName);
            textBox9.Enabled = false;
        }
        private void SetBalloonTip(string title, string text)
        {
            notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
            notifyIcon1.Visible = false;
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
        {  
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MainSpeakerDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
