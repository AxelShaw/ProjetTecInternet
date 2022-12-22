using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseDeleteUser : IUseCaseParameterizedQuery<DtoOutputUser, int>
{
    private readonly IUserRepository _userRepository;

    public UseCaseDeleteUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //execute user delete by id method
    public DtoOutputUser Execute(int id)
    {
        var dbUser = _userRepository.Delete(id);
        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}