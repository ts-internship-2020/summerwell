using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Speaker
    {
        public Speaker()
        {
            SpeakerxConference = new HashSet<SpeakerxConference>();
        }

        public int SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerDomain { get; set; }
        public string SpeakerEmail { get; set; }
        public string Nationality { get; set; }
        public string SpeakerImage { get; set; }
        public int? NumberOfRatings { get; set; }
        public string Rating { get; set; }

        public virtual ICollection<SpeakerxConference> SpeakerxConference { get; set; }
    }
}
