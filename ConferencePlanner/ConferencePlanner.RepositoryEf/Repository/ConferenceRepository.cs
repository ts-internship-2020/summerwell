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
using System.IO;
using System.Net.Mail;

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

            object Category = new DictionaryConferenceCategory { DictionaryConferenceCategoryId = id, DictionaryConferenceCategoryName = Name };
            _dbContext.Add(Category);
            _dbContext.SaveChanges();
        }

        public void AddCity(string Code, string Name, string county)
        {
            DictionaryCity current = new DictionaryCity();
            current.DictionaryCityCode = Code;
            current.DictionaryCityName = Name;
            current.DictionaryCountyId = Int32.Parse(county);
            this._dbContext.DictionaryCity.Add(current);
            this._dbContext.SaveChanges();
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
            DictionaryCounty current = new DictionaryCounty();
            current.DictionaryCountyName = Name;
            current.DictionaryCountyCode = Code;
            current.DictionaryCountryId = Int32.Parse(country);
            this._dbContext.DictionaryCounty.Add(current);
            this._dbContext.SaveChanges();
        }

        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            ConferenceAudience current = new ConferenceAudience();
            current.ConferenceId = _conferenceAudienceModel.ConferenceId;
            current.Participant = _conferenceAudienceModel.Participant;
            current.ConferenceStatusId = _conferenceAudienceModel.ConferenceStatusId;
            current.UniqueParticipantCode = _conferenceAudienceModel.UniqueParticipantCode;
            this._dbContext.ConferenceAudience.Add(current);
            this._dbContext.SaveChanges();
        }

        public void AddSpeaker(string Email, string Name, string Nationality)
        {
            Speaker newSpeaker = new Speaker();
            newSpeaker.SpeakerEmail = Email;
            newSpeaker.SpeakerName = Name;
            newSpeaker.Nationality = Nationality;
            _dbContext.Speaker.Add(newSpeaker);
            _dbContext.SaveChanges();

        }
            public void AddType(string Name, bool isRemote)
        {
            DictionaryConferenceType current = new DictionaryConferenceType();
            current.DictionaryConferenceTypeName = Name;
            current.IsRemote = isRemote;
            this._dbContext.DictionaryConferenceType.Add(current);
            this._dbContext.SaveChanges();
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
            var city = _dbContext.DictionaryCity.Include(x => x.Location).Where(x => x.DictionaryCityId == CityId).First();
            var location = city.Location.ToList();
            foreach (var loc in location)
            {
                var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId);
                if (result != null)
                {
                    foreach (var conf in result)
                    {
                        if (IsRemote)
                            conf.LocationId = 161;
                        else conf.LocationId = 162;
                    }
                }
                _dbContext.Remove(loc);
            }

            _dbContext.Remove(city);
            _dbContext.SaveChanges();
        }

        public void DeleteCountry(int CountryId, bool IsRemote)
        {

            var country = _dbContext.DictionaryCountry.Where(x => x.DictionaryCountryId == CountryId).FirstOrDefault();
            var countys = _dbContext.DictionaryCounty.Where(x => x.DictionaryCountryId == CountryId).ToList();
            foreach (var county in countys)
            {
                var cities = _dbContext.DictionaryCity.Where(x => x.DictionaryCountyId == county.DictionaryCountyId).ToList();
                foreach (var city in cities)
                {
                    var location = _dbContext.Location.Where(x => x.CityId == city.DictionaryCityId).ToList();
                    foreach (var loc in location)
                    {
                        var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId).Include(x => x.ConferenceType).ToList();
                        if (result != null)
                        {
                            foreach (var conf in result)
                            {
                                if (conf.ConferenceType.IsRemote)
                                    conf.LocationId = 161;
                                else
                                    conf.LocationId = 162;
                            }
                        }
                        _dbContext.Remove(loc);
                    }
                    _dbContext.Remove(city);
                }
                _dbContext.Remove(county);
            }
            _dbContext.Remove(country);
            _dbContext.SaveChanges();

        }

        public void DeleteCounty(int CountyId, bool IsRemote)
        {
            try
            {
                var county = _dbContext.DictionaryCounty.Where(x => x.DictionaryCountyId == CountyId).FirstOrDefault();
                var city = _dbContext.DictionaryCity.Where(x => x.DictionaryCountyId == CountyId).ToList();
                foreach (var c in city)
                {
                    var location = _dbContext.Location.Where(x => x.CityId == c.DictionaryCityId);
                    foreach (var loc in location)
                    {
                        var result = _dbContext.Conference.Where(b => b.LocationId == loc.LocationId);
                        if (result != null)
                        {
                            foreach (var conf in result)
                            {
                                conf.LocationId = 162;
                            }
                        }
                        _dbContext.Remove(loc);
                    }
                    _dbContext.Remove(c);
                }
                _dbContext.Remove(county);
                _dbContext.SaveChanges();
            }
            catch { }
        }

        public void DeleteSpeaker(int SpeakerId)
        {
            List<SpeakerxConference> conferencesWithDeletedSpeaker = _dbContext.SpeakerxConference.Where(x => x.SpeakerId == SpeakerId).ToList();
            foreach (var conf in conferencesWithDeletedSpeaker)
            {
                conf.SpeakerId = 30;
            }
            Speaker current = _dbContext.Speaker.Where(x => x.SpeakerId == SpeakerId).FirstOrDefault();
            _dbContext.Remove(current);
            _dbContext.SaveChanges();
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
            var result = _dbContext.DictionaryConferenceCategory.SingleOrDefault(b => b.DictionaryConferenceCategoryId == Id);
            if (result != null)
            {
                result.DictionaryConferenceCategoryName = Name;
                _dbContext.SaveChanges();
            }
        }

        public void EditCity(string Code, string Name, int CityId)
        {
            var result = _dbContext.DictionaryCity.SingleOrDefault(b => b.DictionaryCityId == CityId);
            if (result != null)
            {
                result.DictionaryCityName = Name;
                result.DictionaryCityCode = Code;
                _dbContext.SaveChanges();
            }
        }

        public void EditConference(AddEventDetailModel eventDetail, string newAddress, string newConferenceName)
        {
            var result = _dbContext.Conference.SingleOrDefault(b => b.ConferenceId == eventDetail.ConferenceId);
            if (result != null)
            {
                result.ConferenceTypeId = eventDetail.ConferenceTypeId;
                result.ConferenceCategoryId = eventDetail.DictionaryConferenceCategoryId;
                result.HostEmail = eventDetail.HostEmail;
                result.StartDate=eventDetail.StartDate;
                result.EndDate=eventDetail.EndDate;
                result.ConferenceName = eventDetail.ConferenceName;
                if (eventDetail.isRemote) result.LocationId = 131;
                else result.LocationId = _locationRepository.AddLocation(eventDetail.DictionaryCityId,newAddress);
                _dbContext.SaveChanges();
            }
            var sxc = _dbContext.SpeakerxConference.SingleOrDefault(b => b.ConferenceId == eventDetail.ConferenceId);
            if(sxc != null)
            {
                sxc.SpeakerId = eventDetail.SpeakerId;
                sxc.IsMainSpeaker = true;
                _dbContext.SaveChanges();
            }
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
            var result = _dbContext.DictionaryCounty.SingleOrDefault(b => b.DictionaryCountyId == CountyId);
            if (result != null)
            {
                result.DictionaryCountyName = Name;
                result.DictionaryCountyCode = Code;

            }
        }
            public void EditSpeaker(string Email, string Name, int SpeakerId, string Nationality)
        {
            Speaker current = _dbContext.Speaker.Where(x => x.SpeakerId == SpeakerId).FirstOrDefault();
            if (current != null)
            {
                current.SpeakerEmail = Email;
                current.SpeakerName = Name;
                current.Nationality = Nationality;
                _dbContext.SaveChanges();
            }
        }

        public void EditType(int Id, string Name, bool isRemote)
        {
            var result = _dbContext.DictionaryConferenceType.SingleOrDefault(b => b.DictionaryConferenceTypeId == Id);
            if (result != null)
            {
                result.DictionaryConferenceTypeName = Name;
                result.IsRemote = isRemote;
                _dbContext.SaveChanges();
            }
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

                List<Conference> conferences = _dbContext.Conference.ToList();

                List<ConferenceModel> conferenceModels = conferences.Where(a => a.ConferenceId == conferenceId).Select(a => new ConferenceModel()
                {
                    LocationId = (int)a.LocationId

                }).ToList();

                List<Location> locations = _dbContext.Location.ToList();

                List<LocationModel> locationModels = locations.Where(a => a.LocationId == conferenceModels[0].LocationId).Select(a => new LocationModel()
                {

                    CityId = a.CityId

                }).ToList();

                List<DictionaryCity> cities = _dbContext.DictionaryCity.ToList();

                List<DictionaryCityModel> citiesModel = cities.Where(a => a.DictionaryCityId == locationModels[0].CityId).Select(a => new DictionaryCityModel()
                {

                    DictionaryCityId = a.DictionaryCityId,
                    DictionaryCountyId = a.DictionaryCountyId,
                    Name = a.DictionaryCityName,
                    Code = a.DictionaryCityCode


                }).ToList();

                return citiesModel[0];
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
                .Where(a=>a.StartDate > StartDate).Where(a => a.StartDate < EndDate).ToList();

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
            List<Conference> conferences = _dbContext.Conference.Include(a => a.ConferenceType).Include(a => a.ConferenceCategory).Include(a => a.SpeakerxConference)
    .Include(a => a.Location).Include(a => a.Location.City).Where(a => a.HostEmail == hostName).Where(a => a.StartDate > StartDate).Where(a => a.StartDate < EndDate).ToList();

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

        public Bitmap GetQRCodeUniqueParticipantCode(ConferenceAudienceModel _conferenceAudienceModel)
        {
            QRCoder.QRCodeGenerator QG = new QRCoder.QRCodeGenerator();
            var data = QG.CreateQrCode(_conferenceAudienceModel.UniqueParticipantCode, QRCoder.QRCodeGenerator.ECCLevel.Q);
            var QRCode = new QRCoder.QRCode(data);
            MemoryStream memstream = new MemoryStream();
            Bitmap QRCodeImage = QRCode.GetGraphic(20);
            QRCodeImage.Save(memstream, System.Drawing.Imaging.ImageFormat.Png);
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("aremere333@gmail.com");
            mail.To.Add(_conferenceAudienceModel.Participant);
            mail.Subject = "QR Code To Join";
            mail.Body = String.Format("This is an automatic message so you can join to the conference named {0} via QR Code", _conferenceAudienceModel.ConferenceName);
            memstream.Position = 0;
            var attachment = new System.Net.Mail.Attachment(memstream, "image.png");
            mail.Attachments.Add(attachment);
            SmtpServer.Host = "smtp.gmail.com";
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("aremere333@gmail.com", "Parola12345*");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
            return QRCodeImage;
        }

        public string GetUniqueParticipantCode()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        public void RatingChange(int Nota, string Name)
        {
            Speaker speakers = _dbContext.Speaker.Where(x => x.SpeakerName == Name).FirstOrDefault();
            int rating = int.Parse(speakers.Rating);
            int norating = (int)speakers.NumberOfRatings;
            norating++;

            int FinalRating = ((rating * norating) + Nota) / (norating + 1);

            if (speakers != null)
            {
                speakers.Rating = FinalRating.ToString();
                speakers.NumberOfRatings = norating;
                _dbContext.SaveChanges();
            }
        }

        public int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel)
        {
            ConferenceAudience result;
            if (_conferenceAudienceModel.ConferenceStatusId == 2)
                result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                            x.Participant == _conferenceAudienceModel.Participant && x.ConferenceStatusId == 3);
            else if (_conferenceAudienceModel.ConferenceStatusId == 3)
                result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                            x.Participant == _conferenceAudienceModel.Participant);
            else
                result = null;
            if (result != null)
            {
                result.ConferenceStatusId = _conferenceAudienceModel.ConferenceStatusId;
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }

        public int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel)
        {
            var result = _dbContext.ConferenceAudience.SingleOrDefault(x => x.ConferenceId == _conferenceAudienceModel.ConferenceId &&
                                                                       x.Participant == _conferenceAudienceModel.Participant && (x.ConferenceStatusId == 3 || x.ConferenceStatusId == 1));
            if (result != null)
            {
                result.ConferenceId = _conferenceAudienceModel.ConferenceId;
                result.Participant = _conferenceAudienceModel.Participant;
                result.ConferenceStatusId = _conferenceAudienceModel.ConferenceStatusId;
                _dbContext.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
