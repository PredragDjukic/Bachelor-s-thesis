using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.DAL.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public PaymentRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }
    

    public Payment Create(Payment entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdateAt = DateTime.UtcNow;

        _context.Payment.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public bool DoesPaymentsExistsForTrainer(int trainerId)
    {
        return _context.Payment.Any(e => e.TrainerId == trainerId);
    }

    public bool DoesPaymentsExistsForExerciser(int exerciserId)
    {
        return _context.Payment.Any(e => e.ExerciserId == exerciserId);
    }
}