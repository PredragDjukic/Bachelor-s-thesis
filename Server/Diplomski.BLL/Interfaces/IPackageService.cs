using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces;

public interface IPackageService
{
    PackageReadDto Create(int trainerId, PackageCreateDto dto);
    PackageReadDto GetRead(int id);
    Package Get(int id);
}