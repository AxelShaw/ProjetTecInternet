using Application.UseCases.CommentMovies.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases.CommentMovies.UseCaseCommentMovie;

public class UseCaseCreateCommentMovie : IUseCaseWriter<DtoOutputCommentMovie, DtoInputCreateCommentMovie>
{    
    private readonly ICommentMovieRepository _commentMovieRepository;

    public UseCaseCreateCommentMovie(ICommentMovieRepository commentMovieRepository)
    {
        _commentMovieRepository = commentMovieRepository;
    }
    
    //execute create commentmovie method with dtoinputcreatemovie to output
    public DtoOutputCommentMovie Execute(DtoInputCreateCommentMovie input)
    {
        var dbCommentMovie = _commentMovieRepository.Create(input.Rating, input.CommentText,input.IdMovieRef,input.IdUserRef);
        return Mapper.GetInstance().Map<DtoOutputCommentMovie>(dbCommentMovie);
    }
}