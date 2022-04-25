using Diplomski.BLL.DTOs.UserDtos;

namespace Diplomski.BLL.Interfaces
{
    public interface IAuthService
    {
        string Register(UserRegisterDto dto);
        string Login(UserLoginDto dto);
        string VerifyEmail(int loggedUserId, SecretCodeUserDto dto);
    }
}
