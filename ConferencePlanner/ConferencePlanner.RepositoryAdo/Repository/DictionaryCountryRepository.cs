
using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ConferencePlanner.Abstraction.Repository
{
    public class DictionaryCountryRepository : IDictionaryCountryRepository
    {
        private readonly SqlConnection _sqlConnection;

        public DictionaryCountryRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<DictionaryCountryModel> GetDictionaryCountry()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryCountryId, DictionaryCountryName from DictionaryCountry";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DictionaryCountryModel> countries = new List<DictionaryCountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countries.Add(new DictionaryCountryModel()
                    {
                        DictionaryCountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        DictionaryCountryName = sqlDataReader.GetString("DictionaryCountryName")
                    });


                }
               

                sqlDataReader.Close();


            }
            return countries;

        }
    }
}

