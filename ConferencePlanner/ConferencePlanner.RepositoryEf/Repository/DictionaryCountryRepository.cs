using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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
            DictionaryCountry current = new DictionaryCountry();
            current.DictionaryCountryCode = Code;
            current.DictionaryCountryName = Name;

            this._dbContext.DictionaryCountry.Add(current);
            this._dbContext.SaveChanges();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void EditCountry(int Id, string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public DictionaryCountryModel GetCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<DictionaryCountryModel> GetDictionaryCountry()
        {
            List<DictionaryCountry> countries = _dbContext.DictionaryCountry.ToList();
            List<DictionaryCountryModel> countriesModel = countries.Select(a => new DictionaryCountryModel()
            {
                
                DictionaryCountryName = a.DictionaryCountryName,
                DictionaryCountryId=a.DictionaryCountryId

            }).ToList();
            return countriesModel;
        }
    }
}
