using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly summerwellContext _dbContext;
        public LocationRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddLocation(int CityId, string Street)
        {
            Location current = new Location();
            current.CityId = CityId;
            current.Street = Street;
            this._dbContext.Location.Add(current);
            this._dbContext.SaveChanges();
            return current.LocationId;
        }

        public List<LocationModel> GetLocation()
        {
            List<Location> conferencesLocation = _dbContext.Location.ToList();
            List<LocationModel> locationModel = conferencesLocation.Select(a => new LocationModel()
            {
                LocationId = a.LocationId,
                CityId = a.CityId,
                Latitude = a.Latitude,
                Longitude=a.Longitude,
                Street=a.Street
            }).ToList();
            return locationModel;
        }
    }
}
