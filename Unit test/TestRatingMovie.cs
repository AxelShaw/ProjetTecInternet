using Domain;
using NUnit.Framework;

namespace Unit_test;

//test on rating movie
public class TestRatingMovie
{
    [Test]
    public void TestAverageRating()
    {
        // Arrange
        RatingMovie movie = new RatingMovie();

        // Act
        movie.AverageRating(5);
        movie.AverageRating(3);
        movie.AverageRating(4);

        // Assert
        Assert.AreEqual(4, movie.Average_rating);
    }

}