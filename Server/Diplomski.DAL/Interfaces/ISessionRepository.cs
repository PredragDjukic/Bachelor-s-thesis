using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface ISessionRepository
{
    Session Create(Session entity);
}