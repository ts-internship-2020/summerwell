using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class DictionaryConferenceTypeRepository : IConferenceTypeRepository
    {
        private readonly summerwellContext _dbContext;

        public DictionaryConferenceTypeRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddType(string Name, bool isRemote)
        {
            DictionaryConferenceType current = new DictionaryConferenceType();
            current.DictionaryConferenceTypeName = Name;
            current.IsRemote = isRemote;
            this._dbContext.DictionaryConferenceType.Add(current);
            this._dbContext.SaveChanges();
        }

        public bool DeleteType(int TypeId, bool IsRemote)
        {
            try
            {
                _dbContext.Remove(_dbContext.DictionaryConferenceType.First(a => a.DictionaryConferenceTypeId == TypeId));
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public void EditType(int Id, string Name, bool isRemote)
        {
            var result = _dbContext.DictionaryConferenceType.SingleOrDefault(b => b.DictionaryConferenceTypeId == Id);
            if (result != null)
            {
                result.DictionaryConferenceTypeName = Name;
                result.IsRemote = isRemote;
                _dbContext.SaveChanges();
            }
        }

        public List<ConferenceTypeModel> GetConferenceType()
        {
            List<DictionaryConferenceType> conferencesType = _dbContext.DictionaryConferenceType.ToList();
            List<ConferenceTypeModel> conferencesTypeModel = conferencesType.Select(a => new ConferenceTypeModel()
            {
                IsRemote = (bool)a.IsRemote,
                ConferenceTypeId = (int)a.DictionaryConferenceTypeId,
                Name = a.DictionaryConferenceTypeName
            }).ToList();
            return conferencesTypeModel;
        }
    }
}
