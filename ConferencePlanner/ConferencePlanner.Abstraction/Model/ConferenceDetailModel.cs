using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceDetailModel
    {
        public string ConferenceName { get; set; }
        public DateTime StartDate { get; set; }
        public string DictionaryConferenceTypeName{get; set; }
        public string DictionaryCityName { get; set; }
        public string DictionaryConferenceCategoryName { get; set; }
        public string SpeakerName { get; set; }
    }
}
