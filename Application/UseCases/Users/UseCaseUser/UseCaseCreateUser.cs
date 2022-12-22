using Application.UseCases.Movies.Dtos;
using Application.UseCases.Users.Dtos;
using Application.UseCases.Utils;
using Infrastructure.Ef;

namespace Application.UseCases;

public class UseCaseCreateUser : IUseCaseWriter<DtoOutputUser, DtoInputCreateUser>
{
    private readonly IUserRepository _userRepository;

    public UseCaseCreateUser(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    //execute user create method
    public DtoOutputUser Execute(DtoInputCreateUser input)
    {
        var dbUser = _userRepository.Create(input.last_name, input.first_name, input.mail, input.nickname,
            input.password, input.role, input.profil_picture);

        return Mapper.GetInstance().Map<DtoOutputUser>(dbUser);
    }
}