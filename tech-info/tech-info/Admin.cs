using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tech_info
{
    public class Admin
    {
        public int id { get; set; }
        public string login { get; set; }
        public string FIO { get; set; }
        public string password { get; set; }
        public byte[] passwordEncript { get; set; }

        public Admin()
        {

        }
        public Admin(
            int id,
            string login,
            string FIO,
            string password,
            byte[] passwordEncript
            )
        {
            this.id = id;
            this.login = login;
            this.FIO = FIO;
            this.password = password;
            this.passwordEncript = passwordEncript;
        }
    }
}
