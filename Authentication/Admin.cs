using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBAOOP
{
    class Admin : User
    {
        public Admin(int id, string firstName, string lastName, string username, string password)
            : base(id, firstName, lastName, username, password) { }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Role: Admin");
        }
    }
}