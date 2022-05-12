using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Diplomski.DAL.Repositories;

public class PackageRepository : IPackageRepository
{
    private readonly ConcurrencyDbContext _context;

    
    public PackageRepository(ConcurrencyDbContext context)
    {
        _context = context;
    }

    
    public Package Create(Package entity)
    {   
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;

        _context.Package.Add(entity);

        _context.SaveChanges();

        return entity;
    }

    public Package? Get(int id)
    {
        return _context.Package.FirstOrDefault(e => e.Id == id);
    }
}