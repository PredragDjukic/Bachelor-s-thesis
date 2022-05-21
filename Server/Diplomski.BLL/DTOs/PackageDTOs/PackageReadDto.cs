namespace Diplomski.BLL.DTOs.PackageDTOs;

public class PackageReadDto
{
    public int Id { get; set; }
    public int NumberOfSessions { get; set; }
    public decimal Price { get; set; }
    public int TrainerId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}