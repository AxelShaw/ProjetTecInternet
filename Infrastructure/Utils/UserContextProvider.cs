using Infrastructure.Ef;

namespace Infrastructure.Utils;

public class UserContextProvider
{
    private readonly IConnectionStringProvider _connectionStringProvider;


    public UserContextProvider(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public UserContext NewContext()
    {
        return new UserContext(_connectionStringProvider);
    }
}