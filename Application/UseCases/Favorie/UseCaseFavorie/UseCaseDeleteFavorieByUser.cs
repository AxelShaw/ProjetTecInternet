using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseFavorie;
public class UseCaseDeleteFavorieByUser:  IUseCaseParameterizedQuery<DtoOutputFavorie, int>
{
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseDeleteFavorieByUser(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }
    
    //execute favori delete by user method
    public DtoOutputFavorie Execute(int id)
    {
        var dbFavorie = _favorieRepository.DeleteByUser(id);
        return Mapper.GetInstance().Map<DtoOutputFavorie>(dbFavorie);
    }
}