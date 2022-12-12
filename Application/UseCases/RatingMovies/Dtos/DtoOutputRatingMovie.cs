namespace Application.UseCases.RatingMovies.Dtos;

public class DtoOutputRatingMovie
{
    public int Average_rating { get; set; }
    
    public int NumVote { get; set; }
    public int MovieRefId{ get; set; }
}