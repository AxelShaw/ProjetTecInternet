using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.RatingMovies.Dtos;

public class DtoInputCreateRatingMovie
{
    
    [Required]public int Average_rating { get; set; }
    [Required]public int NumVote { get; set; }

    [Required]public int MovieRefId{ get; set; }

}