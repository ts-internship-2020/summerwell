using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class AddCity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string county { get; set; }
    }
}
