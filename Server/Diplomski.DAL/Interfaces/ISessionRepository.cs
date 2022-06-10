using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface ISessionRepository
{
    Session Create(Session entity);
    Session? Get(int id);
    Session Update(Session entity);
    bool DoesSessionOverlap(int trainerId, DateTime start, DateTime end);
    bool DoesReservedOrCompletedExistByTrainer(int trainerId);
    bool DoesReservedOrCompletedExistByExerciser(int exerciserId);
    void DeleteAvailableSessionsByTrainer(int trainerId);
}