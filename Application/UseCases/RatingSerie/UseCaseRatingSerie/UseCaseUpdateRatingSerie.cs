
using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;

using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.RatingSerie.UseCaseRatingSerie;

public class UseCaseUpdateRatingSerie : IUseCaseParameterizedQueryUpRatingSerie<DtoOutputRatingSerie, Domain.RatingSerie>
{
    private readonly IRatingSerieRepository _ratingSerieRepository;

    public UseCaseUpdateRatingSerie(IRatingSerieRepository ratingSerieRepository)
    {
        _ratingSerieRepository = ratingSerieRepository;
    }

    public bool Execute(DbRatingSerie ratingSerie)
    {
        var dbUser = _ratingSerieRepository.Update(ratingSerie);
        return Mapper.GetInstance().Map<bool>(dbUser);
    }
}