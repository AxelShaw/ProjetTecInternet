using System.Globalization;
using Domain;
using NUnit.Framework;

namespace Unit_test;

public class TestDateReleaseActu
{
    [Test]
    public void TestReleaseActuFormat_Ok()
    {
        // Arrange
        Actu actu = new Actu { Release_actu = "12/23/2022" };

        // Actu
        var result = actu.IsValidateDate(actu.Release_actu);
        
        
        // Assert
        Assert.IsTrue(result);
    }
    
    [Test]
    public void TestReleaseActuFormat_NotOk()
    {
        // Arrange
        Actu actu = new Actu { Release_actu = "19/87/1987" };

        // Actu
        var result = actu.IsValidateDate(actu.Release_actu);
        
        
        // Assert
        Assert.IsFalse(result);
    }
    
    
}