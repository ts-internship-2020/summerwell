using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class SpeakerDetailModel
    {
        public int SpeakerId { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerDomain { get; set; }
        public string SpeakerEmail { get; set; }
        public string Rating { get; set; }
        public string Nationality { get; set; }
        public string SpeakerImage { get; set; }

    }
}
