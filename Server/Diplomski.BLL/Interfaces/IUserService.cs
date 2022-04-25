using Diplomski.BLL.DTOs.UserDtos;

namespace Diplomski.BLL.Interfaces
{
    public interface IUserService
    {
        string Register(UserRegisterDto dto);
        string VerifyEmail(int loggedUserId, SecretCodeUserDto dto);
        void ResendSecretCode(int loggedUserId);
    }
}
