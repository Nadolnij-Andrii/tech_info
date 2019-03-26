using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    class AttractionsInfo
    {
        public Admin admin { get; set; }
        public List<Attraction> Attractions { get; set; }
        public List<AttractionType> AttractionTypes { get; set; }
    }
}
