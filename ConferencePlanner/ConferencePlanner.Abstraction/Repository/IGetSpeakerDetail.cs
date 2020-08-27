using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IGetSpeakerDetail
    {
        List<SpeakerDetailModel> GetSpeakers();
        string GetSpeakerImage(string speakerImage);
    }
}
