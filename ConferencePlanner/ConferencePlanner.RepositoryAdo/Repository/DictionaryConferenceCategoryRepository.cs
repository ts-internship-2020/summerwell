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

        public void AddCategory(string Name)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public void EditCategory(int Id, string Name)
        {
            throw new NotImplementedException();
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

        public DictionaryConferenceCategoryModel GetDictionaryCategory(int conferenceId)
        {
            SqlCommand sqlCommand = _sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select dcc.DictionaryConferenceCategoryId as Id, dcc.DictionaryConferenceCategoryName as Name "+
                                        "from DictionaryConferenceCategory dcc "+
                                        "join Conference c on dcc.DictionaryConferenceCategoryId = c.ConferenceCategoryId "+
                                        "where c.ConferenceId = @conferenceId";
            sqlCommand.Parameters.Add("@conferenceId", SqlDbType.Int).Value = conferenceId;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            DictionaryConferenceCategoryModel categoryModel = new DictionaryConferenceCategoryModel();
            if (sqlDataReader.HasRows)
            {
                sqlDataReader.Read();
                categoryModel.DictionaryConferenceCategoryName = sqlDataReader.GetString("Name");
                categoryModel.DictionaryConferenceCategoryId = sqlDataReader.GetInt32("Id");
            }
            return categoryModel;
        }
    }
}

