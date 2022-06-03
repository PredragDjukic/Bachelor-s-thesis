using Diplomski.BLL.DTOs.PaymentDTOs;
using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Utils.Models;
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
        void AddCardToUser(int id, CardModel model);
        IEnumerable<CardReadDto> GetUserCards(int id);
        CardReadDto GetDefaultCard(int id);
        CardReadDto SetUpDefaultCard(int id, string cardId);
        void DeleteCard(int userId, string cardId);
    }
}
