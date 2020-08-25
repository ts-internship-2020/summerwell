using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConferencePlanner.Repository.Ado.Repository
{
    public class DictionaryConferenceCategoryRepository : IDictionaryConferenceCategoryRepository
    {
        
        private readonly SqlConnection _sqlConnection;

        public DictionaryConferenceCategoryRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<DictionaryConferenceCategoryModel> GetDictionaryCategory()
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select DictionaryConferenceCategoryId, DictionaryConferenceCategoryName from DictionaryConferenceCategory";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<DictionaryConferenceCategoryModel> categories= new List<DictionaryConferenceCategoryModel>();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    categories.Add(new DictionaryConferenceCategoryModel()
                    { 
                        DictionaryConferenceCategoryId = sqlDataReader.GetInt32("DictionaryConferenceCategoryId"),
                        DictionaryConferenceCategoryName = sqlDataReader.GetString("DictionaryConferenceCategoryName")
                    });


                }


                sqlDataReader.Close();


            }
            return categories;

        }
    }
}

