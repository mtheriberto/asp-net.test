using AspNet.Test.Domain;
using Npgsql;
using System.Configuration;

namespace AspNet.Test.Data.PostgreSql
{
    public class UserData
    {
        public User GetByName(string name)
        {
            User user = null;
            string connectionString = ConfigurationManager.ConnectionStrings["test"].ToString();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                // TODO: secure query 
                string query = $"SELECT * FROM \"Usuario\" WHERE \"Nombre\" = '{name}'";

                using (var command = new NpgsqlCommand(query, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User()
                        {
                            Name = reader["Nombre"].ToString(),
                            LastName = reader["Apellido"].ToString(),
                        };
                    }
                }
                conn.Close();
            }
            return user;
        }
    }
}
