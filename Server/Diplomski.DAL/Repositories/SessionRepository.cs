using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.DAL.Repositories;

public class SessionRepository : ISessionRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public SessionRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }

    
    public Session Create(Session entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdateAt = DateTime.UtcNow;

        _context.Session.Add(entity);
        _context.SaveChanges();

        return entity;
    }
}