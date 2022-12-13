using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchLastIdMovie : IUseCaseQuery<DtoOutputMovie>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchLastIdMovie(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public DtoOutputMovie Execute()
    {
        var dbUser = _movieRepository.FetchLastId();
        return Mapper.GetInstance().Map<DtoOutputMovie>(dbUser);
    }
}