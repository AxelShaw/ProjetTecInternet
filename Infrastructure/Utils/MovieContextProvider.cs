using Infrastructure.Ef;

namespace Infrastructure.Utils;

public class MovieContextProvider
{
    private readonly IConnectionStringProvider _connectionStringProvider;


    public MovieContextProvider(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public MovieContext NewContext()
    {
        return new MovieContext(_connectionStringProvider);
    }
}