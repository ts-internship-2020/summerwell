using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceRepository
    {
        List<ConferenceModel> GetConference();
        List<ConferenceDetailModel> GetConferenceDetail();
        List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName);
        void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        // List<ConferenceModel> GetConference(string email);
        // List<ConferenceModel> GetConference(DateTime StartDate);
    }
}
