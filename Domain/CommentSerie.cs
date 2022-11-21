namespace Domain;

public class CommentSerie
{
    public int IdComSerie{ get; set; }
    
    public int Rating { get; set; }
    public string CommentText { get; set; }
    
    public int IdSerieRef { get; set; }
    public int IdUserRef { get; set; }
}