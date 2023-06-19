using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    public class History
    {
        public DateTime startDate { get; set; }
        public int employeeId { get; set; }
        public DateTime endDate { get; set; }
        public int departmentId { get; set; }
        public string jobId { get; set; } = string.Empty;


        public List<History> GetAllHistories()
        {
            var conn = Connection.connection;
            List<History> histories = new List<History>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM histories";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new History();
                        history.startDate = reader.IsDBNull(0) ? DateTime.Now : reader.GetDateTime(0);
                        history.employeeId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                        history.endDate = reader.IsDBNull(2) ? DateTime.Now : reader.GetDateTime(2);
                        history.departmentId = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        history.jobId = reader.IsDBNull(4) ? "null" : reader.GetString(4);

                        histories.Add(history);
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
            return histories;
        }
    }
}