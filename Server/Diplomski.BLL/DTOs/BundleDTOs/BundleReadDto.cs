using Diplomski.BLL.DTOs.PackageDTOs;

namespace Diplomski.BLL.DTOs.BundleDTOs;

public class BundleReadDto
{
    public int Id { get; set; }
    public int SessionsLeft { get; set; }
    public int PackageId { get; set; }
    public int ExerciserId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public PackageReadDto? Package { get; set; }
}