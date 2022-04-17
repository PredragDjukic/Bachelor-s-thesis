using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Register(User entity);
        bool CheckIfExistsByEmail(string email);
        bool CheckIfExistsByPhoneNumber(string phoneNumber);

    }
}
