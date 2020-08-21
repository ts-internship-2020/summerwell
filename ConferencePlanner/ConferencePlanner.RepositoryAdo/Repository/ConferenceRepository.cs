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
                                        "c.ConferenceCategoryId, c.HostEmail, c.StartDate, c.EndDate " +
                                        "FROM Conference c";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceModel> conferences = new List<ConferenceModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    DateTime timeNow = DateTime.Now;
                    DateTime StartDate = sqlDataReader.GetDateTime("StartDate");
                    if(timeNow < StartDate)
                        conferences.Add(new ConferenceModel() { ConferenceId = sqlDataReader.GetInt32("ConferenceId"),
                                        ConferenceTypeId = sqlDataReader.GetInt32("ConferenceTypeId"),
                                        LocationId = sqlDataReader.GetInt32("LocationId"),
                                        ConferenceCategoryId = sqlDataReader.GetInt32("ConferenceCategoryId"),
                                        HostEmail = sqlDataReader.GetString("HostEmail"),
                                        StartDate = StartDate,
                                        EndDate = sqlDataReader.GetDateTime("StartDate")});
                    }
            }
            return conferences;
        }
    }
}
