using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseFavorie;
public class UseCaseDeleteFavorieById:  IUseCaseParameterizedQuery<DtoOutputFavorie, int>
{
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseDeleteFavorieById(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }
    //execute favori delete by movie method
    public DtoOutputFavorie Execute(int id)
    {
        var dbFavorie = _favorieRepository.DeleteById(id);
        return Mapper.GetInstance().Map<DtoOutputFavorie>(dbFavorie);
    }
}