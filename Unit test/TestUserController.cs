using Api.Controllers.User;
using Application.UseCases;
using Application.UseCases.Users.Dtos;
using Infrastructure.Ef;
using NUnit.Framework;

namespace Unit_test;

public class TestUserController
{
    [Test]
    public void TestCreate(DtoInputCreateUser user)
    {
        UserRepository userRepository = new UserRepository();
        
        
        UseCaseCreateUser _useCaseCreateUser=new UseCaseCreateUser(userRepository);
//        UserController controller = new UserController(_useCaseCreateUser);
        DtoInputCreateUser input = new DtoInputCreateUser();
        DtoOutputUser output = new DtoOutputUser();
        _useCaseCreateUser.Execute(input);
        Assert.Equals(output,input);
    }
}