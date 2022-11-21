using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentSeries.UseCase;

public class UseCaseFetchAllCommentSeries : IUseCaseQuery<IEnumerable<DtoOutputCommentSerie>>
{
    private readonly ICommentSerieRepository _commentSerieRepository;

    public UseCaseFetchAllCommentSeries(ICommentSerieRepository commentSerieRepository)
    {
        _commentSerieRepository = commentSerieRepository;
    }

    public IEnumerable<DtoOutputCommentSerie> Execute()
    {
        var dbUsers = _commentSerieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputCommentSerie>>(dbUsers);
    }
}