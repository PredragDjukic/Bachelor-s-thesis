using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IBundleRepository
{
    Bundle Create(Bundle entity);
    Bundle? Get(int id);
    bool ExistsByPackage(int packageId);
}