namespace Application.UseCases.CommentMovies.Dtos;

public class DtoInputCreateCommentMovie
{
    public int Rating { get; set; }
    public string CommentText { get; set; }

    public int IdMovieRef{ get; set; }
    public int IdUserRef{ get; set; }
}