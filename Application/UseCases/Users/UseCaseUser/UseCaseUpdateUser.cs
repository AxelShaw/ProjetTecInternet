using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Domain;
using Infrastructure.Ef;
using Infrastructure.Ef.DbEntities;

namespace Application.UseCases;

public class UseCaseUpdateUser : IUseCaseParameterizedQueryUpUser<DtoOutputUser, User>
{
    private readonly IUserRepository _userRepository;

    public UseCaseUpdateUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //execute user update method
    public bool Execute(DbUser user)
    {
        var dbUser = _userRepository.Update(user);
        return Mapper.GetInstance().Map<bool>(dbUser);
    }
    
}