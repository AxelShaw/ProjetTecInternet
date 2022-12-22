using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Actu.UseCaseActu;

public class UseCaseFetchActuById : IUseCaseParameterizedQuery<IEnumerable<DtoOutputActu>, int>
{
    private readonly IActuRepository _actuRepository;

    public UseCaseFetchActuById(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }
    //execute news get by Id method with id to dtoOutput
    public IEnumerable<DtoOutputActu> Execute(int id)
    {
        var dbActu = _actuRepository.FetchById(id);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputActu>>(dbActu);
    }
}