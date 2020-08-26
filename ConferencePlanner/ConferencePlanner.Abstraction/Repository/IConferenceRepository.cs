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
        List<ConferenceDetailModel> GetConferenceDetail(DateTime StartDate, DateTime EndDate);
        List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName);
        List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName, DateTime StartDate, DateTime EndDate);
        void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        string GetUniqueParticipantCode();
        // List<ConferenceModel> GetConference(string email);
        // List<ConferenceModel> GetConference(DateTime StartDate);
    }
}
