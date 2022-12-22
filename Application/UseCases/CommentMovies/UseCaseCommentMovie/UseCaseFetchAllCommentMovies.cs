using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseFetchAllCommentMovies : IUseCaseQuery<IEnumerable<DtoOutputCommentMovie>>
{
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseFetchAllCommentMovies(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }

    //execute comment movie get all method 
    public IEnumerable<DtoOutputCommentMovie> Execute()
    {
        var dbCommentMovie = _commentMovieRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputCommentMovie>>(dbCommentMovie);
    }
}