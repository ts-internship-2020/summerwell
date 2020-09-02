using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDictionaryCityRepository
    {
        List<DictionaryCityModel> GetCity();
        void AddCity(string Code, string Name, string county);
        void EditCity(string Code, string Name, int CityId);
        void DeleteCity(int CityId, bool IsRemote);

    }
}
