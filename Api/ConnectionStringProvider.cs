using Infrastructure.Utils;

namespace Api;

public class ConnectionStringProvider : IConnectionStringProvider
{
    private readonly IConfiguration _configuration;

    public ConnectionStringProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    //get  connection string in appsettings.Development.json
    public string Get(string key)
    {
        return _configuration.GetConnectionString(key);
    }
}