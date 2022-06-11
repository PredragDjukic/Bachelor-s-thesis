using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces
{
    public interface IUserRepository
    {
        User? Get(int id);
        User? Get(string email);
        User? GetTrainer(int id);
        User? GetExerciser(int id);
        void Create(User entity);
        bool CheckIfExistsByEmail(string email);
        bool CheckIfExistsByPhoneNumber(string phoneNumber);
        User Update(User entity);
        void Delete(User entity);
        IQueryable<User> GetAllTrainers();
        IQueryable<User> SearchTrainerByFullName(string fullName);
        IQueryable<User> SearchTrainerByUsername(string username);
    }
}
