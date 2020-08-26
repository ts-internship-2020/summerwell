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
        public List<DictionaryCityModel> GetCity()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from DictionaryCity";
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
    }
}
