using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Mappers;

internal static class PackageMapper
{
    internal static PackageReadDto ToReadDto(this Package package) => new PackageReadDto()
    {
        Id = package.Id,
        NumberOfSessions = package.NumberOfSessions,
        Price = package.Price,
        TrainerId = package.TrainerId,
        IsActive = package.IsActive,
        CreatedAt = package.CreatedAt,
        UpdatedAt = package.UpdatedAt
    };

    internal static IEnumerable<PackageReadDto> ToReadDtos(this IEnumerable<Package> packages)
        => packages.Select(e => e.ToReadDto());
}