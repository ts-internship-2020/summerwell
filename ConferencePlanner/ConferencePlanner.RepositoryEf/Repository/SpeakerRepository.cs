using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using ConferencePlanner.Repository.Ef.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class SpeakerRepository : IGetSpeakerDetail
    {
        private summerwellContext _dbContext;
        public SpeakerRepository(summerwellContext dbContext)
        {
            _dbContext = dbContext;
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

        public void DeleteSpeaker(int SpeakerId)
        {
            List<SpeakerxConference> conferencesWithDeletedSpeaker = _dbContext.SpeakerxConference.Where(x => x.SpeakerId == SpeakerId).ToList();
            foreach(var conf in conferencesWithDeletedSpeaker)
            {
                conf.SpeakerId = 30;
            }
            Speaker current = _dbContext.Speaker.Where(x => x.SpeakerId == SpeakerId).FirstOrDefault();
            _dbContext.Remove(current);
            _dbContext.SaveChanges();
        }

       

        public string GetSpeakerImage(string speakerImage)
        {
            Speaker speakers = _dbContext.Speaker.Where(x => x.SpeakerImage == speakerImage).FirstOrDefault();
            string Image = speakers.SpeakerImage;
            return Image;
        }

        public string GetSpeakerRating(string SpeakerName)
        {
            Speaker speakers = _dbContext.Speaker.Where(x=>x.SpeakerName == SpeakerName).FirstOrDefault();
            string rating = speakers.Rating;
            return rating;
        }

        public List<SpeakerDetailModel> GetSpeakers()
        {
            List<Speaker> speakers = _dbContext.Speaker.ToList();
            List<SpeakerDetailModel> speakerDetails = new List<SpeakerDetailModel>();
            speakerDetails.AddRange(speakers.Select(x => new SpeakerDetailModel()
            {
                SpeakerId = x.SpeakerId,
                SpeakerName = x.SpeakerName,
                SpeakerDomain = x.SpeakerDomain,
                SpeakerEmail = x.SpeakerEmail,
                Rating = x.Rating,
                Nationality = x.Nationality,
                SpeakerImage = x.SpeakerImage
            }));
            return speakerDetails;
        }
    }
}
