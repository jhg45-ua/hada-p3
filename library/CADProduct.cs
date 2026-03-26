using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    internal class CADProduct
    {
        private readonly string constring;

        // Inicializa la cadena de conexión a la base de datos
        public CADProduct() {
            var cs = ConfigurationManager.ConnectionStrings["cadenaconexion"];

            if (cs == null || string.IsNullOrEmpty(cs.ConnectionString))
            {
                throw new InvalidOperationException("La cadena de conexión no está configurada correctamente.");
            }

            string constring = cs.ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            try {
                if (en == null)
                {
                    throw new InvalidOperationException();
                }

                using (SqlConnection con = new SqlConnection(constring))
                {
                    string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", en.Name);
                        cmd.Parameters.AddWithValue("@Price", en.Price);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: { 0}", ex.Message);
                return false;
            }
        }
    }
}
