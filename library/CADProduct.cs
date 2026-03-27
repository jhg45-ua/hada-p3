using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Policy;

namespace library
{
    public class CADProduct
    {
        private readonly string constring;

        public CADProduct()
        {
            var cs = ConfigurationManager.ConnectionStrings["cadenaconexion"];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
            {
                throw new InvalidOperationException("No existe la cadena de conexión 'cadenaconexion' en Web.config.");
            }

            constring = cs.ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));

                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Products (Code, Name, Amount, Category, Price, CreationDate)
                    VALUES (@code, @name, @amount, @category, @price, @creationDate);";

                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@amount", en.Ammount);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Update(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Products
                    SET Name = @name, Amount = @amount, Category = @category, Price = @price, CreationDate = @creationDate
                    WHERE Code = @code;";
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    cmd.Parameters.AddWithValue("@name", en.Name);
                    cmd.Parameters.AddWithValue("@amount", en.Ammount);
                    cmd.Parameters.AddWithValue("@category", en.Category);
                    cmd.Parameters.AddWithValue("@price", en.Price);
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Delete(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Products WHERE Code = @code;";
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    con.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool Read(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Products WHERE Code = @code;";
                    cmd.Parameters.AddWithValue("@code", en.Code);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Name = reader["Name"].ToString();
                            en.Ammount = Convert.ToInt32(reader["Amount"]);
                            en.Category = Convert.ToInt32(reader["Category"]);
                            en.Price = float.Parse(reader["Price"].ToString());
                            en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadFirst(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT TOP 1 * FROM Products ORDER BY CreationDate DESC;";
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Code = reader["Code"].ToString();
                            en.Name = reader["Name"].ToString();
                            en.Ammount = Convert.ToInt32(reader["Amount"]);
                            en.Category = Convert.ToInt32(reader["Category"]);
                            en.Price = float.Parse(reader["Price"].ToString());
                            en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadNext(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Products WHERE CreationDate > @creationDate ORDER BY CreationDate ASC;";
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Code = reader["Code"].ToString();
                            en.Name = reader["Name"].ToString();
                            en.Ammount = Convert.ToInt32(reader["Amount"]);
                            en.Category = Convert.ToInt32(reader["Category"]);
                            en.Price = float.Parse(reader["Price"].ToString());
                            en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }

        public bool ReadPrevious(ENProduct en)
        {
            try
            {
                if (en == null) throw new ArgumentNullException(nameof(en));
                using (var con = new SqlConnection(constring))
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Products WHERE CreationDate < @creationDate ORDER BY CreationDate DESC;";
                    cmd.Parameters.AddWithValue("@creationDate", en.CreationDate);
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Code = reader["Code"].ToString();
                            en.Name = reader["Name"].ToString();
                            en.Ammount = Convert.ToInt32(reader["Amount"]);
                            en.Category = Convert.ToInt32(reader["Category"]);
                            en.Price = float.Parse(reader["Price"].ToString());
                            en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed.Error: {0}", ex.Message);
                return false;
            }
        }
    }
}
