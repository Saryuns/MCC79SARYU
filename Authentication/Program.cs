using System;
using System.Collections.Generic;
using COBAOOP;

namespace COBAOOP
{
    class Program
    {
        static List<User> users = new List<User>();
        static List<User> admins = new List<User>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("== EVENODD APPLICATION ==");

            // Menambahkan data admin statis
            User admin1 = new Admin(idCounter++, "Admin1", "Admin1", "admin1", "admin123");
            User admin2 = new Admin(idCounter++, "Admin2", "Admin2", "admin1", "admin456");
            admins.Add(admin1);
            admins.Add(admin2);

            bool logout = false;
            bool loggedIn = false; // Menyimpan status login pengguna
            User loggedInUser = null; // Menyimpan pengguna yang berhasil login
            while (!logout)
            {
                if (!loggedIn)
                {
                    // Tampilkan form login
                    Console.WriteLine("\n== LOGIN ==");

                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    User user = admins.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password) ?? users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && u.Password == password);

                    if (user != null)
                    {
                        loggedIn = true;
                        loggedInUser = user;
                        Console.WriteLine("Login Successfully!!!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password!!!");
                    }
                }
                else
                {
                    Console.WriteLine($"\nLogged in as {loggedInUser.FullName}");

                    Console.ReadLine();
                    Console.Clear();

                    if (loggedInUser is Admin)
                    {
                        // Menu untuk admin
                        Console.WriteLine("== ADMIN MENU ==");
                        Console.WriteLine("1. Create User");
                        Console.WriteLine("2. Show User");
                        Console.WriteLine("3. Search User");
                        Console.WriteLine("4. Manage Account");
                        Console.WriteLine("5. Add Admin");
                        Console.WriteLine("6. Logout");
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
                                ManageAccount();
                                break;
                            case "5":
                                AddAdmin();
                                break;
                            case "6":
                                loggedIn = false;
                                loggedInUser = null;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again!!!");
                                break;
                        }
                    }
                    else
                    {
                        // Menu untuk pengguna (user)
                        Console.WriteLine("== USER MENU ==");
                        Console.WriteLine("1. Cek Ganjil/Genap");
                        Console.WriteLine("2. Print Ganjil/Genap");
                        Console.WriteLine("3. Exit");
                        Console.Write("Input: ");

                        string choice = Console.ReadLine();

                        Console.Clear();

                        switch (choice)
                        {
                            case "1":
                                Console.Write("Masukkan Bilangan yang ingin di cek : ");
                                int input;
                                if (int.TryParse(Console.ReadLine(), out input) && input > 0)
                                {
                                    string result;
                                    if (input % 2 == 0)
                                    {
                                        Console.WriteLine("Genap");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ganjil");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!!!");
                                }
                                break;
                            case "2":
                                Console.Write("Pilih (Ganjil/Genap): ");
                                string printChoice = Console.ReadLine();
                                if (printChoice.ToLower() == "even" || printChoice.ToLower() == "genap")
                                {
                                    Console.Write("Masukkan limit: ");
                                    int limit;
                                    if (int.TryParse(Console.ReadLine(), out limit) && limit > 0)
                                    {
                                        Console.WriteLine("Print bilangan 1 - " + limit + " :");
                                        PrintEvenOdd(limit, "Even");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input limit tidak valid!!!");
                                    }
                                }
                                else if (printChoice.ToLower() == "odd" || printChoice.ToLower() == "ganjil")
                                {
                                    Console.Write("Masukkan limit: ");
                                    int limit;
                                    if (int.TryParse(Console.ReadLine(), out limit) && limit > 0)
                                    {
                                        Console.WriteLine("Print bilangan 1 - " + limit + " :");
                                        PrintEvenOdd(limit, "Odd");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input limit tidak valid!!!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Input pilihan tidak valid!!!");
                                }
                                break;
                            case "3":
                                loggedIn = false;
                                loggedInUser = null;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again!!!");
                                break;
                        }
                    }
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

        static string GenerateUsername(string firstName, string lastName)
        {
            string username = firstName.Substring(0, Math.Min(2, firstName.Length)).ToUpper();
            username += lastName.Substring(0, Math.Min(2, lastName.Length)).ToUpper();
            return username;
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

        static void ManageAccount()
        {
            Console.WriteLine("== MANAGE ACCOUNT ==");

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

        static void AddAdmin()
        {
            Console.WriteLine("== ADD ADMIN ==");
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            User user = users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (user != null)
            {
                admins.Add(user);
                users.Remove(user);
                Console.WriteLine($"User '{user.Username}' added as admin successfully!!!");
            }
            else
            {
                Console.WriteLine("User not found!!!");
            }
        }

        static string EvenOddCheck(int input)
        {
            if (input % 2 == 0)
            {
                return "Even";
            }
            else
            {
                return "Odd";
            }
        }

        static void PrintEvenOdd(int limit, string choice)
        {

            for (int i = 1; i <= limit; i++)
            {
                if (EvenOddCheck(i) == choice)
                {
                    Console.Write(i + " ");
                }
            }

            Console.WriteLine();
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
    }
}