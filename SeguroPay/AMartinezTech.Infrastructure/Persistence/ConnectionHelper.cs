using Microsoft.Extensions.Configuration;

namespace AMartinezTech.Infrastructure.Persistence;

public static class ConnectionHelper 
{
    private static IConfiguration _configuration;

    public static void Init(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static string GetConnectionString(string user, string password)
    {
        if (_configuration == null)
            throw new InvalidOperationException("Debes inicializar ConnectionHelper con IConfiguration");

        var template = _configuration.GetConnectionString("DefaultConnection");
        return string.Format(template, user, password);
    }
}
