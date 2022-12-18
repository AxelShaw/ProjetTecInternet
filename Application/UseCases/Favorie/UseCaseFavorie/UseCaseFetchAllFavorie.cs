using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseFavorie;
public class UseCaseFetchAllFavorie : IUseCaseQuery<IEnumerable<DtoOutputFavorie>>
{
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseFetchAllFavorie(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }

    public IEnumerable<DtoOutputFavorie> Execute()
    {
        var dbFavories = _favorieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputFavorie>>(dbFavories);
    }
}