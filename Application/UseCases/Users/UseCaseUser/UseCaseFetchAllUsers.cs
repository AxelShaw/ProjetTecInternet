using Application.UseCases.Movies.Dtos;
using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchAllUsers : IUseCaseQuery<IEnumerable<DtoOutputUser>>
{
    private readonly IUserRepository _userRepository;

    public UseCaseFetchAllUsers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //execute user get all method
    public IEnumerable<DtoOutputUser> Execute()
    {
        var dbUsers = _userRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputUser>>(dbUsers);
    }
}