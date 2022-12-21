using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseIsPresentUser: IUseCaseParameterizedQuery<Boolean, string>
{
    private readonly IUserRepository _userRepository;

    public UseCaseIsPresentUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public bool Execute(string mail)
    {
        var dbUser = _userRepository.IsPresentMail(mail);
        return Mapper.GetInstance().Map<Boolean>(dbUser);
    }
}