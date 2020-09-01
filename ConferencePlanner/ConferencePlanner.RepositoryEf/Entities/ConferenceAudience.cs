using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class ConferenceAudience
    {
        public int ConferenceAudienceId { get; set; }
        public int? ConferenceId { get; set; }
        public string Participant { get; set; }
        public int? ConferenceStatusId { get; set; }
        public string UniqueParticipantCode { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual DictionaryConferenceStatus ConferenceStatus { get; set; }
    }
}
