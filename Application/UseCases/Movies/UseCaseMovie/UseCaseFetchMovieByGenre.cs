using Application.UseCases.Movies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchMovieByGenre :IUseCaseParameterizedQuery<IEnumerable<DtoOutputMovie>, string>
{
    private readonly IMovieRepository _movieRepository;

    public UseCaseFetchMovieByGenre(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public IEnumerable<DtoOutputMovie> Execute(string genre)
    {
        var dbMovie = _movieRepository.FetchByGenre(genre);
        return Mapper.GetInstance().Map<List<DtoOutputMovie>>(dbMovie);
    }
}