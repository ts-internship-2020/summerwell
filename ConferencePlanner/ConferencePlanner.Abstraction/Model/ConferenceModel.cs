using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModel
    {
        
        public int ConferenceId { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public int ConferenceCategoryId { get; set; }
        public string HostEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }
    }
}
