

namespace Domain;

public class Movie
{
    public int IdMovie { get; set; }
    
    public string NameMovie { get; set; }
    
    public int RuntimeMinute { get; set; }
    
    public string MovieType { get; set; }
    
    public string DescriptionMovie { get; set; }
    
    public byte[] ImageMovie { get; set; }
    
    public string FilmGenre { get; set; }
    
    public string Director { get; set; }
    
    public string Release_movie { get; set; }
    
    //Method to check if the duration of a film is correct
    public void PositiveRuntime(int movieRuntimeMinute)
    {
        if (RuntimeMinute < 0)
        {
            RuntimeMinute = 0;
        }
        else
        {
            RuntimeMinute = movieRuntimeMinute;
        }
    }
    

}   