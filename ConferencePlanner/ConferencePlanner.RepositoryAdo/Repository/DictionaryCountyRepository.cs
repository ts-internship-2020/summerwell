﻿using ConferencePlanner.Abstraction.Model;
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

        public DictionaryCountyModel GetCounty(int countyId)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select dc.DictionaryCountyName as Name, dc.DictionaryCountyId as Id, dc.DictionaryCountyCode as Code, dc.DictionaryCountryId as CountryId " +
                                       "from DictionaryCounty dc " +
                                       "where dc.DictionaryCountyId = @countyId";
            sqlCommand.Parameters.Add("@countyId", SqlDbType.Int).Value = countyId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DictionaryCountyModel countyModel = new DictionaryCountyModel();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                countyModel.DictionaryCountyId = countyId;
                countyModel.DictionaryCountyName = sqlDataReader.GetString("Name");
                countyModel.Code = sqlDataReader.GetString("Code");
                countyModel.DictionaryCountryId = sqlDataReader.GetInt32("CountryId");
            }
            return countyModel;
        }

        public void AddCounty(string Code, string Name, string country)
        {
            throw new NotImplementedException();
        }

        public void EditCounty(string Code, string Name, int CountyId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCounty(int CountyId)
        {
            throw new NotImplementedException();
        }
    }
}