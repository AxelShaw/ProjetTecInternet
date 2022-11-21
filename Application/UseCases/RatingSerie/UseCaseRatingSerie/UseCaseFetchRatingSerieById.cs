using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingSerie.UseCaseRatingSerie;

public class UseCaseFetchRatingSerieById : IUseCaseParameterizedQuery<DtoOutputRatingSerie, int>
{
    private readonly IRatingSerieRepository _ratingSerieRepository;

    public UseCaseFetchRatingSerieById(IRatingSerieRepository ratingSerieRepository)
    {
        _ratingSerieRepository = ratingSerieRepository;
    }

    public DtoOutputRatingSerie Execute(int id)
    {
        var dbUser = _ratingSerieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputRatingSerie>(dbUser);
    }
}