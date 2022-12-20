using System.Security.Claims;
using Application.UseCases.Users.Dtos;
using Infrastructure.Ef;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
[Route("api/v1/login")]


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
    public IActionResult login([FromBody] DtoInputLoginUser model)
    {
        var Dbuser = _JwtAuthentificationManager.Authenticate(model.mail, model.password);
        if (Dbuser != null)
        {
            var claims = new List<Claim>
            {
                new Claim("id", Dbuser.IdUser.ToString()),
                new Claim("FirstName", Dbuser.first_name),
                new Claim("LastName", Dbuser.last_name),
                new Claim("Adresse mail", Dbuser.mail),
                new Claim("Password", Dbuser.password),
                new Claim("Role", Dbuser.role),
            };
            var token = _JwtAuthentificationManager.GenerateToken(_config["Jwt:Key"], claims);
            
            Response.Cookies.Append("cookie", token, new CookieOptions()
            {
                HttpOnly = true,
                Secure = true
            });
            
            return Ok(token);
        }
        
        return Unauthorized();
    }
}