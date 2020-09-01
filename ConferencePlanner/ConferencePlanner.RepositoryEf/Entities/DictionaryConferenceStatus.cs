using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryConferenceStatus
    {
        public DictionaryConferenceStatus()
        {
            ConferenceAudience = new HashSet<ConferenceAudience>();
        }

        public int DictionaryConferenceStatusId { get; set; }
        public string DictionaryConferenceStatusName { get; set; }

        public virtual ICollection<ConferenceAudience> ConferenceAudience { get; set; }
    }
}
