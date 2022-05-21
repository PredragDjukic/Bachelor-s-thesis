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
        UpdatedAt = bundle.UpdatedAt,
        Package = bundle.Package.ToReadDto() ?? null
    };

    internal static IEnumerable<BundleReadDto> ToReadDtos(this IEnumerable<Bundle> bundles)
        => bundles.Select(e => e.ToReadDto());
}