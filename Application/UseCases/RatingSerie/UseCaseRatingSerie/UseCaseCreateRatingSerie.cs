using Application.UseCases.RatingMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.RatingSerie.UseCaseRatingSerie;

public class UseCaseCreateRatingSerie : IUseCaseWriter<DtoOutputRatingSerie, DtoInputCreateRatingSerie>
{
    private readonly IRatingSerieRepository _ratingSerieRepository;

    public UseCaseCreateRatingSerie(IRatingSerieRepository ratingSerieRepository)
    {
        _ratingSerieRepository = ratingSerieRepository;
    }
    
    
    public DtoOutputRatingSerie Execute(DtoInputCreateRatingSerie input)
    {
        var dbRatingSerie = _ratingSerieRepository.Create(input.Average_rating, input.NumVote, input.SerieRefId );
        return Mapper.GetInstance().Map<DtoOutputRatingSerie>(dbRatingSerie);
    }
}