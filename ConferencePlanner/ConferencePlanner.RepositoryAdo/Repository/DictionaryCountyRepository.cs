using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ConferencePlanner.Abstraction.Repository
{
    public class DictionaryCountyRepository : IDictionaryCountyRepository
    {
        private readonly SqlConnection _sqlConnection;

        public DictionaryCountyRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<DictionaryCountyModel> GetDictionaryCounty()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryCountyId, DictionaryCountyName, DictionaryCountryId, DictionaryCountyCode from DictionaryCounty order by DictionaryCountyId";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DictionaryCountyModel> countys = new List<DictionaryCountyModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countys.Add(new DictionaryCountyModel()
                    {
                        DictionaryCountyId = sqlDataReader.GetInt32("DictionaryCountyId"),
                        DictionaryCountyName = sqlDataReader.GetString("DictionaryCountyName"),
                        Code = sqlDataReader.GetString("DictionaryCountyCode"),
                        DictionaryCountryId = sqlDataReader.GetInt32("DictionaryCountryId")
                    });


                }


                sqlDataReader.Close();


            }
            return countys;

        }
    }
}