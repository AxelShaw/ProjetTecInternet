using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain;

namespace Infrastructure.Ef.DbEntities;

public class DbRatingMovie
{

    public int Average_rating { get; set; }
    public int NumVote { get; set; }
    
    [Key]
    public int MovieRefId{ get; set; }
    
}