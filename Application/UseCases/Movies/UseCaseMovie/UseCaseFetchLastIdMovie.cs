using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchLastIdMovie : IUseCaseQuery<int>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchLastIdMovie(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public int Execute()
    {
        var dbUser = _movieRepository.FetchLastId();
        return Mapper.GetInstance().Map<Int32>(dbUser);
    }
}