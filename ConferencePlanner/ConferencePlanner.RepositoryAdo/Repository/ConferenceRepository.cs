﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.IO;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly SqlConnection _sqlConnection;

        public ConferenceRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<ConferenceModel> GetConference()
        {
            
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT c.ConferenceId, c.ConferenceTypeId, c.LocationId, " +
                                        "c.ConferenceCategoryId, c.HostEmail, c.StartDate, c.EndDate, c.ConferenceName " +
                                        "FROM Conference c";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    DateTime timeNow = DateTime.Now;
                    DateTime StartDate = sqlDataReader.GetDateTime("StartDate");
                    var ConferenceName = "";
                    if (!sqlDataReader.IsDBNull("ConferenceName"))
                    {
                        ConferenceName = sqlDataReader.GetString("ConferenceName");
                    }
                    if (timeNow < StartDate)
                        conferences.Add(new ConferenceModel()
                        {
                            ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                            ConferenceTypeId = sqlDataReader.GetInt32("ConferenceTypeId"),
                            LocationId = sqlDataReader.GetInt32("LocationId"),
                            ConferenceCategoryId = sqlDataReader.GetInt32("ConferenceCategoryId"),
                            HostEmail = sqlDataReader.GetString("HostEmail"),
                            StartDate = StartDate,
                            EndDate = sqlDataReader.GetDateTime("StartDate"),
                            ConferenceName = ConferenceName
                        });

                }
            }
            return conferences;
        }
        public void RatingChange(int Nota, string Name)
        {
            int FinalRating = 0;
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT Rating, NumberOfRatings " +
                                        "FROM Speaker WHERE SpeakerName = @SpeakerName";
            sqlCommand.Parameters.Add("@SpeakerName", SqlDbType.VarChar, 100).Value = Name;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    int NoRating = sqlDataReader.GetInt32("NumberOfRatings");
                    int Rating = int.Parse(sqlDataReader.GetString("Rating"));
                    FinalRating = ((Rating*NoRating)+Nota)/(NoRating+1);
                    SqlCommand commmand = _sqlConnection.CreateCommand();
                    commmand.CommandText = "UPDATE Speaker " +
                                            "SET Rating = @Rating, NumberOfRatings = @NumberOfRatings " +
                                            "WHERE SpeakerName = @SpeakerName ";
                    commmand.Parameters.Add("@Rating ", SqlDbType.VarChar).Value = FinalRating.ToString();
                    commmand.Parameters.Add("@SpeakerName ", SqlDbType.VarChar).Value = Name;
                    commmand.Parameters.Add("@NumberOfRatings ", SqlDbType.Int).Value = NoRating+1;
                    commmand.ExecuteNonQuery();

                }

            }
        }
        public List<ConferenceDetailModel> GetConferenceDetail()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select c.ConferenceId, c.ConferenceName, c.StartDate,c.EndDate, d.DictionaryConferenceTypeName," +
                " ci.DictionaryCityName, dcc.DictionaryConferenceCategoryName, sp.SpeakerName, c.HostEmail " +
                "from Conference c " +
                "INNER JOIN DictionaryConferenceType d on ConferenceTypeId = d.DictionaryConferenceTypeId " +
                "INNER JOIN Location l on c.LocationId = l.LocationId " +
                "INNER JOIN DictionaryCity ci on l.CityId = ci.DictionaryCityId " +
                "INNER JOIN DictionaryConferenceCategory dcc on c.ConferenceCategoryId = dcc.DictionaryConferenceCategoryId " +
                "INNER JOIN  SpeakerxConference spc on c.ConferenceId = spc.ConferenceId " +
                "INNER JOIN Speaker sp on sp.SpeakerId = spc.SpeakerId " +
                "WHERE StartDate > GETDATE()" +
                "ORDER BY StartDate";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceDetailModel> conferenceDetails = new List<ConferenceDetailModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var conferenceName = "";
                    var conferenceTypeName = "";
                    var conferenceCityName = "";
                    var conferenceCategoryName = "";
                    var conferenceSpeakerName = "";
                    var conferenceHostEmail = "";
                    if (!sqlDataReader.IsDBNull("ConferenceName"))
                    {
                        conferenceName = sqlDataReader.GetString("ConferenceName");
                    }
                    if (!sqlDataReader.IsDBNull("DictionaryConferenceTypeName"))
                    {
                        conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName");
                    }
                    if (!sqlDataReader.IsDBNull("DictionaryCityName"))
                    {
                        conferenceCityName = sqlDataReader.GetString("DictionaryCityName");
                    }
                    if (!sqlDataReader.IsDBNull("DictionaryConferenceCategoryName"))
                    {
                        conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName");
                    }
                    if (!sqlDataReader.IsDBNull("SpeakerName"))
                    {
                        conferenceSpeakerName = sqlDataReader.GetString("SpeakerName");
                    }
                    if (!sqlDataReader.IsDBNull("HostEmail"))
                    {
                        conferenceHostEmail = sqlDataReader.GetString("HostEmail");
                    }
                    conferenceDetails.Add(new ConferenceDetailModel()
                    {
                        ConferenceName = conferenceName,
                        StartDate = sqlDataReader.GetDateTime("StartDate"),
                        EndDate = sqlDataReader.GetDateTime("EndDate"),
                        DictionaryConferenceTypeName = conferenceTypeName,
                        DictionaryCityName = conferenceCityName,
                        DictionaryConferenceCategoryName = conferenceCategoryName,
                        SpeakerName = conferenceSpeakerName,
                        HostEmail = conferenceHostEmail,
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId")
                    });
                }
            }
            return conferenceDetails;
        }
        
        public List<ConferenceDetailModel> GetConferenceDetail(DateTime StartDate, DateTime EndDate)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select c.ConferenceId, c.ConferenceName, c.StartDate,c.EndDate, d.DictionaryConferenceTypeName," +
                " ci.DictionaryCityName, dcc.DictionaryConferenceCategoryName, sp.SpeakerName, c.HostEmail, l.Street, d.IsRemote " +
                "from Conference c " +
                "INNER JOIN DictionaryConferenceType d on ConferenceTypeId = d.DictionaryConferenceTypeId " +
                "INNER JOIN Location l on c.LocationId = l.LocationId " +
                "INNER JOIN DictionaryCity ci on l.CityId = ci.DictionaryCityId " +
                "INNER JOIN DictionaryConferenceCategory dcc on c.ConferenceCategoryId = dcc.DictionaryConferenceCategoryId " +
                "INNER JOIN  SpeakerxConference spc on c.ConferenceId = spc.ConferenceId " +
                "INNER JOIN Speaker sp on sp.SpeakerId = spc.SpeakerId " +
                "WHERE StartDate > GETDATE()" +
                "ORDER BY StartDate";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceDetailModel> conferenceDetails = new List<ConferenceDetailModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    DateTime conferenceStartDate = new DateTime();
                    conferenceStartDate = sqlDataReader.GetDateTime("StartDate");
                    if (conferenceStartDate > StartDate && conferenceStartDate < EndDate)
                    {
                        var conferenceName = "";
                        var conferenceTypeName = "";
                        var conferenceCityName = "";
                        var conferenceCategoryName = "";
                        var conferenceSpeakerName = "";
                        var conferenceHostEmail = "";
                        var conferenceLocationStreet = "";
                        if (!sqlDataReader.IsDBNull("ConferenceName"))
                        {
                            conferenceName = sqlDataReader.GetString("ConferenceName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceTypeName"))
                        {
                            conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryCityName"))
                        {
                            conferenceCityName = sqlDataReader.GetString("DictionaryCityName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceCategoryName"))
                        {
                            conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName");
                        }
                        if (!sqlDataReader.IsDBNull("SpeakerName"))
                        {
                            conferenceSpeakerName = sqlDataReader.GetString("SpeakerName");
                        }
                        if (!sqlDataReader.IsDBNull("HostEmail"))
                        {
                            conferenceHostEmail = sqlDataReader.GetString("HostEmail");
                        }
                        if (!sqlDataReader.IsDBNull("Street"))
                        {
                            conferenceLocationStreet = sqlDataReader.GetString("Street");
                        }
                        conferenceDetails.Add(new ConferenceDetailModel()
                        {
                            ConferenceName = conferenceName,
                            StartDate = sqlDataReader.GetDateTime("StartDate"),
                            EndDate = sqlDataReader.GetDateTime("EndDate"),
                            DictionaryConferenceTypeName = conferenceTypeName,
                            DictionaryCityName = conferenceCityName,
                            LocationStreet = conferenceLocationStreet,
                            DictionaryConferenceCategoryName = conferenceCategoryName,
                            SpeakerName = conferenceSpeakerName,
                            HostEmail = conferenceHostEmail,
                            ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                            IsRemote = sqlDataReader.GetBoolean("IsRemote")
                        });
                    }
                }
            }
            return conferenceDetails;
        }
        public List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select c.ConferenceId, c.ConferenceName, c.StartDate,c.EndDate, d.DictionaryConferenceTypeName," +
                " ci.DictionaryCityName, dcc.DictionaryConferenceCategoryName, sp.SpeakerName, c.HostEmail " +
                "from Conference c " +
                "INNER JOIN DictionaryConferenceType d on ConferenceTypeId = d.DictionaryConferenceTypeId " +
                "INNER JOIN Location l on c.LocationId = l.LocationId " +
                "INNER JOIN DictionaryCity ci on l.CityId = ci.DictionaryCityId " +
                "INNER JOIN DictionaryConferenceCategory dcc on c.ConferenceCategoryId = dcc.DictionaryConferenceCategoryId " +
                "INNER JOIN  SpeakerxConference spc on c.ConferenceId = spc.ConferenceId " +
                "INNER JOIN Speaker sp on sp.SpeakerId = spc.SpeakerId " +
                "WHERE StartDate > GETDATE()" +
                "ORDER BY StartDate";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceDetailModel> conferenceDetails = new List<ConferenceDetailModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var conferenceHostEmail = "";
                    if (!sqlDataReader.IsDBNull("HostEmail"))
                    {
                        conferenceHostEmail = sqlDataReader.GetString("HostEmail");
                    }
                    if (conferenceHostEmail == hostName)
                    {
                        var conferenceName = "";
                        var conferenceTypeName = "";
                        var conferenceCityName = "";
                        var conferenceCategoryName = "";
                        var conferenceSpeakerName = "";

                        if (!sqlDataReader.IsDBNull("ConferenceName"))
                        {
                            conferenceName = sqlDataReader.GetString("ConferenceName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceTypeName"))
                        {
                            conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryCityName"))
                        {
                            conferenceCityName = sqlDataReader.GetString("DictionaryCityName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceCategoryName"))
                        {
                            conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName");
                        }
                        if (!sqlDataReader.IsDBNull("SpeakerName"))
                        {
                            conferenceSpeakerName = sqlDataReader.GetString("SpeakerName");
                        }
                        conferenceDetails.Add(new ConferenceDetailModel()
                        {
                            ConferenceName = conferenceName,
                            StartDate = sqlDataReader.GetDateTime("StartDate"),
                            EndDate = sqlDataReader.GetDateTime("EndDate"),
                            DictionaryConferenceTypeName = conferenceTypeName,
                            DictionaryCityName = conferenceCityName,
                            DictionaryConferenceCategoryName = conferenceCategoryName,
                            SpeakerName = conferenceSpeakerName,
                            HostEmail = conferenceHostEmail,
                            ConferenceId = sqlDataReader.GetInt32("ConferenceId")
                        });
                    }
                }
            }
            return conferenceDetails;
        }
        public List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName,DateTime StartDate, DateTime EndDate)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select c.ConferenceId, c.ConferenceName, c.StartDate,c.EndDate, d.DictionaryConferenceTypeName," +
                " ci.DictionaryCityName, dcc.DictionaryConferenceCategoryName, sp.SpeakerName, c.HostEmail, l.Street, d.IsRemote " +
                "from Conference c " +
                "INNER JOIN DictionaryConferenceType d on ConferenceTypeId = d.DictionaryConferenceTypeId " +
                "INNER JOIN Location l on c.LocationId = l.LocationId " +
                "INNER JOIN DictionaryCity ci on l.CityId = ci.DictionaryCityId " +
                "INNER JOIN DictionaryConferenceCategory dcc on c.ConferenceCategoryId = dcc.DictionaryConferenceCategoryId " +
                "INNER JOIN  SpeakerxConference spc on c.ConferenceId = spc.ConferenceId " +
                "INNER JOIN Speaker sp on sp.SpeakerId = spc.SpeakerId " +
                "WHERE StartDate > GETDATE()" +
                "ORDER BY StartDate";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceDetailModel> conferenceDetails = new List<ConferenceDetailModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var conferenceHostEmail = "";
                    DateTime conferenceStartDate = new DateTime();
                    if (!sqlDataReader.IsDBNull("HostEmail"))
                    {
                        conferenceHostEmail = sqlDataReader.GetString("HostEmail");
                        conferenceStartDate = sqlDataReader.GetDateTime("StartDate");
                    }
                    if (conferenceHostEmail == hostName && conferenceStartDate > StartDate && conferenceStartDate < EndDate)
                    {
                        var conferenceName = "";
                        var conferenceTypeName = "";
                        var conferenceCityName = "";
                        var conferenceCategoryName = "";
                        var conferenceSpeakerName = "";
                        var conferenceLocationStreet = "";

                        if (!sqlDataReader.IsDBNull("ConferenceName"))
                        {
                            conferenceName = sqlDataReader.GetString("ConferenceName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceTypeName"))
                        {
                            conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryCityName"))
                        {
                            conferenceCityName = sqlDataReader.GetString("DictionaryCityName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceCategoryName"))
                        {
                            conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName");
                        }
                        if (!sqlDataReader.IsDBNull("SpeakerName"))
                        {
                            conferenceSpeakerName = sqlDataReader.GetString("SpeakerName");
                        }
                        if (!sqlDataReader.IsDBNull("Street"))
                        {
                            conferenceLocationStreet = sqlDataReader.GetString("Street");
                        }
                        conferenceDetails.Add(new ConferenceDetailModel()
                        {
                            ConferenceName = conferenceName,
                            StartDate = sqlDataReader.GetDateTime("StartDate"),
                            EndDate = sqlDataReader.GetDateTime("EndDate"),
                            DictionaryConferenceTypeName = conferenceTypeName,
                            DictionaryCityName = conferenceCityName,
                            LocationStreet = conferenceLocationStreet,
                            DictionaryConferenceCategoryName = conferenceCategoryName,
                            SpeakerName = conferenceSpeakerName,
                            HostEmail = conferenceHostEmail,
                            ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                            IsRemote = sqlDataReader.GetBoolean("IsRemote")
                        });
                    }
                }
            }
            return conferenceDetails;
        }
        public List<ConferenceAudienceModel> GetConferenceAudience(string email)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT c.ConferenceAudienceId, c.ConferenceId, c.Participant, " +
                                    "c.ConferenceStatusId, c.UniqueParticipantCode " +
                                    "FROM ConferenceAudience c " +
                                    "WHERE c.Participant = @Participant";
            sqlCommand.Parameters.Add("@Participant", SqlDbType.VarChar, 100).Value = email;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceAudienceModel> conferenceAudience = new List<ConferenceAudienceModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferenceAudience.Add(new ConferenceAudienceModel()
                    {
                        ConferenceAudienceId = sqlDataReader.GetInt32("ConferenceAudienceId"),
                        ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                        Participant = sqlDataReader.GetString("Participant"),
                        ConferenceStatusId = sqlDataReader.GetInt32("ConferenceStatusId"),
                        UniqueParticipantCode = sqlDataReader.GetString("UniqueParticipantCode")

                    });
                }
                
            }
            return conferenceAudience;
        }
     
        public List<ConferenceDetailAttendFirstModel> GetAttendedConferencesFirst(List<ConferenceAudienceModel> _attendedConferences, DateTime StartDate, DateTime EndDate)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select c.ConferenceId, c.ConferenceName, c.StartDate,c.EndDate, d.DictionaryConferenceTypeName," +
                " ci.DictionaryCityName, dcc.DictionaryConferenceCategoryName, sp.SpeakerName, c.HostEmail, l.Street, d.IsRemote " +
                "from Conference c " +
                "INNER JOIN DictionaryConferenceType d on ConferenceTypeId = d.DictionaryConferenceTypeId " +
                "INNER JOIN Location l on c.LocationId = l.LocationId " +
                "INNER JOIN DictionaryCity ci on l.CityId = ci.DictionaryCityId " +
                "INNER JOIN DictionaryConferenceCategory dcc on c.ConferenceCategoryId = dcc.DictionaryConferenceCategoryId " +
                "INNER JOIN  SpeakerxConference spc on c.ConferenceId = spc.ConferenceId " +
                "INNER JOIN Speaker sp on sp.SpeakerId = spc.SpeakerId " +
                "WHERE StartDate > GETDATE()" +
                "ORDER BY StartDate";

            List<ConferenceDetailAttendFirstModel> conferenceDetails = new List<ConferenceDetailAttendFirstModel>();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    DateTime conferenceStartDate = new DateTime();
                    conferenceStartDate = sqlDataReader.GetDateTime("StartDate");
                    if (conferenceStartDate > StartDate && conferenceStartDate < EndDate)
                    {
                        var conferenceName = "";
                        var conferenceTypeName = "";
                        var conferenceCityName = "";
                        var conferenceCategoryName = "";
                        var conferenceSpeakerName = "";
                        var conferenceHostEmail = "";
                        var conferenceLocationStreet = "";
                        int conferenceId;
                        int conferenceStatusId;
                        if (!sqlDataReader.IsDBNull("ConferenceName"))
                        {
                            conferenceName = sqlDataReader.GetString("ConferenceName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceTypeName"))
                        {
                            conferenceTypeName = sqlDataReader.GetString("DictionaryConferenceTypeName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryCityName"))
                        {
                            conferenceCityName = sqlDataReader.GetString("DictionaryCityName");
                        }
                        if (!sqlDataReader.IsDBNull("DictionaryConferenceCategoryName"))
                        {
                            conferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName");
                        }
                        if (!sqlDataReader.IsDBNull("SpeakerName"))
                        {
                            conferenceSpeakerName = sqlDataReader.GetString("SpeakerName");
                        }
                        if (!sqlDataReader.IsDBNull("HostEmail"))
                        {
                            conferenceHostEmail = sqlDataReader.GetString("HostEmail");
                        }
                        if (!sqlDataReader.IsDBNull("Street"))
                        {
                            conferenceLocationStreet = sqlDataReader.GetString("Street");
                        }
                        conferenceId = sqlDataReader.GetInt32("ConferenceId");

                        conferenceStatusId = _attendedConferences.Exists(currentConference =>
                                           currentConference.ConferenceId == conferenceId && currentConference.ConferenceStatusId == 3) ? 3 : 0;
                        
                        conferenceDetails.Add(new ConferenceDetailAttendFirstModel()
                        {
                            ConferenceName = conferenceName,
                            StartDate = sqlDataReader.GetDateTime("StartDate"),
                            EndDate = sqlDataReader.GetDateTime("EndDate"),
                            DictionaryConferenceTypeName = conferenceTypeName,
                            DictionaryCityName = conferenceCityName,
                            LocationStreet = conferenceLocationStreet,
                            DictionaryConferenceCategoryName = conferenceCategoryName,
                            SpeakerName = conferenceSpeakerName,
                            HostEmail = conferenceHostEmail,
                            ConferenceId = conferenceId,
                            ConferenceStatusId = conferenceStatusId,
                            IsRemote = sqlDataReader.GetBoolean("IsRemote")
                        
                        });
                    }

                }
            }
            List<ConferenceDetailAttendFirstModel> sortedConferences = conferenceDetails.OrderByDescending(conf => conf.ConferenceStatusId).ToList();
            return sortedConferences;
        }
        
        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {

            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO ConferenceAudience (ConferenceId,Participant,ConferenceStatusId,UniqueParticipantCode) " +
                                    "VALUES (@ConferenceId, @Participant, @ConferenceStatusId, @UniqueParticipantCode)";
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceId;
            command.Parameters.Add("@Participant", SqlDbType.VarChar, 100).Value = _conferenceAudienceModel.Participant;
            command.Parameters.Add("@ConferenceStatusId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceStatusId;
            command.Parameters.Add("@UniqueParticipantCode", SqlDbType.VarChar, 255).Value = _conferenceAudienceModel.UniqueParticipantCode;
            command.ExecuteNonQuery();
        }
        public int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE ConferenceAudience " +
                                    "SET ConferenceStatusId = @ConferenceStatusId " +
                                    "WHERE Participant = @Participant and ConferenceId = @ConferenceId";
            command.Parameters.Add("@ConferenceStatusId ", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceStatusId;
            command.Parameters.Add("@Participant", SqlDbType.VarChar, 100).Value = _conferenceAudienceModel.Participant;
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceId;

            return(command.ExecuteNonQuery());
        }
        public int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE ConferenceAudience " +
                                    "SET ConferenceStatusId = @ConferenceStatusId " +
                                    "WHERE Participant = @Participant and ConferenceId = @ConferenceId " +
                                    "and (ConferenceStatusId = 3 or ConferenceStatusId = 1)";
            command.Parameters.Add("@ConferenceStatusId ", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceStatusId;
            command.Parameters.Add("@Participant", SqlDbType.VarChar, 100).Value = _conferenceAudienceModel.Participant;
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceId;
        
            return (command.ExecuteNonQuery());
        }

        public string GetUniqueParticipantCode()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
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
            catch(Exception ex)
            {
                
            }
            return QRCodeImage;
        }
        public void AddCountry(string Code, string Name)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO DictionaryCountry (DictionaryCountryName,DictionaryCountryCode) " +
                                    "VALUES (@CountryName, @CountryCode)";
            command.Parameters.Add("@CountryName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 100).Value = Code;
            command.ExecuteNonQuery();

        }
        public void AddCounty(string Code, string Name, string country)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO DictionaryCounty (DictionaryCountyName,DictionaryCountyCode,DictionaryCountryId) " +
                                    "VALUES (@CountyName, @CountyCode, @CountryId)";
            command.Parameters.Add("@CountyName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 100).Value = Code;
            command.Parameters.Add("@CountryId", SqlDbType.Int, 100).Value = Int32.Parse(country);
            command.ExecuteNonQuery();
        }
        public void AddCity(string Code, string Name, string county)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO DictionaryCity (DictionaryCityName,DictionaryCityCode,DictionaryCountyId) " +
                                    "VALUES (@CityName, @CityCode, @CountyId)";
            command.Parameters.Add("@CityName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CityCode", SqlDbType.VarChar, 100).Value = Code;
            command.Parameters.Add("@CountyId", SqlDbType.Int, 100).Value = Int32.Parse(county);
            command.ExecuteNonQuery();
        }
        public void AddSpeaker(string Email,string Name,string Nationality)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Speaker (SpeakerName,SpeakerEmail,Nationality) " +
                                    "VALUES (@SpeakerName,@SpeakerEmail,@Nationality)";
            command.Parameters.Add("@SpeakerName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@SpeakerEmail", SqlDbType.VarChar, 100).Value = Email;
            command.Parameters.Add("@Nationality", SqlDbType.VarChar, 100).Value = Nationality;
            command.ExecuteNonQuery();
        }
        public void AddType(string Name, bool isRemote)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO DictionaryConferenceType (DictionaryConferenceTypeName,IsRemote) " +
                                    "VALUES (@ConferenceName,@IsRemote)";
            command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@IsRemote", SqlDbType.Int, 100).Value = isRemote;
            command.ExecuteNonQuery();
        }
        public void AddCategory(string Name)
        {
            int index = 0;
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "SELECT MAX(DictionaryConferenceCategoryId) abc FROM DictionaryConferenceCategory ";
            command.ExecuteNonQuery();
            SqlDataReader sqldatareader = command.ExecuteReader();
            if (sqldatareader.HasRows)
            {
                sqldatareader.Read();
                index = sqldatareader.GetInt32("abc");
            }
            sqldatareader.Close();
            command.CommandText = "INSERT INTO DictionaryConferenceCategory (DictionaryConferenceCategoryName,DictionaryConferenceCategoryId) " +
                                    "VALUES (@ConferenceCategoryName,@ConferenceCategoryId)";
            command.Parameters.Add("@ConferenceCategoryName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@ConferenceCategoryId", SqlDbType.Int, 100).Value = index+1;
            command.ExecuteNonQuery();
        }
        public void EditCountry(int Id, string Code, string Name)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE DictionaryCountry " +
                "SET DictionaryCountryName = @CountryName , DictionaryCountryCode = @CountryCode " +
                "WHERE DictionaryCountryId = @Id ";
            command.Parameters.Add("@CountryName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CountryCode", SqlDbType.VarChar, 100).Value = Code;
            command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = Id;
            command.ExecuteNonQuery();
        }
        public void EditCounty(string Code, string Name, int CountyId) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE DictionaryCounty " +
                "SET DictionaryCountyName = @CountyName , DictionaryCountyCode = @CountyCode " +
                "WHERE DictionaryCountyId = @CountyId ";
            command.Parameters.Add("@CountyName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CountyCode", SqlDbType.VarChar, 100).Value = Code;
            command.Parameters.Add("@CountyId", SqlDbType.Int).Value = CountyId;
            command.ExecuteNonQuery();
        }
        public void EditCity(string Code, string Name, int CityId) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE DictionaryCity " +
                "SET DictionaryCityName = @CityName , DictionaryCityCode = @CityCode " +
                "WHERE DictionaryCityId = @CityId ";
            command.Parameters.Add("@CityName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@CityCode", SqlDbType.VarChar, 100).Value = Code;
            command.Parameters.Add("@CityId", SqlDbType.Int).Value = CityId;
            command.ExecuteNonQuery();
        }
        public void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Speaker " +
                "SET SpeakerName = @SpeakerName , SpeakerEmail = @SpeakerEmail, Nationality = @Nationality " +
                "WHERE SpeakerId = @SpeakerId ";
            command.Parameters.Add("@SpeakerName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@SpeakerEmail", SqlDbType.VarChar, 100).Value = Email;
            command.Parameters.Add("@SpeakerId", SqlDbType.Int).Value = SpeakerId;
            command.Parameters.Add("@Nationality", SqlDbType.VarChar, 100).Value = Nationality;
            command.ExecuteNonQuery();
        }
        public void EditType(int Id,string Name, bool isRemote) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE DictionaryConferenceType SET DictionaryConferenceTypeName = @ConferenceName, isRemote = @isRemote WHERE DictionaryConferenceTypeId = @Id";
            command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = Id;
            command.Parameters.Add("@isRemote", SqlDbType.Int, 100).Value = isRemote;
            command.ExecuteNonQuery();
        }
        public void EditCategory(int Id, string Name) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE DictionaryConferenceCategory SET DictionaryConferenceCategoryName = @ConferenceName WHERE DictionaryConferenceCategoryId = @Id";
            command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = Name;
            command.Parameters.Add("@Id", SqlDbType.Int, 100).Value = Id;
            command.ExecuteNonQuery();
        }
        
            public bool DeleteType(int TypeId, bool IsRemote)
            {
                SqlCommand command = _sqlConnection.CreateCommand();
                /*if (IsRemote == true)
                {
                    command.CommandText = "UPDATE Conference " +
                                        "SET ConferenceTypeId = 30 " +                          //30 is the id for default remote type
                                        "WHERE ConferenceTypeId = @ConferenceTypeId";
                }
                else
                {
                    command.CommandText = "UPDATE Conference " +
                                        "SET ConferenceTypeId = 31 " +                          //31 is the id for default nonremote type
                                        "WHERE ConferenceTypeId = @ConferenceTypeId";
                }
                command.Parameters.Add("@ConferenceTypeId", SqlDbType.Int).Value = TypeId;
                command.ExecuteNonQuery();

                command.CommandText = "DELETE FROM DictionaryConferenceType " +
                                    "WHERE DictionaryConferenceTypeId = @ConferenceTypeId";

                command.ExecuteNonQuery();
                */
                // if (IsRemote == true)
                // {
                command.CommandText = "SELECT ConferenceTypeId From Conference WHERE ConferenceTypeId = @TypeId";
                command.Parameters.Add("@TypeId", SqlDbType.Int).Value = TypeId;
                SqlDataReader sqlDataReader = command.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    return false;
                }
                else
                {
                SqlCommand commmand = _sqlConnection.CreateCommand();
                commmand.CommandText = commmand.CommandText = "DELETE FROM DictionaryConferenceType " +
                                "WHERE DictionaryConferenceTypeId = @ConferenceTypeId";
                commmand.Parameters.Add("@ConferenceTypeId", SqlDbType.Int).Value = TypeId;
                commmand.ExecuteNonQuery();
                    return true;
                }
                // }
            }


        public void DeleteCountry(int CountryId, bool IsRemote)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT c.DictionaryCountyId " +
                                "FROM DictionaryCounty c " +
                                "WHERE c.DictionaryCountryId = @CountryId";
            sqlCommand.Parameters.Add("@CountryId", SqlDbType.Int).Value = CountryId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    int countyId = sqlDataReader.GetInt32("DictionaryCountyId");
                    SqlCommand sqlCommand2 = _sqlConnection.CreateCommand();
                    sqlCommand2.CommandText = "SELECT c.DictionaryCityId " +
                                            "FROM DictionaryCity c " +
                                            "WHERE c.DictionaryCountyId = @CountyId";
                    sqlCommand2.Parameters.Add("@CountyId", SqlDbType.Int).Value = countyId;
                    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                    if (sqlDataReader2.HasRows)
                    {
                        while (sqlDataReader2.Read())
                        {
                            int cityId = sqlDataReader2.GetInt32("DictionaryCityId");
                            SqlCommand sqlCommand3 = _sqlConnection.CreateCommand();
                            sqlCommand3.CommandText = "SELECT l.LocationId " +
                                                    "FROM Location l " +
                                                    "WHERE l.CityId = @CityId";
                            sqlCommand3.Parameters.Add("@CityId", SqlDbType.Int).Value = cityId;
                            SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                            if (sqlDataReader3.HasRows)
                            {
                                while (sqlDataReader3.Read())
                                {
                                    int locationId = sqlDataReader3.GetInt32("LocationId");
                                    SqlCommand commandLocation = _sqlConnection.CreateCommand();
                                    if (IsRemote == true)
                                    {
                                        commandLocation.CommandText = "UPDATE Conference " +
                                                                    "SET LocationId = 131 " +
                                                                    "WHERE LocationId = @LocationId";
                                    }
                                    else
                                    {
                                        commandLocation.CommandText = "UPDATE Conference " +
                                                                    "SET LocationId = 132 " +
                                                                    "WHERE LocationId = @LocationId";
                                    }
                                    commandLocation.Parameters.Add("LocationId", SqlDbType.Int).Value = locationId;
                                    commandLocation.ExecuteNonQuery();
                                }
                            }
                                    SqlCommand command = _sqlConnection.CreateCommand();
                            command.CommandText = "DELETE FROM Location " +
                                                "WHERE CityId = @CityId";
                            command.Parameters.Add("@CityId", SqlDbType.Int).Value = cityId;
                            command.ExecuteNonQuery();
                        }
                    }
                    SqlCommand command2 = _sqlConnection.CreateCommand();
                    command2.CommandText = "DELETE FROM DictionaryCity " +
                                        "WHERE DictionaryCountyId = @CountyId";
                    command2.Parameters.Add("@CountyId", SqlDbType.Int).Value = countyId;
                    command2.ExecuteNonQuery();

                }
            }
            SqlCommand command3 = _sqlConnection.CreateCommand();
            command3.CommandText = "DELETE FROM DictionaryCounty " +
                                "WHERE DictionaryCountryId = @CountryId";
            command3.Parameters.Add("@CountryId", SqlDbType.Int).Value = CountryId;
            command3.ExecuteNonQuery();

            command3.CommandText = "DELETE FROM DictionaryCountry " +
                                "WHERE DictionaryCountryId = @CountryId";
            command3.ExecuteNonQuery();
        }
        
        public void DeleteSpeaker(int SpeakerId)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE SpeakerxConference " +
                                "SET SpeakerId = 30 " +
                                "WHERE SpeakerId = @SpeakerId";
            command.Parameters.Add("@SpeakerId", SqlDbType.Int).Value = SpeakerId;
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM Speaker " +
                                "WHERE SpeakerId = @SpeakerId";
            command.ExecuteNonQuery();
        }

        public void DeleteCounty(int CountyId, bool IsRemote)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT c.DictionaryCityId " +
                                "FROM DictionaryCity c " +
                                "WHERE c.DictionaryCountyId = @CountyId";
            sqlCommand.Parameters.Add("@CountyId", SqlDbType.Int).Value = CountyId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    int cityId = sqlDataReader.GetInt32("DictionaryCityId");
                    SqlCommand sqlCommand3 = _sqlConnection.CreateCommand();
                    sqlCommand3.CommandText = "SELECT l.LocationId " +
                                            "FROM Location l " +
                                            "WHERE l.CityId = @CityId";
                    sqlCommand3.Parameters.Add("@CityId", SqlDbType.Int).Value = cityId;
                    SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();
                    if (sqlDataReader3.HasRows)
                    {
                        while (sqlDataReader3.Read())
                        {
                            int locationId = sqlDataReader3.GetInt32("LocationId");
                            SqlCommand commandLocation = _sqlConnection.CreateCommand();
                            if (IsRemote == true)
                            {
                                commandLocation.CommandText = "UPDATE Conference " +
                                                            "SET LocationId = 131 " +
                                                            "WHERE LocationId = @LocationId";
                            }
                            else
                            {
                                commandLocation.CommandText = "UPDATE Conference " +
                                                            "SET LocationId = 132 " +
                                                            "WHERE LocationId = @LocationId";
                            }
                            commandLocation.Parameters.Add("LocationId", SqlDbType.Int).Value = locationId;
                            commandLocation.ExecuteNonQuery();
                        }
                    }
                    SqlCommand command = _sqlConnection.CreateCommand();
                    command.CommandText = "DELETE FROM Location " +
                                        "WHERE CityId = @CityId";
                    command.Parameters.Add("@CityId", SqlDbType.Int).Value = cityId;
                    command.ExecuteNonQuery();
                }
            }
            SqlCommand command2 = _sqlConnection.CreateCommand();
            command2.CommandText = "DELETE FROM DictionaryCity " +
                                "WHERE DictionaryCountyId = @CountyId";
            command2.Parameters.Add("@CountyId", SqlDbType.Int).Value = CountyId;
            command2.ExecuteNonQuery();

    
            SqlCommand command3 = _sqlConnection.CreateCommand();
            command3.CommandText = "DELETE FROM DictionaryCounty " +
                                "WHERE DictionaryCountyId = @CountyId";
            command3.Parameters.Add("@CountyId", SqlDbType.Int).Value = CountyId;
            command3.ExecuteNonQuery();

         }
            
        public void DeleteCity(int CityId, bool IsRemote)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT l.LocationId " +
                                "FROM Location l " +
                                "WHERE CityId = @CityId";
            sqlCommand.Parameters.Add("@CityId", SqlDbType.Int).Value = CityId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    int locationId = sqlDataReader.GetInt32("LocationId");
                    SqlCommand commandLocation = _sqlConnection.CreateCommand();
                    if (IsRemote == true)
                    {
                        commandLocation.CommandText = "UPDATE Conference " +
                                                    "SET LocationId = 131 " +
                                                    "WHERE LocationId = @LocationId";
                    }
                    else
                    {
                        commandLocation.CommandText = "UPDATE Conference " +
                                                    "SET LocationId = 132 " +
                                                    "WHERE LocationId = @LocationId";
                    }
                    commandLocation.Parameters.Add("LocationId", SqlDbType.Int).Value = locationId;
                    commandLocation.ExecuteNonQuery();
                }
            }
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "DELETE FROM Location " +
                                "WHERE CityId = @CityId";
            command.Parameters.Add("@CityId", SqlDbType.Int).Value = CityId;
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM DictionaryCity " +
                                "WHERE DictionaryCityId = @CityId";
            command.ExecuteNonQuery();
        }    

        public bool DeleteCategory(int CategoryId)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            /*command.CommandText = "UPDATE Conference " +
                                "SET ConferenceCategoryId = 1 " +
                                "WHERE ConferenceCategoryId = @CategoryId";
            command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM DictionaryConferenceCategory " +
                                "WHERE DictionaryConferenceCategoryId = @CategoryId";
            command.ExecuteNonQuery();
            */
            command.CommandText = "SELECT ConferenceCategoryId From Conference WHERE ConferenceCategoryId = @TypeId";
            command.Parameters.Add("@TypeId", SqlDbType.Int).Value = CategoryId;
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                return false;
            }
            else
            {
                SqlCommand commmand = _sqlConnection.CreateCommand();
                commmand.CommandText = commmand.CommandText = "DELETE FROM DictionaryConferenceCategory " +
                                "WHERE DictionaryConferenceCategoryId = @CategoryId";
                commmand.Parameters.Add("@ConferenceTypeId", SqlDbType.Int).Value = CategoryId;
                commmand.ExecuteNonQuery();
                return true;
            }
        }
        public void AddConference(AddEventDetailModel eventDetail) 
        {
            if (eventDetail.isRemote == true)
            {
                SqlCommand command = _sqlConnection.CreateCommand();
                command.CommandText = "INSERT INTO Conference(ConferenceTypeId, LocationId, ConferenceCategoryId, HostEmail, StartDate, EndDate, ConferenceName) " +
                                    "VALUES (@ConferenceTypeId, 131, @ConferenceCategoryId, @HostEmail, @StartDate, @EndDate, @ConferenceName) SELECT @@IDENTITY ";
                command.Parameters.Add("@ConferenceTypeId", SqlDbType.Int, 100).Value = int.Parse(eventDetail.ConferenceTypeId.ToString());
                command.Parameters.Add("@ConferenceCategoryId", SqlDbType.Int, 100).Value = int.Parse(eventDetail.DictionaryConferenceCategoryId.ToString());
                command.Parameters.Add("@HostEmail", SqlDbType.VarChar, 100).Value = eventDetail.HostEmail.ToString();
                command.Parameters.Add("@StartDate", SqlDbType.DateTime, 100).Value = eventDetail.StartDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime, 100).Value = eventDetail.EndDate;
                command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = eventDetail.ConferenceName;
                int ConferenceId = Convert.ToInt32(command.ExecuteScalar());
                AddConferenceXSpeaker(ConferenceId, eventDetail.SpeakerId);
            }
            else
            {
                int LocationId = 0;
                try
                {
                    LocationId = AddLocationId(eventDetail.DictionaryCityId, eventDetail.LocationName);
                }
                catch { LocationId = 69; }
                SqlCommand command = _sqlConnection.CreateCommand();
                command.CommandText = "INSERT INTO Conference (ConferenceTypeId,LocationId,ConferenceCategoryId,HostEmail,StartDate,EndDate,ConferenceName) " +
                                    "VALUES (@ConferenceTypeId, @LocationId, @ConferenceCategoryId, @HostEmail, @StartDate, @EndDate, @ConferenceName) SELECT @@IDENTITY ";
                command.Parameters.Add("@ConferenceTypeId", SqlDbType.Int, 100).Value = int.Parse(eventDetail.ConferenceTypeId.ToString());
                command.Parameters.Add("@LocationId", SqlDbType.Int, 100).Value = LocationId;
                command.Parameters.Add("@ConferenceCategoryId", SqlDbType.Int, 100).Value = int.Parse(eventDetail.DictionaryConferenceCategoryId.ToString());
                command.Parameters.Add("@HostEmail", SqlDbType.VarChar, 100).Value = eventDetail.HostEmail.ToString();
                command.Parameters.Add("@StartDate", SqlDbType.DateTime, 100).Value = eventDetail.StartDate;
                command.Parameters.Add("@EndDate", SqlDbType.DateTime, 100).Value = eventDetail.EndDate;
                command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = eventDetail.ConferenceName;
                int ConferenceId = Convert.ToInt32(command.ExecuteScalar());

                AddConferenceXSpeaker(ConferenceId, eventDetail.SpeakerId);
            }    
        }
        public int AddLocationId(int CityId,string Street) 
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO Location (CityId,Street) VALUES (@CityId,@Street)";
            command.Parameters.Add("@CityId", SqlDbType.Int, 100).Value = CityId;
            command.Parameters.Add("@Street", SqlDbType.VarChar, 100).Value = Street;
            command.ExecuteNonQuery();

            SqlCommand commmand = _sqlConnection.CreateCommand();
            commmand.CommandText = "Select LocationId from Location Where Street = @Street and CityId = @CityId";
            commmand.Parameters.Add("@Street", SqlDbType.VarChar, 100).Value = Street;
            commmand.Parameters.Add("@CityId", SqlDbType.Int, 100).Value = CityId;
            SqlDataReader sqlDataReader = commmand.ExecuteReader();
            sqlDataReader.Read();

            return sqlDataReader.GetInt32("LocationId");
        }
        public int GetLocationId(string Street)
        {
            SqlCommand commmand = _sqlConnection.CreateCommand();
            commmand.CommandText = "Select LocationId from Location Where Street = @Street";
            commmand.Parameters.Add("@Street", SqlDbType.VarChar, 100).Value = Street;

            SqlDataReader sqlDataReader = commmand.ExecuteReader();
            sqlDataReader.Read();

            return sqlDataReader.GetInt32("LocationId");
        }
        public void AddConferenceXSpeaker(int ConferenceId, int SpeakerId)
        {
            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO SpeakerXConference (ConferenceId,SpeakerId,isMainSpeaker) " +
                                        "VALUES (@ConferenceId, @SpeakerId, @isMainSpeaker)";
            command.Parameters.Add("@ConferenceId", SqlDbType.Int, 100).Value = ConferenceId;
            command.Parameters.Add("@SpeakerId", SqlDbType.Int, 100).Value = SpeakerId;
            command.Parameters.Add("@isMainSpeaker", SqlDbType.Int, 100).Value = 1;
            command.ExecuteNonQuery();
        }
        public void EditConference(AddEventDetailModel eventDetail, string newAddress, string ConferenceName) 
        {

            int findLocationId = 0;
            try
            {
                findLocationId = AddLocationId(eventDetail.DictionaryCityId, newAddress);
            }
            catch { findLocationId = 69; }

            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "UPDATE Conference SET ConferenceTypeId = @ConferenceTypeId ,LocationId = @LocationId," +
                "ConferenceCategoryId = @ConferenceCategoryId ,HostEmail = @HostEmail," +
                "StartDate = @StartDate ,EndDate = @EndDate ,ConferenceName = @ConferenceName WHERE ConferenceId = @ConferenceId ";
            command.Parameters.Add("@ConferenceTypeId", SqlDbType.Int).Value = eventDetail.ConferenceTypeId;
            if (eventDetail.isRemote == true)
            {
                command.Parameters.Add("@LocationId", SqlDbType.Int, 100).Value = 131;
            }
            else
            {
                command.Parameters.Add("@LocationId", SqlDbType.Int, 100).Value = findLocationId;
            }
            command.Parameters.Add("@ConferenceCategoryId", SqlDbType.Int).Value = eventDetail.DictionaryConferenceCategoryId;
            command.Parameters.Add("@HostEmail", SqlDbType.VarChar, 100).Value = eventDetail.HostEmail.ToString();
            command.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = eventDetail.StartDate;
            command.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = eventDetail.EndDate;
            command.Parameters.Add("@ConferenceName", SqlDbType.VarChar, 100).Value = ConferenceName;
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = eventDetail.ConferenceId;
            command.ExecuteNonQuery();

            command.Parameters.Clear();
            command.CommandText = "UPDATE SpeakerxConference " +
                                "SET SpeakerId = @SpeakerId, isMainSpeaker = 1 " +
                                "WHERE ConferenceId = @ConferenceId";
            command.Parameters.Add("@SpeakerId", SqlDbType.Int).Value = eventDetail.SpeakerId;
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = eventDetail.ConferenceId;
            try { command.ExecuteNonQuery(); }
            catch { };

        }

        public DictionaryCityModel GetCity(int conferenceId)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select dc.DictionaryCityName as Name, dc.DictionaryCityCode as Code, dc.DictionaryCityId as Id, dc.DictionaryCountyId as CountyId "+
                                      "from DictionaryCity dc "+
                                      "join Location l on l.CityId = dc.DictionaryCityId "+
                                      "join Conference c on c.LocationId = l.LocationId "+
                                      "where c.ConferenceId = @conferenceId";
            sqlCommand.Parameters.Add("@conferenceId", SqlDbType.Int).Value = conferenceId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DictionaryCityModel cityModel = new DictionaryCityModel();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                cityModel.Name = sqlDataReader.GetString("Name");
                cityModel.Code = sqlDataReader.GetString("Code");
                cityModel.DictionaryCityId= sqlDataReader.GetInt32("Id");
                cityModel.DictionaryCountyId = sqlDataReader.GetInt32("CountyId");
            }
            return cityModel;
        }

        public void AddSpeakerXConference(int ConferenceId, int SpeakerId)
        {
            throw new NotImplementedException();
        }
    }
}
