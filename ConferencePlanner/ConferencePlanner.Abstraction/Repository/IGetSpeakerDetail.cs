using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IGetSpeakerDetail
    {
        List<SpeakerDetailModel> GetSpeakers();
        void AddSpeaker(string Code, string Name, string Nationality);
        void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality);
        void DeleteSpeaker(int SpeakerId);
        string GetSpeakerImage(string speakerImage);
        string GetSpeakerRating(string SpeakerName);
    }
}
