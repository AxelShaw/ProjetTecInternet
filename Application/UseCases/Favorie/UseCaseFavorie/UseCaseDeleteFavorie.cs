using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseFavorie;
public class UseCaseDeleteFavorie : IUseCaseParameterizedQuery<DtoOutputFavorie, int>
{
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseDeleteFavorie(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }

    //execute favori delete by id method
    public DtoOutputFavorie Execute(int id)
    {
        var dbFavorie = _favorieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputFavorie>(dbFavorie);
    }
}