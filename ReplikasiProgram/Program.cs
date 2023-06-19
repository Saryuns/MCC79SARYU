using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC79OOP;

namespace MCC79OOP
{
    class Program
    {
        static List<User> users = new List<User>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("== BASIC AUTHENTICATION ==");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Manage Account");
                Console.WriteLine("6. Exit");

                Console.Write("Input: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        ShowUser();
                        break;
                    case "3":
                        SearchUser();
                        break;
                    case "4":
                        LoginUser();
                        break;
                    case "5":
                        ManageAccount();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!!!");
                        break;
                }
            }
        }

        static void CreateUser()
        {
            Console.WriteLine("== CREATE USER ==");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (firstName.Length >= 2 && lastName.Length >= 2 && IsValidPassword(password))
            {
                string username = GenerateUsername(firstName, lastName);
                User newUser = new User(idCounter++, firstName, lastName, username, password);
                users.Add(newUser);
                Console.WriteLine("User Successfully Created!!!");
            }
            else
            {
                Console.WriteLine("Invalid input. User creation failed!!!");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void ShowUser()
        {
            Console.WriteLine("== SHOW USER ==");

            foreach (User user in users)
            {
                user.DisplayInfo();
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void SearchUser()
        {
            Console.WriteLine("== SEARCH USER ==");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            User user = users.Find(u => u.FullName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (user != null)
            {
                user.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Account Not Found!!!");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void LoginUser()
        {
            Console.WriteLine("== LOGIN ==");

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);
            if (user != null)
            {
                Console.WriteLine("Login Successfully!!!");
            }
            else
            {
                Console.WriteLine("Invalid Username or Password!!!");
            }

            Console.ReadLine();
            Console.Clear();
        }


        static void ManageAccount()
        {
            Console.WriteLine("\n== Manage Account ==");

            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Change Password");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Back");

                Console.Write("Input: ");
                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ChangePassword();
                        break;
                    case "2":
                        DeleteAccount();
                        break;
                    case "3":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again!!!");
                        break;
                }
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void ChangePassword()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            User userToEdit = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (userToEdit != null)
            {
                Console.Write("Enter Current Password: ");
                string currentPassword = Console.ReadLine();

                if (currentPassword == userToEdit.Password)
                {
                    Console.Write("Enter New Password: ");
                    string newPassword = Console.ReadLine();

                    if (IsValidPassword(newPassword))
                    {
                        userToEdit.Password = newPassword;
                        Console.WriteLine("Password Updated Successfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid password. Update failed!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect password!!!");
                }
            }
            else
            {
                Console.WriteLine("User not found!!!");
            }

            Console.ReadLine();
            Console.Clear();
        }

        static void DeleteAccount()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            User userToDelete = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (userToDelete != null)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (password == userToDelete.Password)
                {
                    users.Remove(userToDelete);
                    Console.WriteLine("Account Deleted Successfully!!!");
                }
                else
                {
                    Console.WriteLine("Incorrect password. Deletion failed!!!");
                }
            }
            else
            {
                Console.WriteLine("User not found!!!");
            }
        }


        static bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpperCase = true;
                else if (char.IsLower(c))
                    hasLowerCase = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
            }

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        static string GenerateUsername(string firstName, string lastName)
        {
            string username = firstName.Substring(0, Math.Min(2, firstName.Length)).ToUpper();
            username += lastName.Substring(0, Math.Min(2, lastName.Length)).ToUpper();
            return username;
        }
    }
}
