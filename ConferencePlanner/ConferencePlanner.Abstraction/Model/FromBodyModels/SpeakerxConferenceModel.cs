using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class SpeakerxConferenceModel
    {
        public int ConferenceId { get; set; }
        public int SpeakerId { get; set; }

        public bool isMainSpeaker { get; set; }
    }
}
