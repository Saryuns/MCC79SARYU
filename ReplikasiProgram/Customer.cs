using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC79OOP
{
    class Customer : User
    {
        public Customer(int id, string firstName, string lastName, string username, string password) : base(id, firstName, lastName, username, password) { }

        public override void DisplayInfo()
        {
            Console.WriteLine("Customer Information");
            base.DisplayInfo();
        }
    }
}