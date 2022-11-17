using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchMovieByName :IUseCaseParameterizedQuery<IEnumerable<DtoOutputMovie>, string>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchMovieByName(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public IEnumerable<DtoOutputMovie> Execute(string name)
    {
        var dbUser = _movieRepository.FetchByName(name);
        return Mapper.GetInstance().Map<List<DtoOutputMovie>>(dbUser);
    }
}