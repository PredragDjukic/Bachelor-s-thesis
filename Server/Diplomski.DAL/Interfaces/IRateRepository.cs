using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IRateRepository
{
    Rate Create(Rate rate);
    Rate? GetBySessionId(int sessionId);
    IQueryable<Rate> GetByTrainerId(int trainerId);
}