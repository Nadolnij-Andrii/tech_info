using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    public class AttractionsInfoResponce
    {
        public Admin admin { get; set; }
        public List<Attraction> attractions { get; set; }
        public bool active { get; set; }
        public AttractionsInfoResponce()
        {

        }
        public AttractionsInfoResponce(Admin admin, List<Attraction> attractions, bool active)
        {
            this.admin = admin;
            this.attractions = attractions;
            this.active = active;
        }
    }
}
