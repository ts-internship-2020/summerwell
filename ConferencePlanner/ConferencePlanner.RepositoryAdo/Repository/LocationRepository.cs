using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly SqlConnection _sqlConnection;

        public LocationRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public int AddLocation(int CityId, string Street)
        {
            throw new NotImplementedException();
        }

        List<LocationModel> ILocationRepository.GetLocation()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select LocationId, CityId, Latitude, Longitude, Street from Location";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<LocationModel> location = new List<LocationModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    location.Add(new LocationModel()
                    {
                        LocationId = sqlDataReader.GetInt32("LocationId"),
                        Longitude = sqlDataReader.GetString("Longitude"),
                        Latitude = sqlDataReader.GetString("Latitude"),
                        CityId = sqlDataReader.GetInt32("CityId"),
                        Street = sqlDataReader.GetString("Street")
                    });
                }
            }
            return location;
        }
    }
}
