using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    class Connection
    {
        public static string connectionString = "Data Source=SARYU; Database = db_hr; Integrated Security = True; Connect Timeout = 30";
        public static SqlConnection connection = new SqlConnection(connectionString);
    }
}