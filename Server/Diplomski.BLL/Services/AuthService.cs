using Diplomski.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Diplomski.BLL.Enums;
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
        
        
        public string GenerateJwt(int role, bool isEmailVerified)
        {
            var claims = new[]
            {
                new Claim(Claims.Role.ToString(), role.ToString()),
                new Claim(Claims.IsEmailVerified.ToString(), isEmailVerified.ToString())
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

        public Dictionary<string, object> ValidateTokenAndGetClaims(string token)
        {
            JwtSecurityToken jwtToken  = ValidateToken(token);
            
            Dictionary<string, object> claims = jwtToken.Claims
                .ToDictionary(e => e.Type, e => (object)e.Value);

            return claims;
        }

        private JwtSecurityToken ValidateToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_jwtModel.Key);

            tokenHandler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = _jwtModel.Issuer,
                    ClockSkew = TimeSpan.Zero
                },
                out SecurityToken validatedToken
            );

            return (JwtSecurityToken)validatedToken;
        }
    }
}
