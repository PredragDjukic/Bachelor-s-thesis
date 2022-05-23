using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diplomski.DAL.Repositories;

public class BundleRepository : IBundleRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public BundleRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }
    

    public Bundle Create(Bundle entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        _context.Bundle.Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public Bundle? Get(int id)
    {
        Bundle? bundle = _context.Bundle
            .Include(e => e.Package)
            .FirstOrDefault(e => e.Id == id);

        return bundle;
    }

    public IQueryable<Bundle> GetActiveByExerciser(int exerciserId)
    {
        IQueryable<Bundle> bundles = _context.Bundle
            .Include(e => e.Package)
            .Where(e => 
                e.ExerciserId == exerciserId &&
                e.IsActive == true
            );

        return bundles;
    }

    public IQueryable<Bundle> GetActiveByTrainer(int trainerId)
    {
        IQueryable<Bundle> bundles = _context.Bundle
            .Include(e => e.Package)
            .Where(e => 
                e.Package.TrainerId == trainerId &&
                e.IsActive == true
            );

        return bundles;
    }

    public bool ExistsByPackage(int packageId)
    {
        return _context.Bundle.Any(e => e.PackageId == packageId);
    }

    public void Delete(Bundle entity)
    {
        _context.Bundle.Remove(entity);

        _context.SaveChanges();
    }
}