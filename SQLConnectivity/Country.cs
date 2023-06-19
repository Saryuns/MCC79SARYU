using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectivity
{
    public class Country
    {
        public int id { set; get; }
        public string? name { set; get; }
        public int regionId { set; get; }


        public List<Country> GetAllCountries()
        {
            var conn = Connection.connection;
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM countries";

                conn.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.id = reader.IsDBNull(2) ? 0 : reader.GetInt32(0);
                        country.name = reader.IsDBNull(1) ? "null" : reader.GetString(1);
                        country.regionId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                        countries.Add(country);
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
            return countries;
        }

        public List<Country> GetCountryById(int id)
        {
            var conn = Connection.connection;
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM countries WHERE id = @id";

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
                        var country = new Country();
                        country.id = reader.GetInt32(2);
                        country.name = reader.GetString(1);
                        country.regionId = reader.GetInt32(2);

                        countries.Add(country);
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
            return countries;
        }

        public int InsertCountry(string name, int regionId)
        {
            int insertedId = 0;
            //connection = new SqlConnection(ConnectionString);

            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "INSERT INTO countries (name, regionId) VALUES (@country_name, @region_id); SELECT SCOPE_IDENTITY();";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@country_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = regionId;
                pRegionId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(pName);
                command.Parameters.Add(pRegionId);

                insertedId = Convert.ToInt32(command.ExecuteScalar());
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
            return insertedId;
        }

        /*
        public int InsertCountry(int id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "INSERT INTO countries (id, name, region_id) VALUES (@id, @name, @region_id)";
                command.Transaction = transaction;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterRegionId = new SqlParameter();
                parameterRegionId.ParameterName = "@region_id";
                parameterRegionId.Value = region_id;
                parameterRegionId.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);
                command.Parameters.Add(parameterName);
                command.Parameters.Add(parameterRegionId);

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
        */


        public int UpdateRegionById(int id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE countries SET id = @id, name = @name, region_id = @region_id WHERE id = @id";
                command.Transaction = transaction;

                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                SqlParameter parameterName = new SqlParameter();
                parameterName.ParameterName = "@name";
                parameterName.Value = name;
                parameterName.SqlDbType = SqlDbType.VarChar;

                SqlParameter parameterIdRegion = new SqlParameter();
                parameterIdRegion.ParameterName = "@region_id";
                parameterIdRegion.Value = region_id;
                parameterIdRegion.SqlDbType = SqlDbType.Int;

                command.Parameters.Add(parameterId);
                command.Parameters.Add(parameterName);
                command.Parameters.Add(parameterIdRegion);

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
                command.CommandText = "DELETE FROM countries WHERE id = @id";
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