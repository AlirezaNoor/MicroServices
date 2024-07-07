using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityService.ApplicationContract.Dto.user;
using IdentityService.Domain.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace IdentiyService.Infrustructure.Extensions;

public class TokenProvider : ITokenProvider
{
    public async Task<string> TokenGenator(loginUser login, string userid)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(":1YU_hq%cPU*9Sf\"]Z2zPh5~}(ig(ziPcP.xEk6q]BC3rOnemUBi9+*,tUEWe^F");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, login.username),
                new Claim("userId", userid.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

 
}