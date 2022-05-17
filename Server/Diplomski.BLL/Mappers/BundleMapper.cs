using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Mappers;

internal static class BundleMapper
{
    internal static BundleReadDto ToReadDto(this Bundle bundle) => new BundleReadDto()
    {
        Id = bundle.Id,
        SessionsLeft = bundle.SessionsLeft,
        PackageId = bundle.PackageId,
        ExerciserId = bundle.ExerciserId,
        IsActive = bundle.IsActive,
        CreatedAt = bundle.CreatedAt,
        UpdatedAt = bundle.UpdatedAt
    };
}