using Application.UseCases.Movies.Dtos;
using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseFetchByNameUser :IUseCaseParameterizedQuery<IEnumerable<DtoOutputUser>, string>
{
    private readonly IUserRepository _userRepository;

    public UseCaseFetchByNameUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<DtoOutputUser> Execute(string nickname)
    {
        var dbUser = _userRepository.FetchByName(nickname);
        return Mapper.GetInstance().Map<List<DtoOutputUser>>(dbUser);
    }
}