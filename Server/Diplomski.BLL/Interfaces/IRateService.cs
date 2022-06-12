using Diplomski.BLL.DTOs.RateDTOs;

namespace Diplomski.BLL.Interfaces;

public interface IRateService
{
    RateReadDto Create(int exerciserId, RateCreateDto dto);
    RateReadDto GetBySession(int sessionId);
    IEnumerable<RateReadDto> GetByTrainerId(int trainerId);
}