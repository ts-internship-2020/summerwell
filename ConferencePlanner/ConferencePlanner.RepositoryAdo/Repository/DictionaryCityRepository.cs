using System;
using ConferencePlanner.Abstraction.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using ConferencePlanner.Abstraction.Repository;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class DictionaryCityRepository :IDictionaryCityRepository
    {
        private readonly SqlConnection _sqlConnection;

        public DictionaryCityRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void AddCity(string Code, string Name, string county)
        {
            throw new NotImplementedException();
        }

        public void DeleteCity(int CityId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void EditCity(string Code, string Name, int CityId)
        {
            throw new NotImplementedException();
        }

        public List<DictionaryCityModel> GetCity()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryCityId, DictionaryCityName, DictionaryCountyId, DictionaryCityCode from DictionaryCity";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DictionaryCityModel> city = new List<DictionaryCityModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    city.Add(new DictionaryCityModel()
                    {
                        DictionaryCityId = sqlDataReader.GetInt32("DictionaryCityId"),
                        Name = sqlDataReader.GetString("DictionaryCityName"),
                        DictionaryCountyId = sqlDataReader.GetInt32("DictionaryCountyId"),
                        Code = sqlDataReader.GetString("DictionaryCityCode")
                    });
                }
            }
            return city;
        }

        public DictionaryCityModel GetCity(int conferenceId)
        {
            throw new NotImplementedException();
        }
    }
}
