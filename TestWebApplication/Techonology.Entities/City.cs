﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techonology.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default City";
        public int StateId { get; set; }
        public State? state { get; set; }
    }
}
