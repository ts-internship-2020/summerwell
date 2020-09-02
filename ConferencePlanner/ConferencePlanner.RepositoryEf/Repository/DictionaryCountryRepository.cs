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
            DictionaryCountry current = new DictionaryCountry();
            current.DictionaryCountryCode = Code;
            current.DictionaryCountryName = Name;

            this._dbContext.DictionaryCountry.Add(current);
            this._dbContext.SaveChanges();
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
