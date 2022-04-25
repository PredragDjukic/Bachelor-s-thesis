using Diplomski.BLL.DTOs.UserDtos;

namespace Diplomski.BLL.Interfaces
{
    public interface IAuthService
    {
        string Login(UserLoginDto dto);
        string GenerateJwt(int userId, int role, bool isEmailVerified);
        Dictionary<string, object> ValidateTokenAndGetClaims(string token);
    }
}
