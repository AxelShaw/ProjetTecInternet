using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Actu.UseCaseCommentMovie;

public class UseCaseCreateActu : IUseCaseWriter<DtoOutputActu, DtoInputCreateActu>
{    
    private readonly IActuRepository _actuRepository;

    public UseCaseCreateActu(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }
    
    
    public DtoOutputActu Execute(DtoInputCreateActu input)
    {
        var dbActu = _actuRepository.Create(input.IdMovieRef,input.NewsActu,input.Release_actu);
        return Mapper.GetInstance().Map<DtoOutputActu>(dbActu);
    }
}