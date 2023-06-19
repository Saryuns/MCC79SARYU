using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    public class Region
    {
        public int id { get; set; }
        public string? name { get; set; }


        public List<Region> GetAllRegions()
        {
            var conn = Connection.connection;
            List<Region> regions = new List<Region>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM regions";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region();
                        region.id = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        region.name = reader.IsDBNull(1) ? "null" : reader.GetString(1);

                        regions.Add(region);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return regions;
        }


        public List<Region> GetRegionById(int id)
        {
            var conn = Connection.connection;
            List<Region> regions = new List<Region>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM regions WHERE id = @id";

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var region = new Region();
                        region.id = reader.GetInt32(0);
                        region.name = reader.GetString(1);

                        regions.Add(region);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            return regions;
        }

        /*
        public int InsertRegion(string name)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "INSERT INTO regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@region_name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(parameterName);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }
            Connection.connection.Close();
            return result;
        } */


        public int InsertRegion(string name)
        {
            int result = 0;
            //connection = new SqlConnection(ConnectionString);

            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "Insert Into regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                //Membuat parameter
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                //Menambahkan parameter ke command
                command.Parameters.Add(pName);

                //Menjalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }

                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }

            Connection.connection.Close();
            return result;
        }


        public int UpdateRegionById(int id, string name)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE regions SET name = @name WHERE id = @id";
                command.Transaction = transaction;


                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                command.Parameters.Add(parameterId);
                command.Parameters.Add(parameterName);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }
            Connection.connection.Close();
            return result;
        }


        public int DeleteRegionById(int id)
        {
            var conn = Connection.connection;
            int result = 0;
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "DELETE FROM regions WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);

                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }

            }
            conn.Close();
            return result;
        }

    }
}