using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface ILocationRepository
    {
        List<LocationModel> GetLocation();
        public int AddLocation(int CityId, string Street);
    }
}
