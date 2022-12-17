using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbFavorie
{
    [Key]
    public int IdFav{ get; set; }
    public int IdMovieRef { get; set; }
    public int IdUserRef { get; set; }
    

}