using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    class Program
    {
        public static void Main(string[] args) => new MainMenu().CrudMenu();
    }
}