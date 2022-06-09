using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IBundleRepository
{
    Bundle Create(Bundle entity);
    Bundle? Get(int id);
    IQueryable<Bundle> GetActiveByTrainer(int trainerId);
    IQueryable<Bundle> GetActiveByExerciser(int exerciserId);
    bool ExistsByPackage(int packageId);
    void Delete(Bundle entity);
    bool DoesActiveExistByTrainer(int trainerId);
    bool DoesActiveExistByExerciser(int exerciserId);
}