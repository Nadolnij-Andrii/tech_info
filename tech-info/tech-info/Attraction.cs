using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    public class Attraction
    {
        public int id { get; set; }
        public object attractionIp { get; set; }
        public object attractionPrice { get; set; }
        public object attractionName { get; set; }
        public int attractionType { get; set; }
        public object attractionIsRental { get; set; }
        public object attractionLastPing { get; set; }
        public object attractionPusleDuration { get; set; }
        public object attractionParam1 { get; set; }
        public bool attractionDiscountSpread { get; set; }

        public Attraction()
        {

        }
        public Attraction(
            int id,
            object attractionIp,
            object attractionPrice,
            object attractionName,
            int attractionType,
            object attractionIsRental,
            object attractionLastPing,
            object attractionPusleDuration,
            object attractionParam1,
            bool attractionDiscountSpread
            )
        {
            this.id = id;
            this.attractionIp = attractionIp;
            this.attractionPrice = attractionPrice;
            this.attractionName = attractionName;
            this.attractionType = attractionType;
            this.attractionIsRental = attractionIsRental;
            this.attractionLastPing = attractionLastPing;
            this.attractionPusleDuration = attractionPusleDuration;
            this.attractionParam1 = attractionParam1;
            this.attractionDiscountSpread = attractionDiscountSpread;
        }
    }
}
