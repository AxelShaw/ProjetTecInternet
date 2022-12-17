using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.Favorie.UseCaseCommentMovie;

public class UseCaseUpdateFavorie : IUseCaseParameterizedQueryUpFavorie<DtoOutputFavorie, Domain.Favorie>
{
    private readonly IFavorieRepository _favorieRepositoryy;

    public UseCaseUpdateFavorie(IFavorieRepository favorieRepository)
    {
        _favorieRepositoryy = favorieRepository;
    }


    public bool Execute(DbFavorie favorie)
    {
        var dbFavorie = _favorieRepositoryy.Update(favorie);
        return Mapper.GetInstance().Map<bool>(dbFavorie);
    }
}