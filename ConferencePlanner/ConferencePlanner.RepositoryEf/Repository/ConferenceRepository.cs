using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly summerwellContext _dbContext;
        private readonly ILocationRepository _locationRepository;

        public ConferenceRepository(summerwellContext dbContext, ILocationRepository locationRepository)
        {
            _dbContext = dbContext;
            _locationRepository = locationRepository;
        }

        public void AddCategory(string Name)
        {
            int id = _dbContext.DictionaryConferenceCategory.Max(a => a.DictionaryConferenceCategoryId);
            id += 1;

            object Category = new DictionaryConferenceCategory { DictionaryConferenceCategoryId = id ,DictionaryConferenceCategoryName = Name };
            _dbContext.Add(Category);
            _dbContext.SaveChanges();
        }

        public void AddCity(string Code, string Name, string county)
        {
            throw new NotImplementedException();
        }

        public void AddConference(AddEventDetailModel addEvent)
        {
            Conference current = new Conference();
            if (addEvent.isRemote == false)
                current.LocationId = _locationRepository.AddLocation(addEvent.DictionaryCityId, addEvent.LocationName);
            else
                current.LocationId = 131;
            current.ConferenceTypeId = addEvent.ConferenceTypeId;
            current.ConferenceCategoryId = addEvent.DictionaryConferenceCategoryId;
            current.HostEmail = addEvent.HostEmail;
            current.StartDate = addEvent.StartDate;
            current.EndDate = addEvent.EndDate;
            current.ConferenceName = addEvent.ConferenceName;
            this._dbContext.Conference.Add(current);
            this._dbContext.SaveChanges();
            int conferenceId = current.ConferenceId;
            AddSpeakerXConference(conferenceId, addEvent.SpeakerId);

        }

        public void AddSpeakerXConference(int ConferenceId, int SpeakerId)
        {
            SpeakerxConference current = new SpeakerxConference();
            current.ConferenceId = ConferenceId;
            current.SpeakerId = SpeakerId;
            current.IsMainSpeaker = true;
            this._dbContext.SpeakerxConference.Add(current);
            this._dbContext.SaveChanges();
        }

        public void AddCountry(string Code, string Name)
        {
            DictionaryCountry current = new DictionaryCountry();
            current.DictionaryCountryCode = Code;
            current.DictionaryCountryName = Name;
            
            this._dbContext.DictionaryCountry.Add(current);
            this._dbContext.SaveChanges();
        }

        public void AddCounty(string Code, string Name, string country)
        {
            throw new NotImplementedException();
        }

        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            throw new NotImplementedException();
        }

        public void AddSpeaker(string Code, string Name, string Nationality)
        {
            throw new NotImplementedException();
        }

        public void AddType(string Name, bool isRemote)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                _dbContext.Remove(_dbContext.DictionaryConferenceCategory.First(a => a.DictionaryConferenceCategoryId == CategoryId));
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public void DeleteCity(int CityId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void DeleteCounty(int CountyId, bool IsRemote)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpeaker(int SpeakerId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteType(int TypeId, bool IsRemote)
        {
            try
            {
                _dbContext.Remove(_dbContext.DictionaryConferenceType.First(a => a.DictionaryConferenceTypeId == TypeId));
                _dbContext.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public void EditCategory(int Id, string Name)
        {
            throw new NotImplementedException();
        }

        public void EditCity(string Code, string Name, int CityId)
        {
            throw new NotImplementedException();
        }

        public void EditConference(AddEventDetailModel eventDetail, string newAddress, string newConferenceName)
        {
            throw new NotImplementedException();
        }

        public void EditCountry(int Id, string Code, string Name)
        {
            var result = _dbContext.DictionaryCountry.SingleOrDefault(b => b.DictionaryCountryId == Id);
            if (result != null)
            {
                result.DictionaryCountryName = Name;
                result.DictionaryCountryCode = Code;
                _dbContext.SaveChanges();
            }
        }

        public void EditCounty(string Code, string Name, int CountyId)
        {
            throw new NotImplementedException();
        }

        public void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality)
        {
            throw new NotImplementedException();
        }

        public void EditType(int Id, string Name, bool isRemote)
        {
            throw new NotImplementedException();
        }

        public List<ConferenceDetailAttendFirstModel> GetAttendedConferencesFirst(List<ConferenceAudienceModel> _attendedConferences, DateTime StartDate, DateTime EndDate)
        {
            List<Conference> conferences = _dbContext.Conference
                                                                .Include(x => x.ConferenceType)
                                                                .Include(l => l.Location)
                                                                .ThenInclude(l => l.City)
                                                                .Include(d => d.ConferenceCategory)
                                                                .Include(sxc => sxc.SpeakerxConference)
                                                                .ThenInclude(sxc => sxc.Speaker)
                                                                .Where(x => x.StartDate >= DateTime.Now)
                                                                .ToList();
          
            List<ConferenceDetailAttendFirstModel> attendedConferencesFirst = new List<ConferenceDetailAttendFirstModel>();
            attendedConferencesFirst.AddRange(conferences.Select(x => new ConferenceDetailAttendFirstModel()
            {
                ConferenceName = x.ConferenceName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                DictionaryConferenceTypeName = x.ConferenceType.DictionaryConferenceTypeName,
                DictionaryCityName = x.Location.City.DictionaryCityName,
                LocationStreet = x.Location.Street,
                DictionaryConferenceCategoryName = x.ConferenceCategory.DictionaryConferenceCategoryName,
                SpeakerName = x.SpeakerxConference.FirstOrDefault(x => x.IsMainSpeaker).Speaker.SpeakerName,
                HostEmail = x.HostEmail,
                ConferenceId = x.ConferenceId,
                ConferenceStatusId = _attendedConferences.Exists(currentConference =>
                                           currentConference.ConferenceId == x.ConferenceId && currentConference.ConferenceStatusId == 3) ? 3 : 0,
                IsRemote = x.ConferenceType.IsRemote
            }).ToList());    
            List<ConferenceDetailAttendFirstModel> sortedConferences = attendedConferencesFirst.OrderByDescending(conf => conf.ConferenceStatusId).ToList();
            return sortedConferences;
        }

        public DictionaryCityModel GetCity(int conferenceId)
        {
            throw new NotImplementedException();
        }

        public List<ConferenceModel> GetConference()
        {
            List<Conference> conferences = _dbContext.Conference.ToList();
            List<ConferenceModel> conferencesModel = conferences.Select(a => new ConferenceModel()
            {
                ConferenceId = a.ConferenceId,
                ConferenceTypeId = (int)a.ConferenceTypeId,
                LocationId = (int)a.LocationId,
                ConferenceCategoryId = (int)a.ConferenceCategoryId,
                HostEmail = a.HostEmail,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ConferenceName = a.ConferenceName
            }).ToList();
            return conferencesModel;
        }

        public List<ConferenceAudienceModel> GetConferenceAudience(string email)
        {
            List<ConferenceAudience> conferences = _dbContext.ConferenceAudience.ToList();
            List<ConferenceAudienceModel> audiences = conferences.Where(a => a.Participant == email).Select(a => new ConferenceAudienceModel()
            {
                ConferenceAudienceId=a.ConferenceAudienceId,
                ConferenceId=(int)a.ConferenceId,
                Participant=a.Participant,
                ConferenceStatusId=(int)a.ConferenceStatusId,
                UniqueParticipantCode=a.UniqueParticipantCode
            }).ToList();
            return audiences;
        }

        public List<ConferenceDetailModel> GetConferenceDetail()
        {
            List<Conference> conferences = _dbContext.Conference.Include(a => a.ConferenceType).Include(a => a.ConferenceCategory).Include(a => a.SpeakerxConference)
                 .Include(a => a.Location).Include(a => a.Location.City).ToList();

            List<ConferenceDetailModel> conferencesModel = conferences.Select(a => new ConferenceDetailModel()
            {
                ConferenceId = a.ConferenceId,
                DictionaryConferenceTypeName = a.ConferenceType.DictionaryConferenceTypeName,
                LocationStreet = a.Location.Street,
                DictionaryConferenceCategoryName = a.ConferenceCategory.DictionaryConferenceCategoryName,
                HostEmail = a.HostEmail,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ConferenceName = a.ConferenceName,
                DictionaryCityName = a.Location.City.DictionaryCityName,
                IsRemote = a.ConferenceType.IsRemote
            }).ToList();
            return conferencesModel;
        }

        public List<ConferenceDetailModel> GetConferenceDetail(DateTime StartDate, DateTime EndDate)
        {
            List<Conference> conferences = _dbContext.Conference.Include(a=>a.ConferenceType).Include(a => a.ConferenceCategory).Include(a=>a.SpeakerxConference)
                .Include(a => a.Location).Include(a => a.Location.City)
                .Where(a=>a.StartDate > StartDate).Where(a => a.EndDate < EndDate).ToList();

            List<ConferenceDetailModel> conferencesModel = conferences.Select(a => new ConferenceDetailModel()
            {
                ConferenceId = a.ConferenceId,
                DictionaryConferenceTypeName = a.ConferenceType.DictionaryConferenceTypeName,
                LocationStreet = a.Location.Street,
                DictionaryConferenceCategoryName = a.ConferenceCategory.DictionaryConferenceCategoryName,
                HostEmail = a.HostEmail,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ConferenceName = a.ConferenceName,
                DictionaryCityName = a.Location.City.DictionaryCityName,
                IsRemote = a.ConferenceType.IsRemote
            }).ToList();
            return conferencesModel;

        }

        public List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName)
        {
            List<Conference> conferences = _dbContext.Conference.Include(a => a.ConferenceType).Include(a => a.ConferenceCategory).Include(a => a.SpeakerxConference)
                .Include(a => a.Location).Include(a => a.Location.City).Where(a => a.HostEmail == hostName).ToList();

            List<ConferenceDetailModel> conferencesModel = conferences.Select(a => new ConferenceDetailModel()
            {
                ConferenceId = a.ConferenceId,
                DictionaryConferenceTypeName = a.ConferenceType.DictionaryConferenceTypeName,
                LocationStreet = a.Location.Street,
                DictionaryConferenceCategoryName = a.ConferenceCategory.DictionaryConferenceCategoryName,
                HostEmail = a.HostEmail,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ConferenceName = a.ConferenceName,
                DictionaryCityName = a.Location.City.DictionaryCityName,
                IsRemote = a.ConferenceType.IsRemote
            }).ToList();
            return conferencesModel;
        }

        public List<ConferenceDetailModel> GetConferenceDetailForHost(string hostName, DateTime StartDate, DateTime EndDate)
        {
            throw new NotImplementedException();
        }

        public Bitmap GetQRCodeUniqueParticipantCode(ConferenceAudienceModel _conferenceAudienceModel)
        {
            throw new NotImplementedException();
        }

        public string GetUniqueParticipantCode()
        {
            throw new NotImplementedException();
        }

        public void RatingChange(int Nota, string Name)
        {
            throw new NotImplementedException();
        }

        public int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            throw new NotImplementedException();
        }

        public int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel)
        {
            throw new NotImplementedException();
        }
    }
}
