﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model.FromBodyModels
{
    public class EditCounty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
