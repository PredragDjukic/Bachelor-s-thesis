using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IPackageRepository
{
    Package Create(Package entity);
    Package? Get(int id);
}