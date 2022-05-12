using Diplomski.BLL.DTOs.PackageDTOs;

namespace Diplomski.BLL.Interfaces;

public interface IPackageService
{
    PackageReadDto Create(int trainerId, PackageCreateDto dto);
}