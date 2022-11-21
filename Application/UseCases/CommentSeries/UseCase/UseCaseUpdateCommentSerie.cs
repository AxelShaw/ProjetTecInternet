using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.CommentSeries.UseCase;

public class UseCaseUpdateCommentSerie : IUseCaseParameterizedQueryUpCommentSerie<DtoOutputCommentSerie, CommentSerie>
{
    private readonly ICommentSerieRepository _commentSerieRepository;

    public UseCaseUpdateCommentSerie(ICommentSerieRepository commentSerieRepository)
    {
        _commentSerieRepository = commentSerieRepository;
    }

    public bool Execute(DbCommentSerie CommentSerie)
    {
        var dbUser = _commentSerieRepository.Update(CommentSerie);
        return Mapper.GetInstance().Map<bool>(dbUser);
    }
}