using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Techonology.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";
        public int CountryId { get; set; }//Forigen Key
        public Country? country { get; set; }
        public ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
