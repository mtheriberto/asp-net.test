using AspNet.Test.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Test.Data.PostgreSql
{
    public class ProductData
    {
        public IList<Product> GetAll()
        {
            IList<Product> products = new List<Product>();

            string connectionString = ConfigurationManager.ConnectionStrings["test"].ToString();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // TODO: secure query
                string query = "SELECT * FROM \"Producto\"";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            Id = int.Parse(reader["IdProducto"].ToString()),
                            Name = reader["Producto"].ToString(),
                            Quantity = int.Parse(reader["Cantidad"].ToString()),
                            Price = int.Parse(reader["Precio"].ToString())
                        };
                        products.Add(product);
                    }
                }
                conn.Close();
            }
            return products;
        }
    }
}
