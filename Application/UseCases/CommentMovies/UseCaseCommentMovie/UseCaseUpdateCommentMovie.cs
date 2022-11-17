using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseUpdateCommentMovie
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseUpdateCommentMovie(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    public bool Execute(DbCommentMovie CommentMovie)
    {
        var dbUser = _commentMovieRepository.Update(CommentMovie);
        return Mapper.GetInstance().Map<bool>(dbUser);
    }
}