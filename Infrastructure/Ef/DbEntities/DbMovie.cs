using System.ComponentModel.DataAnnotations;
using Domain;

namespace Infrastructure.Ef.DbEntities;

public class DbMovie
{
    [Key]
    public int IdMovie { get; set; }
    
    public string NameMovie { get; set; }
    
    public int RuntimeMinute { get; set; }

    public string MovieType { get; set; }
    
    public string DescriptionMovie { get; set; }
    
    public string ImageMovie { get; set; }
    
    public string FilmGenre { get; set; }
    
    public string Director { get; set; }
    
    public string Release_movie { get; set; }
    
}