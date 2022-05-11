using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.DAL.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public PackageRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }

    
    public void Create(Package entity)
    {   
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        _context.Package.Add(entity);

        _context.SaveChanges();
    }
}