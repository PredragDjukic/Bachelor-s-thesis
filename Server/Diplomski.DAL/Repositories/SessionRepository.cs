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

    public bool DoesSessionOverlap(int trainerId, DateTime start, DateTime end)
    {
        IQueryable<Session> session = _context.Session.Where(e => trainerId == e.TrainerId);
        //Does not work
        bool contains = session.Any(
            e => 
                (start >= e.StartDateTime && end <= e.EndDateTime) ||
                 (start <= e.StartDateTime && end >= e.EndDateTime) ||
                 (start <= e.StartDateTime && end > e.StartDateTime) ||
                 (start < e.EndDateTime && end >= e.EndDateTime)
        );

        return contains;
    }
}