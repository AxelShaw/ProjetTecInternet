using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Infrastructure.Ef.DbEntities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Ef
{
    public class JwtAuthentificationManager :  IJwtAuthentificationManager
    {
        private readonly List<DbUser> Users = new List<DbUser>()
        {
            new DbUser()
            {
                IdUser = 1,
                mail = "Afton@gmail.com",
                password = "remnant"
            },
            new DbUser()
            {
                IdUser = 2,
                mail = "Maxence@gmail.com",
                password = "1234"
                
            }
        };
        
        public DbUser Authenticate(string mail, string password)
        {
            return Users.Where(u => u.mail.ToUpper().Equals(mail.ToUpper()) 
                                    && u.password.Equals(password)).FirstOrDefault();
        }
        
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
}