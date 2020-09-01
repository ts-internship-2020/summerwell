using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDictionaryCountyRepository
    {
        List<DictionaryCountyModel> GetDictionaryCounty();
        DictionaryCountyModel GetCounty(int countyId);
    }
}