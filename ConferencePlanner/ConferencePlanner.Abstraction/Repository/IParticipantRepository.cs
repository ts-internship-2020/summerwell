using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IParticipantRepository
    {
        void AddParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        int UpdateParticipant(ConferenceAudienceModel _conferenceAudienceModel);
        int UpdateParticipantToJoin(ConferenceAudienceModel _conferenceAudienceModel);
        string GetUniqueParticipantCode();
        Bitmap GetQRCodeUniqueParticipantCode(ConferenceAudienceModel _conferenceAudienceModel);
    }
}
