using Domain;
using NUnit.Framework;

namespace Unit_test;

public class TestUserPassword
{
    [Test]
    public void TestSecurePassword_Ok()
    {
        // Arrange
        var user = new User { password = "MySup3rPassword" };
        
        // Act
        var isSecure = user.IsSecurePassword(user.password);

        // Assert
        Assert.IsTrue(isSecure);
    }

    [Test]
    public void TestSecurePassword_Not_Ok()
    {
        // Arrange
        var user = new User { password = "mysup3rpassword" };
        
        // Act
        var isSecure = user.IsSecurePassword(user.password);

        // Assert
        Assert.IsFalse(isSecure);
    }
}