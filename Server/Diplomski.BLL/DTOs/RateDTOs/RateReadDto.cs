using Diplomski.BLL.DTOs.SessionsDTOs;

namespace Diplomski.BLL.DTOs.RateDTOs;

public class RateReadDto
{
    public int SessionId { get; set; }
    public string Comment { get; set; } = null!;
    public int Rate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public SessionReadDto? Session { get; set; }
}