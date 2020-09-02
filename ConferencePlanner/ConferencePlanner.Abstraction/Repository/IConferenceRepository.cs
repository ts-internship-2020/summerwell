using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

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
        List<ConferenceDetailAttendFirstModel> GetAttendedConferencesFirst(List<ConferenceAudienceModel> _attendedConferences, DateTime StartDate, DateTime EndDate);
        DictionaryCityModel GetCity(int conferenceId); //IDictionaryCityRepository
        void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel); //PartipantRepository
        void AddCountry(string Code, string Name); //IDictionaryCountryRepository
        void AddCounty(string Code, string Name, string country); //IDictionaryCountyRepository
        void AddCity(string Code, string Name,string county); //IDictionaryCityRepository
        void AddSpeaker(string Code, string Name,string Nationality); //IGetSpeakerDetail
        void AddType(string Name, bool isRemote); //IDictionaryTypeRepository
        void AddCategory(string Name); //IDictionaryConferenceCategoryRepository
        void EditCountry(int Id, string Code, string Name); //IDictionaryCountryRepository
        void EditType(int Id, string Name, bool isRemote); //IDictionaryTypeRepository
        void EditCategory(int Id ,string Name); //IDictionaryConferenceCategoryRepository
        void EditCounty(string Code, string Name, int CountyId); //IDictionaryCountyRepository
        void EditCity(string Code, string Name, int CityId); //IDictionaryCityRepository
        void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality); //IGetSpeakerDetail
        bool DeleteType(int TypeId, bool IsRemote); //IDictionaryTypeRepository
        void DeleteCountry(int CountryId, bool IsRemote); //IDictionaryCountryRepository
        void DeleteSpeaker(int SpeakerId); //IGetSpeakerDetail
        void DeleteCounty(int CountyId, bool IsRemote); //IDictionaryCountyRepository
        void DeleteCity(int CityId, bool IsRemote); //IDictionaryCityRepository
        bool DeleteCategory(int CategoryId); //IDictionaryConferenceCategoryRepository
        void AddConference(AddEventDetailModel addEvent);
        public void EditConference(AddEventDetailModel eventDetail, string newAddress, string newConferenceName);
        int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel); //PartipantRepository
        int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel); //PartipantRepository

        void RatingChange(int Nota, string Name); //IGetSpeakerDetail

        string GetUniqueParticipantCode(); //PartipantRepository
        Bitmap GetQRCodeUniqueParticipantCode(ConferenceAudienceModel _conferenceAudienceModel); //PartipantRepository

    }
}
