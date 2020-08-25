using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

        public string GetSpeakerImage(string speakerName)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select SpeakerImage, SpeakerName " +
                "from Speaker";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    var sspeakerName = "";
                    if (!sqlDataReader.IsDBNull("SpeakerName"))
                    {
                        sspeakerName = sqlDataReader.GetString("SpeakerName");
                        if (speakerName == sspeakerName)
                        {
                            if (!sqlDataReader.IsDBNull("SpeakerImage"))
                            {
                                return sqlDataReader.GetString("SpeakerImage");
                            }
                            else return "";
                        }
                        else return "";

                    }
                    else return "";
                }

            }
            else return "";
            return "";
        }
        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {

            SqlCommand command = _sqlConnection.CreateCommand();
            command.CommandText = "INSERT INTO ConferenceAudience (ConferenceId,Participant,ConferenceStatusId) " +
                                    "VALUES (@ConferenceId, @Participant, @ConferenceStatusId)";
            command.Parameters.Add("@ConferenceId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceId;
            command.Parameters.Add("@Participant", SqlDbType.VarChar, 100).Value = _conferenceAudienceModel.Participant;
            command.Parameters.Add("@ConferenceStatusId", SqlDbType.Int).Value = _conferenceAudienceModel.ConferenceStatusId;

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

    }
}
