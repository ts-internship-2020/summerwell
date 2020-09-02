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
    public class DictionaryCountryRepository : IDictionaryCountryRepository
    {
        private readonly summerwellContext _dbContext;

        public DictionaryCountryRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddCountry(string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {

            // var country = _dbContext.DictionaryCountry.Include(a => a.DictionaryCounty).ThenInclude(a => a.DictionaryCity).ThenInclude(a => a.Location).Where(a => a.DictionaryCountryId == CountryId).First();
            //var county = country.Di
            throw new NotImplementedException();
        }

        public void EditCountry(int Id, string Code, string Name)
        {
            var result = _dbContext.DictionaryCountry.SingleOrDefault(b => b.DictionaryCountryId == Id);
            if (result != null)
            {
                result.DictionaryCountryName = Name;
                result.DictionaryCountryCode = Code;
                _dbContext.SaveChanges();
            }
        }

        public DictionaryCountryModel GetCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<DictionaryCountryModel> GetDictionaryCountry()
        {
            throw new NotImplementedException();
        }
    }
}
