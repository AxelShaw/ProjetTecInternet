using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingSerie.UseCaseRatingSerie;

public class UseCaseDeleteRatingSerie: IUseCaseParameterizedQuery<DtoOutputRatingSerie, int>
{
    private readonly IRatingSerieRepository _ratingSerieRepository;

    public UseCaseDeleteRatingSerie(IRatingSerieRepository ratingSerieRepository)
    {
        _ratingSerieRepository = ratingSerieRepository;
    }

    public DtoOutputRatingSerie Execute(int id)
    {
        var dbUser = _ratingSerieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputRatingSerie>(dbUser);
    }
}