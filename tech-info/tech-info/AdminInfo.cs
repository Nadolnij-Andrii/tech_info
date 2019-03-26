using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    class AdminInfo
    {
        public Admin admin { get; set; }
        public Admin loginedAdmin { get; set; }
        public AdminInfo()
        {
        }
        public AdminInfo(
            Admin admin,
            Admin loginedAdmin
            )
        {
            this.admin = admin;
            this.loginedAdmin = loginedAdmin;
        }
    }
}
