using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces
{
    public interface IUserService
    {
        UserReadDto Get(int id);
        User GetById(string email);
        User Create(UserRegisterDto dto);
        User VerifyEmail(int loggedUserId, SecretCodeUserDto dto);
        void ResendSecretCode(int loggedUserId);
    }
}
