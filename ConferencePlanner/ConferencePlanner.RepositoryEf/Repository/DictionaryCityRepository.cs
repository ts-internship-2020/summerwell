using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
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
            throw new NotImplementedException();
        }

        public void DeleteCity(int CityId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void EditCity(string Code, string Name, int CityId)
        {
            throw new NotImplementedException();
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

