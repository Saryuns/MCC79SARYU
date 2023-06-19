using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBAOOP
{
    class User
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public User(int id, string firstName, string lastName, string username, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + FullName);
            Console.WriteLine("Username: " + Username);
            Console.WriteLine("Password: " + Password);
        }
    }
}