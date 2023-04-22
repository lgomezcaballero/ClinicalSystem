﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalSystem.Entities
{
    public abstract class Person
    {
        public int DNI { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
