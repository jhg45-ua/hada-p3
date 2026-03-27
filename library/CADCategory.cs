using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    internal class CADCategory
    {
        private readonly string constring;

        public CADCategory()
        {
            var cs = ConfigurationManager.ConnectionStrings["cadenaconexion"];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
            {
                throw new InvalidOperationException("No existe la cadena de conexión 'cadenaconexion' en Web.config.");
            }

            constring = cs.ConnectionString;
        }

        public bool read(ENCategory en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));

                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Category WHERE Id = @id;";
                    cmd.Parameters.AddWithValue("@id", en.Id);

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Name = reader["Name"].ToString();
                            return true;
                        }

                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
                return false;
            }
        }

        public List<ENCategory> readAll()
        {
            var categories = new List<ENCategory>();

            try
            {
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Category ORDER BY Id ASC;";

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new ENCategory
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            };

                            categories.Add(category);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }

            return categories;
        }
    }
}
