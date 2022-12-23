namespace Domain;

public class RatingMovie
{

    public int Average_rating { get; set; }
    
    public int NumVote { get; set; }

    public int MovieRefId{ get; set; }
    
    //Method to check if the average rating is correct
    public void AverageRating(int i)
    {
        if (Average_rating!=0)
        {
            Average_rating += i;
            Average_rating /= 2;
        }
        else
        {
            Average_rating = i;
        }

    }
    
}