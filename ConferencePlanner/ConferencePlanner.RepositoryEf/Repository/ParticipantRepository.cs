using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private summerwellContext _dbContext;
        public ParticipantRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            ConferenceAudience current = new ConferenceAudience();
            current.ConferenceId = _conferenceAudienceModel.ConferenceId;
            current.Participant = _conferenceAudienceModel.Participant;
            current.ConferenceStatusId = _conferenceAudienceModel.ConferenceStatusId;
            current.UniqueParticipantCode = _conferenceAudienceModel.UniqueParticipantCode;
            this._dbContext.ConferenceAudience.Add(current);
            this._dbContext.SaveChanges();
        }

        public Bitmap GetQRCodeUniqueParticipantCode(ConferenceAudienceModel _conferenceAudienceModel)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var data = QG.CreateQrCode(_conferenceAudienceModel.UniqueParticipantCode, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var QRCode = new QRCoder.QRCode(data);
            MemoryStream memstream = new MemoryStream();
            Bitmap QRCodeImage = QRCode.GetGraphic(20);
            QRCodeImage.Save(memstream, System.Drawing.Imaging.ImageFormat.Png);
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("aremere333@gmail.com");
            mail.To.Add(_conferenceAudienceModel.Participant);
            mail.Subject = "QR Code To Join";
            mail.Body = String.Format("This is an automatic message so you can join to the conference named {0} via QR Code", _conferenceAudienceModel.ConferenceName);
            memstream.Position = 0;
            var attachment = new System.Net.Mail.Attachment(memstream, "image.png");
            mail.Attachments.Add(attachment);
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("aremere333@gmail.com", "Parola12345*");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
            return QRCodeImage;
        }

        public string GetUniqueParticipantCode()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        public int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            ConferenceAudience result;
            if (_conferenceAudienceModel.ConferenceStatusId == 2)
                result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                            x.Participant == _conferenceAudienceModel.Participant && (x.ConferenceStatusId == 3 || x.ConferenceStatusId == 1));
            else 
                result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                            x.Participant == _conferenceAudienceModel.Participant);
            
            if (result != null)
            {
                result.ConferenceStatusId = _conferenceAudienceModel.ConferenceStatusId;
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel)
        {
            var result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                       x.Participant == _conferenceAudienceModel.Participant && (x.ConferenceStatusId == 3 || x.ConferenceStatusId == 1));
            if (result != null)
            {
                result.ConferenceId = _conferenceAudienceModel.ConferenceId;
                result.Participant = _conferenceAudienceModel.Participant;
                result.ConferenceStatusId = 1;
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
