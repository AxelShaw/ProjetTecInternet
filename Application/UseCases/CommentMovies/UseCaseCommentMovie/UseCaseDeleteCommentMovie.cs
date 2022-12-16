using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseDeleteCommentMovie : IUseCaseParameterizedQuery<DtoOutputCommentMovie, int>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseDeleteCommentMovie(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    public DtoOutputCommentMovie Execute(int id)
    {
        var dbCommentMovie = _commentMovieRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputCommentMovie>(dbCommentMovie);
    }
}