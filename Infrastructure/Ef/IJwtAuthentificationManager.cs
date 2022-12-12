using System.Security.Claims;
using System.Text;
using Infrastructure.Ef.DbEntities;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Ef;

public interface IJwtAuthentificationManager
{
    DbUser Authenticate (string mail, string password);

    string GenerateToken(string secret, List<Claim> claims);
}