using Diplomski.BLL.DTOs.SessionsDTOs;

namespace Diplomski.BLL.Interfaces;

public interface ISessionService
{
    SessionReadDto OpenSession(int trainerId, SessionCreateDto dto);
    SessionReadDto Reserve(int exerciserId, SessionReserveDto dto);
}