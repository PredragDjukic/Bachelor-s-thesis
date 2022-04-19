using Diplomski.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Diplomski.BLL.Utils.AppSettingsModels;
using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtModel _jwtModel;
        public AuthService(JwtModel jwtModel)
        {
            this._jwtModel = jwtModel;
        }
        
        
        public string GenerateJwt(int role)
        {
            var claims = new[]
            {
                new Claim("Role", role.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._jwtModel.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(
                _jwtModel.Issuer,
                _jwtModel.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(LiteralConsts.JwtTokenExpiryInMinutes), signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
