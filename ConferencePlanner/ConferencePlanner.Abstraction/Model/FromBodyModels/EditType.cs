using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class EditType
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool isRemote { get; set; }
    }
}
