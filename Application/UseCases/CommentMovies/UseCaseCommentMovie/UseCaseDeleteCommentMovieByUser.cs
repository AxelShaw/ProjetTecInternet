using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseDeleteCommentMovieByUser:  IUseCaseParameterizedQuery<DtoOutputCommentMovie, int>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseDeleteCommentMovieByUser(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    //execute commentmovie delete  comment movie method by user
    public DtoOutputCommentMovie Execute(int id)
    {
        var dbCommentMovie = _commentMovieRepository.DeleteByUser(id);
        return Mapper.GetInstance().Map<DtoOutputCommentMovie>(dbCommentMovie);
    }
}