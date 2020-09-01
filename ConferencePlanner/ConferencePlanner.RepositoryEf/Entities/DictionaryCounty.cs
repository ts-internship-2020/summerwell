using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCounty
    {
        public DictionaryCounty()
        {
            DictionaryCity = new HashSet<DictionaryCity>();
        }

        public int DictionaryCountyId { get; set; }
        public string DictionaryCountyName { get; set; }
        public int DictionaryCountryId { get; set; }
        public string DictionaryCountyCode { get; set; }

        public virtual DictionaryCountry DictionaryCountry { get; set; }
        public virtual ICollection<DictionaryCity> DictionaryCity { get; set; }
    }
}
