using Diplomski.BLL.DTOs.SessionsDTOs;
using Diplomski.DAL.Entities;

namespace Diplomski.BLL.Mappers;

internal static class SessionMapper
{
    internal static SessionReadDto ToReadDto(this Session session) => new SessionReadDto()
    {
        Id = session.Id,
        SessionNumber = session.SessionNumber,
        DateAndTime = session.DateAndTime,
        Location = session.Location,
        Status = session.Status,
        ExerciserId = session.ExerciserId,
        Exerciser = session.Exerciser != null ? session.Exerciser.ToReadDto() : null,
        PackageId = session.PackageId,
        Package = session.Package != null ? session.Package.ToReadDto() : null,
        TrainerId = session.TrainerId,
        Trainer = session.Trainer.ToReadDto(),
        CreatedAt = session.CreatedAt,
        UpdateAt = session.UpdateAt
    };
}