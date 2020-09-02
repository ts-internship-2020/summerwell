﻿using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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
            throw new NotImplementedException();
        }

        public void EditCategory(int Id, string Name)
        {
            throw new NotImplementedException();
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

        public DictionaryConferenceCategoryModel GetDictionaryCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
