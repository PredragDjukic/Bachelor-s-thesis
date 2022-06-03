using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.BLL.DTOs.UserDtos;

namespace Diplomski.BLL.DTOs.SessionsDTOs;

public class SessionReadDto
{
    public int Id { get; set; }
    public int? SessionNumber { get; set; }
    public string Location { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int Status { get; set; }
    public int TrainerId { get; set; }
    public UserReadDto? Trainer { get; set; }
    public int? ExerciserId { get; set; }
    public UserReadDto? Exerciser { get; set; }
    public int? BundleId { get; set; }
    public BundleReadDto? Bundle { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}