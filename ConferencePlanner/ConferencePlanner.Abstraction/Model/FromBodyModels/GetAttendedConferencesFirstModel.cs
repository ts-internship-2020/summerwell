using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class GetAttendedConferencesFirstModel
    {
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
