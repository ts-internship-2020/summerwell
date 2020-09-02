using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class DictionaryCountryRepository : IDictionaryCountryRepository
    {
        public void AddCountry(string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void EditCountry(int Id, string Code, string Name)
        {
            throw new NotImplementedException();
        }

        public DictionaryCountryModel GetCountry(int countryId)
        {
            throw new NotImplementedException();
        }

        public List<DictionaryCountryModel> GetDictionaryCountry()
        {
            throw new NotImplementedException();
        }
    }
}
