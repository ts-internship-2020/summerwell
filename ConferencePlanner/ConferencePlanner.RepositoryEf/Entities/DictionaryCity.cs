using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCity
    {
        public DictionaryCity()
        {
            Location = new HashSet<Location>();
        }

        public int DictionaryCityId { get; set; }
        public string DictionaryCityName { get; set; }
        public int DictionaryCountyId { get; set; }
        public string DictionaryCityCode { get; set; }

        public virtual DictionaryCounty DictionaryCounty { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
