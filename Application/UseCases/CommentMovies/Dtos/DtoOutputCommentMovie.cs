namespace Application.UseCases.CommentMovies.Dtos;

public class DtoOutputCommentMovie
{
    public int IdComMovie{ get; set; }
    public int Rating { get; set; }
    public string CommentText { get; set; }

    public int IdMovieRef{ get; set; }
    public int IdUserRef{ get; set; }
}