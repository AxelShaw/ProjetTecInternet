using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseFetchCommentMovieById : IUseCaseParameterizedQuery<DtoOutputCommentMovie, int>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseFetchCommentMovieById(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    public DtoOutputCommentMovie Execute(int id)
    {
        var dbUser = _commentMovieRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputCommentMovie>(dbUser);
    }
}