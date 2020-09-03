using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class DictionaryCountyRepository : IDictionaryCountyRepository
    {
        private readonly summerwellContext _dbContext;

        public DictionaryCountyRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DictionaryCountyModel> GetDictionaryCounty()
        {
            List<DictionaryCounty> county = _dbContext.DictionaryCounty.ToList();
            List<DictionaryCountyModel> countyModel = county.Select(a => new DictionaryCountyModel()
            {
                DictionaryCountyId = a.DictionaryCountyId,
                DictionaryCountyName = a.DictionaryCountyName,
                Code = a.DictionaryCountyCode,
                DictionaryCountryId = a.DictionaryCountryId
            }).ToList();
            return countyModel;
        }

        public void EditCounty(string Code, string Name, int CountyId)
        {
            var result = _dbContext.DictionaryCounty.SingleOrDefault(b => b.DictionaryCountyId == CountyId);
            if (result != null)
            {
                result.DictionaryCountyName = Name;
                result.DictionaryCountyCode = Code;
                _dbContext.SaveChanges();
            }
        }

        public void AddCounty(string Code, string Name, string country)
        {
            DictionaryCounty current = new DictionaryCounty();
            current.DictionaryCountyName = Name;
            current.DictionaryCountyCode = Code;
            current.DictionaryCountryId = Int32.Parse(country);
            this._dbContext.DictionaryCounty.Add(current);
            this._dbContext.SaveChanges();
        }

        public bool DeleteCounty(int CountyId)
        {
            try
            {
                var county = _dbContext.DictionaryCounty.Where(x => x.DictionaryCountyId == CountyId).FirstOrDefault();
                var city = _dbContext.DictionaryCity.Where(x => x.DictionaryCountyId == CountyId).ToList();
                foreach(var c in city)
                {
                    var location = _dbContext.Location.Where(x => x.CityId == c.DictionaryCityId);
                    foreach(var loc in location)
                    {
                        var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId);
                        if (result != null)
                        {
                            foreach (var conf in result)
                            {
                                conf.LocationId = 162;
                            }
                        }
                        _dbContext.Remove(loc);
                    }
                    _dbContext.Remove(c);
                }
                _dbContext.Remove(county);
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public DictionaryCountyModel GetCounty(int id)
        {
            throw new NotImplementedException();
        }
    }
}
