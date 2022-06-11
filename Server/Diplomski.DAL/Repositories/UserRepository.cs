using Diplomski.DAL.Entities;
using Diplomski.DAL.Enums;
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

        public User? GetTrainer(int id)
        {
            return _context.User.FirstOrDefault(e => 
                e.Id == id && 
                e.UserType == Convert.ToInt32(UserType.Trainer)
            );
        }

        public User? GetExerciser(int id)
        {
            return _context.User.FirstOrDefault(e => 
                e.Id == id && 
                e.UserType == Convert.ToInt32(UserType.Exerciser)
            );
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

        public User Update(User entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            _context.User.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<User> GetAllTrainers()
        {
            var entities = _context.User
                .Where(e => e.IsDeleted == false &&
                            e.UserType == (int)UserType.Trainer
                        );

            return entities;
        }

        public IQueryable<User> SearchTrainerByFullName(string fullName)
        {
            var entities = _context.User
                .Where(e => (e.FirstName + ' ' + e.LastName).Contains(fullName));

            return entities;
        }

        public IQueryable<User> SearchTrainerByUsername(string username)
        {
            var entities = _context.User
                .Where(e => e.Username.Contains(username));

            return entities;
        }
    }
}
