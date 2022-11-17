using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbCommentMovie
{
    [Key]
    public int IdComMovie{ get; set; }
    
    public int Rating { get; set; }
    public string CommentText { get; set; }
    
    public int IdMovieRef { get; set; }
    public int IdUserRef { get; set; }
    

}