using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceTypeModel
    {
        public int ConferenceTypeId { get; set; }
        public string Name { get; set; }
        public bool IsRemote { get; set; }
    }
}
