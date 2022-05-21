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

    public bool ExistsByPackage(int packageId)
    {
        return _context.Bundle.Any(e => e.PackageId == packageId);
    }
}