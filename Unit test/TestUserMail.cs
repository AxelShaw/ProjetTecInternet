
using Domain;
using NUnit.Framework;

namespace Unit_test;

public class TestMailcontroller
{
    [Test]
    public void EmailFormat_Ok()
    {
        // Arrange
        var user = new User { mail = "Gunnar@gmail.com" };

        // Act
        var result = user.IsValidEmail(user.mail);

        // Assert
        Assert.IsTrue(result);
    }
    
    [Test]
    public void EmailFormat_NotOk()
    {
        // Arrange
        var user = new User { mail = "BartLeBg.com" };

        // Act
        var result = user.IsValidEmail(user.mail);

        // Assert
        Assert.IsFalse(result);
    }
    
}