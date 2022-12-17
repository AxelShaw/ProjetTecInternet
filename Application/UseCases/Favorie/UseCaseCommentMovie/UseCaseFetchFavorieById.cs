using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseCommentMovie;

public class UseCaseFetchFavorieById : IUseCaseParameterizedQuery<IEnumerable<DtoOutputFavorie>, int>
{
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseFetchFavorieById(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }

    public IEnumerable<DtoOutputFavorie> Execute(int id)
    {
        var dbFavorie = _favorieRepository.FetchById(id);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputFavorie>>(dbFavorie);
    }
}