using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface ISessionRepository
{
    Session Create(Session entity);
    bool DoesSessionOverlap(int trainerId, DateTime start, DateTime end);
}