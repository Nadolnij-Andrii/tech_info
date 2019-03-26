using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    class CashierInfo
    {
        public Cashier cashier { get; set; }
        public string cardInfoString { get; set; }
        public Admin admin { get; set; }
        public CashierInfo()
        {

        }
        public CashierInfo(
            Cashier cashier,
            string cardInfoString,
            Admin admin
            )
        {
            this.cashier = cashier;
            this.cardInfoString = cardInfoString;
            this.admin = admin;
        }
    }
}
