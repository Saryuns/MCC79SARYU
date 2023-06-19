using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    class MainMenu
    {
        public Region region = new Region();
        public Country country = new Country();
        public Location location = new Location();
        public Employee employee = new Employee();
        public Department department = new Department();
        public Job job = new Job();
        public History history = new History();

        public void CrudMenu()
        {
            Console.Clear();
            Console.WriteLine("== MAIN MENU ==");
            Console.WriteLine(" 1. Region");
            Console.WriteLine(" 2. Country");
            Console.WriteLine(" 3. Employee");
            Console.WriteLine(" 4. Job");
            Console.WriteLine(" 5. Department");
            Console.WriteLine(" 6. Location");
            Console.WriteLine(" 7. History");
            Console.WriteLine(" 8. LINQ Employees");
            Console.WriteLine(" 9. LINQ Employees by Department");
            Console.WriteLine(" 0. Logout");
            Console.Write(" Select an option: ");
            try
            {
                var LINQ = new LINQ();
                int inputMenu = Convert.ToInt32(Console.ReadLine());
                switch (inputMenu)
                {
                    case 1:
                        this.CrudRegion();
                        break;
                    case 2:
                        this.CrudCountry();
                        break;
                    case 3:
                        Console.Clear();
                        this.PrintEmployees();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 4:
                        Console.Clear();
                        this.PrintJobs();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 5:
                        Console.Clear();
                        this.PrintDepartments();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 6:
                        Console.Clear();
                        this.PrintLocations();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 7:
                        Console.Clear();
                        this.PrintHistories();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Input limit: ");
                        try
                        {
                            int limit = Convert.ToInt32(Console.ReadLine());
                            LINQ.GetEmployees(limit);
                            Console.ReadKey();
                            this.CrudMenu();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please, input an valid option!");
                            Console.ReadKey();
                            this.CrudMenu();
                        }

                        break;
                    case 9:
                        Console.Clear();
                        LINQ.GetDepartments();
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Logout successfull!");
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again!");
                        Console.ReadKey();
                        this.CrudMenu();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input an valid option!");
                Console.ReadKey();
                this.CrudMenu();
            }
        }


        public void CrudRegion()
        {
            Console.Clear();
            Console.WriteLine("== CRUD REGION ==");
            Console.WriteLine(" 1. Show All Region");
            Console.WriteLine(" 2. Show Region By Id");
            Console.WriteLine(" 3. Insert Region");
            Console.WriteLine(" 4. Update Region");
            Console.WriteLine(" 5. Delete Region");
            Console.WriteLine(" 9. Back");
            Console.Write(" Select an option: ");
            try
            {
                int inputMenu = Convert.ToInt32(Console.ReadLine());
                switch (inputMenu)
                {
                    case 1:
                        this.PrintRegions();
                        break;
                    case 2:
                        this.ShowRegionById();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 9:
                        this.CrudMenu();
                        break;
                    default:
                        Console.WriteLine("Please, input an valid option!");
                        Console.ReadKey();
                        this.CrudRegion();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input an valid option!");
                Console.ReadKey();
                this.CrudRegion();
            }
        }


        public void CrudCountry()
        {
            Console.Clear();
            Console.WriteLine("== CRUD COUNTRY ==");
            Console.WriteLine(" 1. Show All Country");
            Console.WriteLine(" 2. Show Country By ID");
            Console.WriteLine(" 3. insert Country");
            Console.WriteLine(" 4. Update Country");
            Console.WriteLine(" 5. Delete Country");
            Console.WriteLine(" 9. Back");
            Console.Write(" Select an option: ");
            try
            {
                int inputMenu = Convert.ToInt32(Console.ReadLine());
                switch (inputMenu)
                {
                    case 1:
                        this.PrintCoutries();
                        break;
                    case 2:
                        this.ShowCountryById();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 9:
                        this.CrudMenu();
                        break;
                    default:
                        Console.WriteLine("Please, input an valid option!");
                        Console.ReadKey();
                        this.CrudCountry();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input an valid option!");
                Console.ReadKey();
                this.CrudCountry();
            }
        }

        public void PrintRegions()
        {
            region.GetAllRegions().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"Name = {e.name}");
                Console.WriteLine();
            });
        }

        public void PrintRegionById(int id)
        {
            region.GetRegionById(id).ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"name = {e.name}");
                Console.WriteLine();
            });
        }

        public void ShowRegionById()
        {
            Console.Clear();
            Console.WriteLine("== Show Region By Id ==");
            Console.Write("Enter id: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                this.PrintRegionById(id);
                Console.ReadKey();
                this.CrudRegion();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input an valid option!");
                Console.ReadKey();
                this.CrudRegion();
            }
        }


        public void PrintCoutries()
        {
            country.GetAllCountries().ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"Name = {e.name}");
                Console.WriteLine($"Region Id = {e.regionId}");
                Console.WriteLine();
            });
        }

        public void PrintCountryById(int id)
        {
            country.GetCountryById(id).ForEach(e =>
            {
                Console.WriteLine($"id = {e.id}");
                Console.WriteLine($"name = {e.name}");
                Console.WriteLine($"region id = {e.regionId}");
                Console.WriteLine();
            });
        }

        public void ShowCountryById()
        {
            Console.Clear();
            Console.WriteLine("== Show Country By Id ==");
            Console.Write("Enter id: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                this.PrintCountryById(id);
                Console.ReadKey();
                this.CrudCountry();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input an valid option!");
                Console.ReadKey();
                this.CrudRegion();
            }
        }

        public void PrintLocations()
        {
            location.GetAllLocations().ForEach(e =>
            {
                Console.WriteLine(
                    $"id = {e.id}, street address = {e.streetAddress}, postal code = {e.postalCode}, city = {e.city}, state province = {e.stateProvince}, country id = {e.countryId}");
            });
        }


        public void PrintDepartments()
        {
            department.GetAllDepartments().ForEach(e =>
            {
                Console.WriteLine(
                    $"id = {e.id}, name = {e.name}, location id = {e.locationId}, manager id = {e.managerId}, ");
            });
        }


        public void PrintEmployees()
        {
            employee.GetAllEmployees().ForEach(e =>
            {
                Console.WriteLine(
                    $"id = {e.id}, name = {e.firstName} {e.lastName}, email = {e.email}, phone number = {e.phoneNumber}, hire date = {e.hireDate}, salary = {e.salary}");
            });
        }


        public void PrintHistories()
        {
            history.GetAllHistories().ForEach(e =>
            {
                Console.WriteLine(
                    $"start date = {e.startDate}, end date = {e.endDate}, employee id = {e.employeeId}, department id = {e.departmentId}, job id = {e.jobId}");
            });
        }


        public void PrintJobs()
        {
            job.GetAllJobs().ForEach(e =>
            {
                Console.WriteLine(
                    $"id = {e.id}, title = {e.title}, min salary = {e.minSalary}, max salary = {e.maxSalary}");
            });
        }
    }
}