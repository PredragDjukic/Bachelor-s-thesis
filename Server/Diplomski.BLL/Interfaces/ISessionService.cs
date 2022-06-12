using Diplomski.BLL.DTOs.SessionsDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Interfaces;

public interface ISessionService
{
    SessionReadDto OpenSession(int trainerId, SessionCreateDto dto);
    SessionReadDto Reserve(int exerciserId, SessionReserveDto dto);
    SessionReadDto Cancel(int userId, int sessionId);
    Session Get(int sessionId);
}