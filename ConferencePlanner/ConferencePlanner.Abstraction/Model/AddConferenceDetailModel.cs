using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class AddConferenceDetailModel
    { public int ConferenceTypeId { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceTypeName { get; set; }
        public int ConferenceCategoryId { get; set; }
        public string Location { get; set; }
        public string HostEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }
        public string Speaker { get; set; }
        public string ConferenceCategoryName { get; set; }
    }

}
