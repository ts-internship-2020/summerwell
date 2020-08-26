using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class AddEventDetailModel
    {
        public int ConferenceTypeId { get; set; }
        public string ConferenceTypeName { get; set; }
        public string DictionaryCountryCode { get; set; }
        public string DictionaryCountryName { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerRating { get; set; }
        public string DictionaryCountyCode{ get; set; }
        public string DictionaryCountyName { get; set; }
        public int DictionaryCityId { get; set; }
        public string DictionaryCityName { get; set; }
        public int DictionaryConferenceCategoryId { get; set; }
        public string DictionaryConferenceCategoryName { get; set; }
        public string DictionaryCityCode { get; set; }
        public string DictionaryCityName { get; set; }

    }
}
