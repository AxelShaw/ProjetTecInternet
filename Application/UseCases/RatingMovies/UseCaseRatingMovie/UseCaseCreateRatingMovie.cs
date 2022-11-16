using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseCreateRatingMovie : IUseCaseWriter<DtoOutputRatingMovie, DtoInputCreateRatingMovie>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseCreateRatingMovie(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }
    
    
    public DtoOutputRatingMovie Execute(DtoInputCreateRatingMovie input)
    {
        var dbRatingMovie = _ratingMovieRepository.Create(input.Average_rating, input.NumVote, input.MovieRefId );
        return Mapper.GetInstance().Map<DtoOutputRatingMovie>(dbRatingMovie);
    }
}