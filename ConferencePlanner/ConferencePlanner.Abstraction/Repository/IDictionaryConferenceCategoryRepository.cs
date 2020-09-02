using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDictionaryConferenceCategoryRepository
    {
        List<DictionaryConferenceCategoryModel> GetDictionaryCategory();
        void AddCategory(string Name);
        void EditCategory(int Id, string Name);
        bool DeleteCategory(int CategoryId);
    }
}
