using Domain;
using NUnit.Framework;

namespace Unit_test;

public class TestRuntimeMinuteMovie
{
    [Test]
    public void TestRuntimeMovie_Ok()
    {
        // Arrange
        var movie = new Movie();


        // Act
        movie.PositiveRuntime(30);

        // Assert
        Assert.AreEqual(30, movie.RuntimeMinute);

    }

    [Test]
    public void TestRuntimeMovie_NotOk()
    {
        // Arrange
        var movie = new Movie();


        // Act
        movie.PositiveRuntime(-100);


        // Assert
        Assert.AreEqual(0, movie.RuntimeMinute);

    }
}