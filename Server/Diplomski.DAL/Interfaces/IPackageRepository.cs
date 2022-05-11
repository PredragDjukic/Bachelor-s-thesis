using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IPackageRepository
{
    void Create(Package entity);
}