using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        List<ConferenceAudienceModel> GetConferenceAudience(string email);
        List<ConferenceDetailAttendFirstModel> GetAttendedConferecesFirst(List<ConferenceAudienceModel> _attendedConferences, 
            string currentUser, DateTime StartDate, DateTime EndDate);
        void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        void AddCountry(string Code, string Name);
        void AddCounty(string Code, string Name, string country);
        void AddCity(string Code, string Name,string county);
        void AddSpeaker(string Code, string Name);
        void AddType(string Name);
        void AddCategory(string Name);
        int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel);

        string GetUniqueParticipantCode();
    }
}
