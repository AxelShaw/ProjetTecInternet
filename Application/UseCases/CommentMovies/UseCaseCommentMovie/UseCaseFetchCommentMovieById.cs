using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseFetchCommentMovieById : IUseCaseParameterizedQuery<IEnumerable<DtoOutputCommentMovie>, int>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseFetchCommentMovieById(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    public IEnumerable<DtoOutputCommentMovie> Execute(int id)
    {
        var dbCommentMovie = _commentMovieRepository.FetchById(id);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputCommentMovie>>(dbCommentMovie);
    }
}