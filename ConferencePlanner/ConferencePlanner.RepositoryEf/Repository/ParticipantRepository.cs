using ConferencePlanner.Abstraction.Model;
using ConferencePlanner.Abstraction.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConferencePlanner.Repository.Ef.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        public void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel)
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
