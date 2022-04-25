using Diplomski.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Enums;
using Diplomski.BLL.Helpers;
using Diplomski.BLL.Utils.AppSettingsModels;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtModel _jwtModel;
        private readonly IUserService _userService;
        
        
        public AuthService(JwtModel jwtModel, IUserService userService)
        {
            this._jwtModel = jwtModel;
            _userService = userService;
        }


        public string Login(UserLoginDto dto)
        {
            User user = _userService.Get(dto.Email);

            if (!HashHelper.IsValueEqualToHash(dto.Password, user.Password))
                throw BusinessExceptions.PasswordIncorrect;

            string token = this.GenerateJwt(user.Id, user.UserType, user.IsEmailVerified);

            return token;
        }

        public string GenerateJwt(int userId, int role, bool isEmailVerified)
        {
            var claims = new[]
            {
                new Claim(Claims.Id.ToString(), userId.ToString()),
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
