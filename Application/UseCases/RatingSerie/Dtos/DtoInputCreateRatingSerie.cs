using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.RatingMovies.Dtos;

public class DtoInputCreateRatingSerie
{
    [Required]public int SerieRefId{ get; set; }
    
    [Required]public int Average_rating { get; set; }
    
    [Required]public int NumVote { get; set; }

}