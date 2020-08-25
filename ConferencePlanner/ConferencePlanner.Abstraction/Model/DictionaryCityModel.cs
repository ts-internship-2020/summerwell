using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class DictionaryCityModel
    {
        public int DictionaryCityId { get; set; }
        public int DictionaryCountyId { get; set; }
        public string Name { get; set; }
    }
}
