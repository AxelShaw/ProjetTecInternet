using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbRatingSerie
{
    [Key]
    public int SerieRefId{ get; set; }
    
    public int Average_rating { get; set; }
    public int NumVote { get; set; }
    

}