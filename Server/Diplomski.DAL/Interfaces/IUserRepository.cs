using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces
{
    public interface IUserRepository
    {
        User? Get(int id);
        User? Get(string email);
        void Create(User entity);
        bool CheckIfExistsByEmail(string email);
        bool CheckIfExistsByPhoneNumber(string phoneNumber);
        User Update(User user);
    }
}
