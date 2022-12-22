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
    
    //send a token if user information are correct
    [HttpPost]
    public IActionResult login([FromBody] DtoInputLoginUser model)
    {
        var Dbuser = _JwtAuthentificationManager.Authenticate(model.mail, model.password);
        if (Dbuser != null)
        {
            var claims = new List<Claim>
            {
                new Claim("id", Dbuser.IdUser.ToString()),
                new Claim("Role", Dbuser.role),
            };
            //generate a token
            var token = _JwtAuthentificationManager.GenerateToken(_config["Jwt:Key"], claims);
            
            Response.Cookies.Append("UserInfo", token, new CookieOptions()
            {
                HttpOnly = false,
                Secure = true
            });
            
            return Ok(token);
        }
        
        return Unauthorized();
    }
}