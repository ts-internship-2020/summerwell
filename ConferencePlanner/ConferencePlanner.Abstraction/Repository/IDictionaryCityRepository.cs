using ConferencePlanner.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Repository
{
    interface IDictionaryCityRepository
    {
        List<DictionaryCityModel> GetCity();
    }
}
