using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IPackageRepository
{
    IQueryable<Package> GetActiveByTrainer(int trainerId);
    Package Create(Package entity);
    Package? Get(int id);
    Package Update(Package entity);
    void Delete(Package entity);
}