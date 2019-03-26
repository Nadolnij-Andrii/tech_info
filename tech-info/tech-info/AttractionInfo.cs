using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    class AttractionInfo
    {
        public Admin admin { get; set; }
        public Attraction attraction { get; set; }
        public AttractionInfo(Admin admin, Attraction attraction)
        {
            this.admin = admin;
            this.attraction = attraction;
        }
    }
}
