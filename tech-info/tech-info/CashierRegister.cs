using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    public class CashierRegister
    {
        public object id { get; set; }
        public object cashierRegisterId { get; set; }
        public object cashierRegisterIP { get; set; }
        public DateTime timeLastPing { get; set; }
        public CashierRegister()
        {

        }
        public CashierRegister(
            object id,
            object cashierRegisterId,
            object cashierRegisterIP,
            DateTime timeLastPing
            )
        {
            this.id = id;
            this.cashierRegisterId = cashierRegisterId;
            this.cashierRegisterIP = cashierRegisterIP;
            this.timeLastPing = timeLastPing;
        }
    }
}
