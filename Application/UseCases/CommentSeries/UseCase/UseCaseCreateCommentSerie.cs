using Application.UseCases.CommentSeries.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentSeries.UseCase;

public class UseCaseCreateCommentSerie : IUseCaseWriter<DtoOutputCommentSerie, DtoInputCreateCommentSerie>
{    
    private readonly ICommentSerieRepository _commentSerieRepository;

    public UseCaseCreateCommentSerie(ICommentSerieRepository commentSerieRepository)
    {
        _commentSerieRepository = commentSerieRepository;
    }
    
    
    public DtoOutputCommentSerie Execute(DtoInputCreateCommentSerie input)
    {
        var dbCommentSerie = _commentSerieRepository.Create(input.Rating, input.CommentText,input.IdSerieRef,input.IdUserRef);
        return Mapper.GetInstance().Map<DtoOutputCommentSerie>(dbCommentSerie);
    }
}