using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    public class CardPriceInfo
    {
        public CardStatus cardStatus {get; set;}
        public Admin admin {get; set;}
        
        public CardPriceInfo()
        {

        }
        public CardPriceInfo(CardStatus cardStatus, Admin admin)
        {
            this.admin = admin;
            this.cardStatus = cardStatus;
        }
    }
}
