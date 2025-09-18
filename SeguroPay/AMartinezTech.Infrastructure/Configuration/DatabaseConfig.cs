using System.Text.Json;

namespace AMartinezTech.Infrastructure.Configuration;

public class DatabaseConfig
{
    public string Server { get; private set; }
    public string Database { get; private set; }
    private string User { get; set; }
    private string Password { get; set; }

    public string GetConnectionString()
    {
        var server = string.IsNullOrWhiteSpace(Server) ? "localhost" : Server;
        var database = string.IsNullOrWhiteSpace(Database) ? "Insurance" : Database;

        if (!string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Password))
        {
            return $"Server={server};Database={database};User Id={User};Password={Password};";
        }

        return $"Server={server};Database={database};Trusted_Connection=True;";
    }

    public static DatabaseConfig Load(string path)
    {
        var json = File.ReadAllText(path);
        var doc = JsonSerializer.Deserialize<JsonDocument>(json);
        var dbElement = doc!.RootElement.GetProperty("DatabaseLocation");

        return new DatabaseConfig
        {
            Server = dbElement.GetProperty("Server")!.GetString()!,
            Database = dbElement.GetProperty("Database")!.GetString()!,
            User = "sa",
            Password = "A36m21c722414"
        };
    }
}
