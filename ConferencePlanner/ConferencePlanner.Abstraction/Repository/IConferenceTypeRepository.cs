using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    public interface IConferenceTypeRepository
    {
        List<ConferenceTypeModel> GetConferenceType();
        void AddType(string Name, bool isRemote);
        void EditType(int Id, string Name, bool isRemote);
        bool DeleteType(int TypeId, bool IsRemote);
    }
}
