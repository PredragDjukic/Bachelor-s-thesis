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
        CreatedAt = package.CreatedAt,
        UpdatedAt = package.UpdatedAt
    };
}