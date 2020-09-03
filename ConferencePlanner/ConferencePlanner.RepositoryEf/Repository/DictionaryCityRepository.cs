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
    public class DictionaryCityRepository : IDictionaryCityRepository
    {

        private readonly summerwellContext _dbContext;

        public DictionaryCityRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddCity(string Code, string Name, string county)
        {
            
                DictionaryCity current = new DictionaryCity();
                current.DictionaryCityCode = Code;
                current.DictionaryCityName = Name;
                current.DictionaryCountyId = Int32.Parse(county);
                this._dbContext.DictionaryCity.Add(current);
                this._dbContext.SaveChanges();
          

        }

        public void DeleteCity(int CityId, bool IsRemote)
        {
            var city = _dbContext.DictionaryCity.Include(x => x.Location).Where(x => x.DictionaryCityId == CityId).First();
            var location = city.Location.ToList();
            foreach (var loc in location)
            {
                var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId);
                if (result != null)
                {
                    foreach (var conf in result)
                    {
                        if (IsRemote)
                            conf.LocationId = 161;
                        else conf.LocationId = 162;
                    }
                }
                _dbContext.Remove(loc);
            }
            
            _dbContext.Remove(city);
            _dbContext.SaveChanges();
          }

        public void EditCity(string Code, string Name, int CityId)
        {
            {
                var result = _dbContext.DictionaryCity.SingleOrDefault(b => b.DictionaryCityId == CityId);
                if (result != null)
                {
                    result.DictionaryCityName = Name;
                    result.DictionaryCityCode = Code;
                    _dbContext.SaveChanges();
                }
            }
        }

        public List<DictionaryCityModel> GetCity()
        {
            List<Conference> conferences = _dbContext.Conference.ToList();

            List<ConferenceModel> conferenceModels = conferences.Select(a => new ConferenceModel()
            {
                LocationId = (int)a.LocationId

            }).ToList();

            List<Location> locations = _dbContext.Location.ToList();

            List<LocationModel> locationModels = locations.Select(a => new LocationModel()
            {

                CityId = a.CityId

            }).ToList();

            List<DictionaryCity> cities = _dbContext.DictionaryCity.ToList();

            List<DictionaryCityModel> citiesModel = cities.Select(a => new DictionaryCityModel()
            {

                DictionaryCityId = a.DictionaryCityId,
                DictionaryCountyId = a.DictionaryCountyId,
                Name = a.DictionaryCityName,
                Code = a.DictionaryCityCode


            }).ToList();

            return citiesModel;
        }

    

        public DictionaryCityModel GetCity(int conferenceId)
        {

            List<Conference> conferences = _dbContext.Conference.ToList();

            List<ConferenceModel> conferenceModels = conferences.Where(a => a.ConferenceId == conferenceId).Select(a => new ConferenceModel()
            {
                LocationId = (int)a.LocationId

            }).ToList();

            List<Location> locations = _dbContext.Location.ToList();

            List<LocationModel> locationModels = locations.Where(a => a.LocationId == conferenceModels[0].LocationId).Select(a => new LocationModel()
            {

                CityId = a.CityId

            }).ToList();

            List<DictionaryCity> cities = _dbContext.DictionaryCity.ToList();

            List<DictionaryCityModel> citiesModel = cities.Where(a => a.DictionaryCityId == locationModels[0].CityId).Select(a => new DictionaryCityModel()
            {

                DictionaryCityId = a.DictionaryCityId,
                DictionaryCountyId = a.DictionaryCountyId,
                Name = a.DictionaryCityName,
                Code = a.DictionaryCityCode


            }).ToList();

            return citiesModel[0];
        }
        }
    }

