using Application.UseCases;
using Application.UseCases.Users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly UseCaseCreateUser _useCaseCreateUser;

    public UserController(UseCaseCreateUser useCaseCreateUser)
    {
        _useCaseCreateUser = useCaseCreateUser;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
    {
        var output = _useCaseCreateUser.Execute(dto);
        return CreatedAtAction(
            nameof(FetchById),
            new { id = output.IdUser },
            output
        );
    }
}