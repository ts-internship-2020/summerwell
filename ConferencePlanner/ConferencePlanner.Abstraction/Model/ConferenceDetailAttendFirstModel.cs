using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceDetailAttendFirstModel
    {
        public string ConferenceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DictionaryConferenceTypeName { get; set; }
        public string DictionaryCityName { get; set; }
        public string LocationStreet { get; set; }
        public string DictionaryConferenceCategoryName { get; set; }
        public string SpeakerName { get; set; }
        public string HostEmail { get; set; }
        public int ConferenceId { get; set; }
        public int ConferenceStatusId { get; set; }
        public bool IsRemote { get; set; }
    }
}
