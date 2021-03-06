﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class ConferenceTypeRepository : IConferenceTypeRepository
    {
        private readonly SqlConnection _sqlConnection;

        public ConferenceTypeRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void AddType(string Name, bool isRemote)
        {
            throw new NotImplementedException();
        }

        public bool DeleteType(int TypeId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void EditType(int Id, string Name, bool isRemote)
        {
            throw new NotImplementedException();
        }

        public List<ConferenceTypeModel> GetConferenceType()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryConferenceTypeName,DictionaryConferenceTypeId,IsRemote from DictionaryConferenceType";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<ConferenceTypeModel> conferencestype = new List<ConferenceTypeModel>();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    conferencestype.Add(new ConferenceTypeModel()
                    {
                        Name = sqlDataReader.GetString("DictionaryConferenceTypeName"),
                        ConferenceTypeId = sqlDataReader.GetInt32("DictionaryConferenceTypeId"),
                        IsRemote = sqlDataReader.GetBoolean("IsRemote")
                    });
                }
            }
            return conferencestype;
        }
    }
}
