using Application.UseCases;
using Application.UseCases.Users.Dtos;
using Infrastructure.Ef.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
    private readonly UseCaseCreateUser _useCaseCreateUser;
    private readonly UseCaseFetchAllUsers _useCaseFetchAllUsers;
    private readonly UseCaseFetchUserById _useCaseFetchUserById;
    private readonly UseCaseDeleteUser _useCaseDeleteUser;
    private readonly UseCaseUpdateUser _useCaseUpdateUser;
    private readonly UseCaseFetchByNameUser _useCaseFetchByNameUser;
    private readonly UseCaseIsPresentUser _useCaseIsPresentUser;

    public UserController(UseCaseCreateUser useCaseCreateUser, UseCaseFetchAllUsers useCaseFetchAllUsers,
        UseCaseFetchUserById useCaseFetchUserById, UseCaseDeleteUser useCaseDeleteUser,
        UseCaseUpdateUser useCaseUpdateUser, UseCaseFetchByNameUser useCaseFetchByNameUser, 
        UseCaseIsPresentUser useCaseIsPresentUser)
    {
        _useCaseCreateUser = useCaseCreateUser;
        _useCaseFetchAllUsers = useCaseFetchAllUsers;
        _useCaseFetchUserById = useCaseFetchUserById;
        _useCaseDeleteUser = useCaseDeleteUser;
        _useCaseUpdateUser = useCaseUpdateUser;
        _useCaseFetchByNameUser = useCaseFetchByNameUser;
        _useCaseIsPresentUser = useCaseIsPresentUser;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchAll()
    {
        return Ok(_useCaseFetchAllUsers.Execute());
    }
    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser> FetchById(int id)
    {
        try
        {
            return _useCaseFetchUserById.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputUser>  Delete(int id)
    {
        try
        {
            return _useCaseDeleteUser.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputUser> Create(DtoInputCreateUser dto)
    {
        var output = _useCaseCreateUser.Execute(dto);
        try
        {
            return CreatedAtAction(
                nameof(FetchById),
                new { id = output.IdUser },
                output
            );
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new
            {
                e.Message
            });
        }
        
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Update(DbUser user)
    {
        return _useCaseUpdateUser.Execute(user) ? NoContent() : NotFound();
    }
    [HttpGet]
    [Route("{nickname}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<DtoOutputUser>> FetchByName(string nickname)
    {
        return Ok(_useCaseFetchByNameUser.Execute(nickname));
    }
    [HttpGet]
    [Route("mail/{mail}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Boolean> IsPresentMail(string mail)
    {
        return _useCaseIsPresentUser.Execute(mail);
    }
}