using Diplomski.BLL.DTOs.SessionsDTOs;
using Diplomski.BLL.Enums;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _repository;
    private readonly IUserService _userService;

    
    public SessionService(ISessionRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }


    public SessionReadDto OpenSession(int trainerId, SessionCreateDto dto)
    {
        User trainer = _userService.GetTrainer(trainerId);
        //Session can not be in the past
        //Session can not be in the same time
        Session session = new Session()
        {
            TrainerId = trainer.Id,
            DateAndTime = dto.DateAndTime,
            Location = dto.Location,
            Status = Convert.ToInt32(SessionStatus.Available)
        };

        session = _repository.Create(session);

        return session.ToReadDto();
    }
}