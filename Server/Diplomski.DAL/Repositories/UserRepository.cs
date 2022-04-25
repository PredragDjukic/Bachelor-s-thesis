using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Diplomski.DAL.Mappers;

namespace Diplomski.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConcurrencyDbContext _context;


        public UserRepository(ConcurrencyDbContext context)
        {
            _context = context;
        }


        public User? Get(int id)
        {
            return _context.User.FirstOrDefault(e => e.Id == id);
        }

        public User? Get(string email)
        {
            return _context.User.FirstOrDefault(e => e.Email == email);
        }

        public void Create(User entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.User.Add(entity);

            _context.SaveChanges();
        }

        public bool CheckIfExistsByEmail(string email)
        {
            bool exists = _context.User.Any(e => e.Email == email);

            return exists;
        }

        public bool CheckIfExistsByPhoneNumber(string phoneNumber)
        {
            bool exists = _context.User.Any(e => e.PhoneNumber == phoneNumber);

            return exists;
        }

        public User Update(User user)
        {
            User? entity = _context.User.FirstOrDefault(e => e.Id == user.Id);
            
            entity.UpdatedAt = DateTime.UtcNow;
            entity.ToUpdate(user);

            _context.SaveChanges();

            return entity;
        }
    }
}
