using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    public class Location
    {
        public int id { get; set; }
        public string streetAddress { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string stateProvince { get; set; } = string.Empty;
        public int countryId { get; set; }


        public List<Location> GetAllLocations()
        {
            var conn = Connection.connection;
            List<Location> locations = new List<Location>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM locations";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var location = new Location();
                        location.id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        location.streetAddress = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        location.postalCode = reader.IsDBNull(2) ? "null" : reader.GetString(2);
                        location.city = reader.IsDBNull(3) ? "null" : reader.GetString(3);
                        location.stateProvince = reader.IsDBNull(4) ? "" : reader.GetString(4);
                        location.countryId = reader.IsDBNull(0) ? 0 : reader.GetInt32(5);

                        locations.Add(location);
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
            return locations;
        }
    }
}