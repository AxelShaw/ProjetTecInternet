using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseUpdateCommentMovie : IUseCaseParameterizedQueryUpCommentMovie<DtoOutputCommentMovie, CommentMovie>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseUpdateCommentMovie(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    public bool Execute(DbCommentMovie CommentMovie)
    {
        var dbCommentMovie = _commentMovieRepository.Update(CommentMovie);
        return Mapper.GetInstance().Map<bool>(dbCommentMovie);
    }
}