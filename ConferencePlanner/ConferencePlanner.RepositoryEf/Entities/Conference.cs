using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Conference
    {
        public Conference()
        {
            ConferenceAudience = new HashSet<ConferenceAudience>();
            SpeakerxConference = new HashSet<SpeakerxConference>();
        }

        public int ConferenceId { get; set; }
        public int? ConferenceTypeId { get; set; }
        public int? LocationId { get; set; }
        public int? ConferenceCategoryId { get; set; }
        public string HostEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }

        public virtual DictionaryConferenceCategory ConferenceCategory { get; set; }
        public virtual DictionaryConferenceType ConferenceType { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ConferenceAudience> ConferenceAudience { get; set; }
        public virtual ICollection<SpeakerxConference> SpeakerxConference { get; set; }
    }
}
