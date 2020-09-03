using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
   public class DictionaryConferenceCategoryRepository:IDictionaryConferenceCategoryRepository
    {

        private readonly summerwellContext _dbContext;

        public DictionaryConferenceCategoryRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCategory(string Name)
        {
            int id = _dbContext.DictionaryConferenceCategory.Max(a => a.DictionaryConferenceCategoryId);
            id += 1;

            object Category = new DictionaryConferenceCategory { DictionaryConferenceCategoryId = id, DictionaryConferenceCategoryName = Name };
            _dbContext.Add(Category);
            _dbContext.SaveChanges();
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                _dbContext.Remove(_dbContext.DictionaryConferenceCategory.First(a => a.DictionaryConferenceCategoryId == CategoryId));
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public void EditCategory(int Id, string Name)
        {
            var result = _dbContext.DictionaryConferenceCategory.SingleOrDefault(b => b.DictionaryConferenceCategoryId == Id);
            if (result != null)
            {
                result.DictionaryConferenceCategoryName = Name;
                _dbContext.SaveChanges();
            }
        }

        public List<DictionaryConferenceCategoryModel> GetDictionaryCategory()
        {
            List<DictionaryConferenceCategory> conferencesCategory = _dbContext.DictionaryConferenceCategory.ToList();
            List<DictionaryConferenceCategoryModel> conferencesCategoryModel = conferencesCategory.Select(a => new DictionaryConferenceCategoryModel()
            {
                
                DictionaryConferenceCategoryId = a.DictionaryConferenceCategoryId,
                DictionaryConferenceCategoryName = a.DictionaryConferenceCategoryName
            }).ToList();
            return conferencesCategoryModel;
        }

        public DictionaryConferenceCategoryModel GetDictionaryCategory(int conferenceId)
        {
            List<Conference> conferences = _dbContext.Conference.ToList();
            List<ConferenceModel> conferenceModels = conferences.Where(a => a.ConferenceId == conferenceId).Select(a => new ConferenceModel()
            {
                ConferenceCategoryId = (int)a.ConferenceCategoryId

            }).ToList();

            List<DictionaryConferenceCategory> conferenceCategories = _dbContext.DictionaryConferenceCategory.ToList();
            List<DictionaryConferenceCategoryModel> categoryModels = conferenceCategories
                .Where(a => a.DictionaryConferenceCategoryId == conferenceModels[0].ConferenceCategoryId)
                .Select(a => new DictionaryConferenceCategoryModel()
            {
                DictionaryConferenceCategoryId = a.DictionaryConferenceCategoryId,
                DictionaryConferenceCategoryName = a.DictionaryConferenceCategoryName

            }).ToList();
            return categoryModels[0];
        }
    }
}
