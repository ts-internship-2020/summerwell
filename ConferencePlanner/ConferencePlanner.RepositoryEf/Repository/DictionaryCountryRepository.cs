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

            var country = _dbContext.DictionaryCountry.Where(x => x.DictionaryCountryId == CountryId).FirstOrDefault();
            var countys = _dbContext.DictionaryCounty.Where(x => x.DictionaryCountryId == CountryId).ToList();
            foreach(var county in countys)
            {
                var cities = _dbContext.DictionaryCity.Where(x => x.DictionaryCountyId == county.DictionaryCountyId).ToList();
                foreach (var city in cities)
                {
                    var location = _dbContext.Location.Where(x => x.CityId == city.DictionaryCityId).ToList();
                    foreach (var loc in location)
                    {
                        var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId).Include(x => x.ConferenceType).ToList();
                        if (result != null)
                        {
                            foreach (var conf in result)
                            {
                                if (conf.ConferenceType.IsRemote)
                                    conf.LocationId = 161;
                                else
                                    conf.LocationId = 162;
                            }
                        }
                        _dbContext.Remove(loc);
                    }
                    _dbContext.Remove(city);
                }
                _dbContext.Remove(county);
            }
            _dbContext.Remove(country);
            _dbContext.SaveChanges();
                
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
