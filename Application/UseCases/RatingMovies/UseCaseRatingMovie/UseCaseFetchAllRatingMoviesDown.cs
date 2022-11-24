using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchAllRatingMoviesDown : IUseCaseQuery<IEnumerable<DtoOutputRatingMovie>>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchAllRatingMoviesDown(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    public IEnumerable<DtoOutputRatingMovie> Execute()
    {
        var dbUsers = _ratingMovieRepository.FetchAllDown();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingMovie>>(dbUsers);
    }
}