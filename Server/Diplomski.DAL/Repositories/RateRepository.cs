using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diplomski.DAL.Repositories;

public class RateRepository : IRateRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public RateRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }

    
    public Rate Create(Rate rate)
    {
        rate.CreatedAt = DateTime.UtcNow;
        rate.UpdateAt = DateTime.UtcNow;

        _context.Rate.Add(rate);
        _context.SaveChanges();

        return rate;
    }

    public Rate? GetBySessionId(int sessionId)
    {
        Rate? rate = _context.Rate
            .Include(e => e.Session).ThenInclude(e => e.Trainer)
            .FirstOrDefault(e => e.SessionId == sessionId);

        return rate;
    }

    public IQueryable<Rate> GetByTrainerId(int trainerId)
    {
        IQueryable<Rate> rates = _context.Rate
            .Include(e => e.Session).ThenInclude(e => e.Trainer)
            .Where(e => e.Session.TrainerId == trainerId);

        return rates;
    }
}