using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceAudienceModel
    {
        public int ConferenceAudienceId { get; set; }
        public int ConferenceId { get; set; }
        public string Participant { get; set; }
        public int ConferenceStatusId { get; set; }
    }
}
