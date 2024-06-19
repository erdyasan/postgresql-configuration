using Npgsql;

namespace DotnetConfiguration.CustomConfiguration;

public class PostgreSqlConfigurationProvider : ConfigurationProvider
{
    public override void Load()
    {
        string connectionString = "Host=; Port=5432;Username=;Password=;Database=ConfigTest";
        string sql = "select * from \"Configs\"";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        Data = new Dictionary<string, string?>();
        using (var command = new NpgsqlCommand(sql, connection))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Data.Add(reader["Key"].ToString()!, reader["Value"].ToString());
                }
            }
        }

        connection.Close();
    }
}