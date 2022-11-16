using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseDeleteRatingMovie: IUseCaseParameterizedQuery<DtoOutputRatingMovie, int>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseDeleteRatingMovie(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    public DtoOutputRatingMovie Execute(int id)
    {
        var dbUser = _ratingMovieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputRatingMovie>(dbUser);
    }
}