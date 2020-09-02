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
