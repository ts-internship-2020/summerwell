using ConferencePlanner.Abstraction.Model;
using System.Collections.Generic;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceTypeRepository1
    {
        List<ConferenceTypeModel> GetConferenceType();
    }
}