using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class DeleteType
    {
        public int Id { get; set; }
        public bool isRemote { get; set; }
    }
}
