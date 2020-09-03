using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class EditSpeaker
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
    }
}
