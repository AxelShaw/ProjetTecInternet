using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchUserById: IUseCaseParameterizedQuery<DtoOutputUser, int>
{
    private readonly IUserRepository _userRepository;

    public UseCaseFetchUserById(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //execute user get by id method
    public DtoOutputUser Execute(int id)
    {
        var dbUser = _userRepository.FetchById(id);
        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}