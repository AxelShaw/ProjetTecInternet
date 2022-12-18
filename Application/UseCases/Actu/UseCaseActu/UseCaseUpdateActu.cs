using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Actu.UseCaseActu;

public class UseCaseUpdateActu : IUseCaseParameterizedQueryUpActu<DtoOutputActu, Domain.Actu>
{
    private readonly IActuRepository _actuRepository;

    public UseCaseUpdateActu(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }


    public bool Execute(DbActu actu)
    {
        var dbActu = _actuRepository.Update(actu);
        return Mapper.GetInstance().Map<bool>(dbActu);
    }
}