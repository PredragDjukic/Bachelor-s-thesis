using Diplomski.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Diplomski.BLL.Services
{
    public class AuthService : IAuthService
    {
        public string GenerateJwt(int role)
        {
            var claims = new[]
            {
                new Claim("Role", role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superlongsecretkeyforauthentification123"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(
                "FitConDev",
                "FitConDev",
                claims,
                expires: DateTime.Now.AddMinutes(90), signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
