using Application.UseCases.Favorie.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.Favorie.UseCaseCommentMovie;

public class UseCaseCreateFavorie : IUseCaseWriter<DtoOutputFavorie, DtoInputCreateFavorie>
{    
    private readonly IFavorieRepository _favorieRepository;

    public UseCaseCreateFavorie(IFavorieRepository favorieRepository)
    {
        _favorieRepository = favorieRepository;
    }
    
    
    public DtoOutputFavorie Execute(DtoInputCreateFavorie input)
    {
        var dbFavorie = _favorieRepository.Create(input.IdMovieRef,input.IdUserRef);
        return Mapper.GetInstance().Map<DtoOutputFavorie>(dbFavorie);
    }
}