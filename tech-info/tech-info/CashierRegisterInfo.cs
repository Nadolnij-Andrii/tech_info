using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    class CashierRegisterInfo
    {
        public CashierRegister cashierRegister { get; set; }
        public Admin admin { get; set; }
        public CashierRegisterInfo()
        {

        }
        public CashierRegisterInfo (CashierRegister cashierRegister, Admin admin)
        {
            this.cashierRegister = cashierRegister;
            this.admin = admin;
        }
    }
}
