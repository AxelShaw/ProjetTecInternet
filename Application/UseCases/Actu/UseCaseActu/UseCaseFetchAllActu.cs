using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Actu.UseCaseActu;

public class UseCaseFetchAllActu : IUseCaseQuery<IEnumerable<DtoOutputActu>>
{
    private readonly IActuRepository _actuRepository;

    public UseCaseFetchAllActu(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }

    //execute news get all method
    public IEnumerable<DtoOutputActu> Execute()
    {
        var dbActu = _actuRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputActu>>(dbActu);
    }
}