namespace Domain;

public class CommentMovie
{
    public int IdComMovie{ get; set; }
    
    public int Rating { get; set; }
    public string CommentText { get; set; }
    
    public int IdMovieRef { get; set; }
    public int IdUserRef { get; set; }
}