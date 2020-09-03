using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IDictionaryCountryRepository
    {
        List<DictionaryCountryModel> GetDictionaryCountry();
        DictionaryCountryModel GetCountry(int countryId);
        void AddCountry(string Code, string Name);
        void EditCountry(int Id, string Code, string Name);
        void DeleteCountry(int CountryId, bool IsRemote);
    }
}