using Domain;
using NUnit.Framework;

namespace Unit_test;

public class TestRatingMovie
{
    [Test]
    public void TestAverageRating()
    {
        RatingMovie movie = new RatingMovie();

        
        movie.AverageRating(5);
        movie.AverageRating(3);
        movie.AverageRating(4);

        
        Assert.AreEqual(4, movie.Average_rating);
    }

}