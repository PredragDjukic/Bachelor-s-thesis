using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces
{
    public interface IUserService
    {
        User Get(string email);
        string Register(UserRegisterDto dto);
        string VerifyEmail(int loggedUserId, SecretCodeUserDto dto);
        void ResendSecretCode(int loggedUserId);
    }
}
