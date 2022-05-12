using Diplomski.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Diplomski.DAL.Interfaces;

public interface IPackageRepository
{
    Package Create(Package entity);
}