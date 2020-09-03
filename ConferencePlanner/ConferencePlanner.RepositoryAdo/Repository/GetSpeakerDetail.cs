using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class GetSpeakerDetail : IGetSpeakerDetail
    {
        private readonly SqlConnection _sqlConnection;

        public GetSpeakerDetail(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public List<SpeakerDetailModel> GetSpeakers()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT s.SpeakerId, s.SpeakerName, s.SpeakerDomain, " +
                                        "s.SpeakerEmail, s.Rating, s.Nationality, s.SpeakerImage " +
                                        "FROM Speaker s";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<SpeakerDetailModel> speakers = new List<SpeakerDetailModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                { 
                    string speakerName = "";
                    string speakerDomain = "";
                    string speakerEmail = "";
                    string rating = "";
                    string nationality = "";
                    string speakerImage = "";
                    
                    if (!sqlDataReader.IsDBNull("SpeakerName"))
                    {
                        speakerName = sqlDataReader.GetString("SpeakerName");
                    }
                    if (!sqlDataReader.IsDBNull("SpeakerDomain"))
                    {
                        speakerDomain = sqlDataReader.GetString("SpeakerDomain");
                    }
                    if (!sqlDataReader.IsDBNull("SpeakerEmail"))
                    {
                        speakerEmail = sqlDataReader.GetString("SpeakerEmail");
                    }
                    if (!sqlDataReader.IsDBNull("Rating"))
                    {
                        rating = sqlDataReader.GetString("Rating");
                    }
                    if (!sqlDataReader.IsDBNull("Nationality")){
                        nationality = sqlDataReader.GetString("Nationality");
                    }
                    if (!sqlDataReader.IsDBNull("SpeakerImage"))
                    {
                        speakerImage = sqlDataReader.GetString("SpeakerImage");
                    }
                    speakers.Add(new SpeakerDetailModel(){
                            SpeakerId = sqlDataReader.GetInt32("SpeakerId"),
                            SpeakerName = speakerName,
                            SpeakerDomain = speakerDomain,
                            SpeakerEmail = speakerEmail,
                            Rating = rating,
                            Nationality = nationality,
                            SpeakerImage = speakerImage
                        });

                }
            }
            return speakers;
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
        public string GetSpeakerRating(string SpeakerName)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "SELECT Rating FROM Speaker WHERE SpeakerName = @Name";
            sqlCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = SpeakerName;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                string speakerRating = "";
                while (sqlDataReader.Read())
                {
                    speakerRating = sqlDataReader.GetString("Rating");
                }
                return speakerRating;
            }
            else return "";
        }

        public void AddSpeaker(string Code, string Name, string Nationality)
        {
            throw new NotImplementedException();
        }

        public void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpeaker(int SpeakerId)
        {
            throw new NotImplementedException();
        }
    }
}

