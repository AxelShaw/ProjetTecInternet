using System.Security.Claims;
using Application.UseCases.Users.Dtos;
using Infrastructure.Ef;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
//[Route("api/v1/login")]
[Route("api/[controller]")]

public class LoginController : ControllerBase
{
    private readonly IJwtAuthentificationManager _JwtAuthentificationManager;
    private readonly IConfiguration _config;
    public LoginController(IJwtAuthentificationManager JwtAuthentificationManager, IConfiguration config)
    {
        _JwtAuthentificationManager = JwtAuthentificationManager;
        _config = config;
    }
    
    [HttpPost]
    [Route("Login")]
    public IActionResult login([FromBody] DtoInputLoginUser model)
    {
        var Dbuser = _JwtAuthentificationManager.Authenticate(model.mail, model.password);
        if (Dbuser != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Dbuser.mail),
            };
            var token = _JwtAuthentificationManager.GenerateToken(_config["Jwt:Key"], claims);
            return Ok(token);
        }
        return Unauthorized();
    }
}