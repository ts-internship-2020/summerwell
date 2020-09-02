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
        string GetSpeakerRating(string SpeakerName);
        void AddSpeaker(string Code, string Name, string Nationality);
        void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality);
        void RatingChange(int Nota, string Name);
        void DeleteSpeaker(int SpeakerId);
    }
}
