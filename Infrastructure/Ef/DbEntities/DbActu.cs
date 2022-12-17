using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbActu
{
    [Key]
    public int IdActu{ get; set; }
    public int IdMovieRef { get; set; }
    public string NewsActu { get; set; }
    public string Release_actu { get; set; }
    
}