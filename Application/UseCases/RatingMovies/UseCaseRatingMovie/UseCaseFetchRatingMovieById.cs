using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseFetchRatingMovieById : IUseCaseParameterizedQuery<DtoOutputRatingMovie, int>
{    
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseFetchRatingMovieById(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }

    public DtoOutputRatingMovie Execute(int id)
    {
        var dbUser = _ratingMovieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputRatingMovie>(dbUser);
    }
}