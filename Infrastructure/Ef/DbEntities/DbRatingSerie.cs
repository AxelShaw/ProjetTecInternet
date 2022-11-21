using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Ef.DbEntities;

public class DbRatingSerie
{

    
    public int Average_rating { get; set; }
    public int NumVote { get; set; }
    
    [Key]
    public int SerieRefId{ get; set; }
    

}