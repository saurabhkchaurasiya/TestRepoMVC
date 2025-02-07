﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Techonology.Entities
{
    public class Country
    {
       public int Id { get; set; }
        public string Name { get; set; } = "Default Country";
        public ICollection<State> States { get; set;} = new HashSet<State>();
    }
}
