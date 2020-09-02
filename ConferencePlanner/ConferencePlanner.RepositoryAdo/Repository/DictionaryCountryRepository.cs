
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
            sqlCommand.CommandText = "select DictionaryCountryId, DictionaryCountryName, DictionaryCountryCode from DictionaryCountry";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DictionaryCountryModel> countries = new List<DictionaryCountryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    countries.Add(new DictionaryCountryModel()
                    {
                        DictionaryCountryId = sqlDataReader.GetInt32("DictionaryCountryId"),
                        DictionaryCountryName = sqlDataReader.GetString("DictionaryCountryName"),
                        Code = sqlDataReader.GetString("DictionaryCountryCode")
                    });


                }
               

                sqlDataReader.Close();


            }
            return countries;
        }

        public DictionaryCountryModel GetCountry(int countryId)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select dc.DictionaryCountryName as Name, dc.DictionaryCountryCode as Code " +
                                       "from DictionaryCountry dc " +
                                       "where dc.DictionaryCountryId = @countryId";
            sqlCommand.Parameters.Add("@countryId", SqlDbType.Int).Value = countryId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DictionaryCountryModel countryModel = new DictionaryCountryModel();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                countryModel.DictionaryCountryId = countryId;
                countryModel.DictionaryCountryName = sqlDataReader.GetString("Name");
                countryModel.Code = sqlDataReader.GetString("Code");
            }
            return countryModel;
        }

        public void AddCountry(string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public void EditCountry(int Id, string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {
            throw new NotImplementedException();
        }
    }
}

