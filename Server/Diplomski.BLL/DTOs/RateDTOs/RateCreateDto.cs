using System.ComponentModel.DataAnnotations;

namespace Diplomski.BLL.DTOs.RateDTOs;

public class RateCreateDto
{
    public int SessionId { get; set; }
    public string Comment { get; set; } = null!;
    [Range(1, 10)]
    public int Rate { get; set; }
}