using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.BLL.DTOs.UserDtos;

namespace Diplomski.BLL.DTOs.SessionsDTOs;

public class SessionReadDto
{
    public int Id { get; set; }
    public int? SessionNumber { get; set; }
    public string Location { get; set; } = null!;
    public DateTime DateAndTime { get; set; }
    public int Status { get; set; }
    public int TrainerId { get; set; }
    public UserReadDto? Trainer { get; set; }
    public int? ExerciserId { get; set; }
    public UserReadDto? Exerciser { get; set; }
    public int? PackageId { get; set; }
    public PackageReadDto? Package { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}