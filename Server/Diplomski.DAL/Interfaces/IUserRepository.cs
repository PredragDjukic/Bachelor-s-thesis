using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces
{
    public interface IUserRepository
    {
        void Register(User entity);
    }
}
