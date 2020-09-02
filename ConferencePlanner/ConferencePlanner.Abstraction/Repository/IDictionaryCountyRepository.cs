using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDictionaryCountyRepository
    {
        List<DictionaryCountyModel> GetDictionaryCounty();
        void AddCounty(string Code, string Name, string country);
        void EditCounty(string Code, string Name, int CountyId);
        bool DeleteCounty(int CountyId);
    }
}