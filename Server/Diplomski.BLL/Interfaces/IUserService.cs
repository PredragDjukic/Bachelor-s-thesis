using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces
{
    public interface IUserService
    {
        UserReadDto GetRead(int id);
        User Get(int id);
        UserReadDto GetTrainerRead(int id);
        User GetTrainer(int id);
        UserReadDto GetExerciserRead(int id);
        User GetExerciser(int id);
        User Get(string email);
        User Create(UserRegisterDto dto);
        User VerifyEmail(int loggedUserId, SecretCodeUserDto dto);
        void ResendSecretCode(int loggedUserId);
        void Delete(int userId);
    }
}
