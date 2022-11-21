using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingSerie.UseCaseRatingSerie;

public class UseCaseFetchAllRatingSeries: IUseCaseQuery<IEnumerable<DtoOutputRatingSerie>>
{
    private readonly IRatingSerieRepository _ratingSerieRepository;

    public UseCaseFetchAllRatingSeries(IRatingSerieRepository ratingSerieRepository)
    {
        _ratingSerieRepository = ratingSerieRepository;
    }

    public IEnumerable<DtoOutputRatingSerie> Execute()
    {
        var dbUsers = _ratingSerieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputRatingSerie>>(dbUsers);
    }
}