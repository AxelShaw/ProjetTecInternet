using Application.UseCases.Actu.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseCommentMovie;

public class UseCaseDeleteActu : IUseCaseParameterizedQuery<DtoOutputActu, int>
{
    private readonly IActuRepository _actuRepository;

    public UseCaseDeleteActu(IActuRepository actuRepository)
    {
        _actuRepository = actuRepository;
    }

    public DtoOutputActu Execute(int id)
    {
        var dbActu = _actuRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputActu>(dbActu);
    }
}