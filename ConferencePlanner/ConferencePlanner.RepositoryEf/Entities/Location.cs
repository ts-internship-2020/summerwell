using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Location
    {
        public Location()
        {
            Conference = new HashSet<Conference>();
        }

        public int LocationId { get; set; }
        public int CityId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Street { get; set; }

        public virtual DictionaryCity City { get; set; }
        public virtual ICollection<Conference> Conference { get; set; }
    }
}
