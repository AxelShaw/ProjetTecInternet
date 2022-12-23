using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain;
using Infrastructure.Ef.DbEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Ef;

public class JwtAuthentificationManager :  IJwtAuthentificationManager
{
    private readonly IUserRepository _users;
    private readonly IConfiguration _config;

    private readonly IEnumerable<DbUser> Users = new List<DbUser>();


    //connection to our database
    public JwtAuthentificationManager(IUserRepository user, IConfiguration config)
    {
        _users = user;
        _config = config;
        Users = _users.FetchAll();

    }
   
    //authentifcate a user to check if he is in database
    public DbUser Authenticate(string mail, string password)
    {
        //set encryption method
        SHA256 sha256Hash = SHA256.Create();
        //get hash of password
        var passwordHashVerif = HashedPassword.GetHash(sha256Hash, password);
            
        return Users.Where(u => u.mail.ToUpper().Equals(mail.ToUpper()) 
                                && u.password.Equals(passwordHashVerif.ToString())).FirstOrDefault();
        
    }
    
    //generate a token
    public string GenerateToken(string secret, List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var TokenHandler = new JwtSecurityTokenHandler();
        var token = TokenHandler.CreateToken(tokenDescriptor);
        return TokenHandler.WriteToken(token);
    }
}
