using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchAllRatingMovies : IUseCaseQuery<IEnumerable<DtoOutputRatingMovie>>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchAllRatingMovies(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    //execute ratingmovie get all method
    public IEnumerable<DtoOutputRatingMovie> Execute()
    {
        var dbRatingMovie = _ratingMovieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingMovie>>(dbRatingMovie);
    }
}