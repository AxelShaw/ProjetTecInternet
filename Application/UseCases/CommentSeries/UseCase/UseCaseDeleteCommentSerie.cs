using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentSeries.UseCase;

public class UseCaseDeleteCommentSerie : IUseCaseParameterizedQuery<DtoOutputCommentSerie, int>
{
    private readonly ICommentSerieRepository _commentSerieRepository;

    public UseCaseDeleteCommentSerie(ICommentSerieRepository commentSerieRepository)
    {
        _commentSerieRepository = commentSerieRepository;
    }

    public DtoOutputCommentSerie Execute(int id)
    {
        var dbUser = _commentSerieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputCommentSerie>(dbUser);
    }
}