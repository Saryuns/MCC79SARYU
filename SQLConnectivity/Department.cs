using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int locationId { get; set; }
        public int managerId { get; set; }


        public List<Department> GetAllDepartments()
        {
            var conn = Connection.connection;
            List<Department> departments = new List<Department>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM departments";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new Department();
                        department.id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        department.name = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        department.locationId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        department.managerId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);

                        departments.Add(department);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return departments;
        }
    }
}