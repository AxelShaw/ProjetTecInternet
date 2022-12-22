using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.RatingMovies.UseCaseRatingMovie;

public class UseCaseUpdateRatingMovie : IUseCaseParameterizedQueryUpRatingMovie<DtoOutputRatingMovie, RatingMovie>
{
    private readonly IRatingMovieRepository _ratingMovieRepository;

    public UseCaseUpdateRatingMovie(IRatingMovieRepository ratingMovieRepository)
    {
        _ratingMovieRepository = ratingMovieRepository;
    }
    //execute update rating movie method
    public bool Execute(DbRatingMovie ratingMovie)
    {
        var dbRatingMovie = _ratingMovieRepository.Update(ratingMovie);
        return Mapper.GetInstance().Map<bool>(dbRatingMovie);
    }
}