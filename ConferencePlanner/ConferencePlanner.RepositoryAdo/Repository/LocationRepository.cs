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
                        Longitude = sqlDataReader.GetString("DictionaryCityName"),
                        Latitude = sqlDataReader.GetString("DictionaryCountyId"),
                        CityId = sqlDataReader.GetInt32("DictionaryCityCode"),
                        Street = sqlDataReader.GetString("Streed")
                    });
                }
            }
            return location;
        }
    }
}
