using Diplomski.BLL.DTOs.RateDTOs;
using Diplomski.BLL.Enums;
using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class RateService : IRateService
{
    private readonly IRateRepository _repository;
    private readonly IUserService _userService;
    private readonly ISessionService _sessionService;

    
    public RateService(
        IRateRepository repository, 
        IUserService userService, 
        ISessionService sessionService
    )
    {
        _repository = repository;
        _userService = userService;
        _sessionService = sessionService;
    }

    
    public RateReadDto Create(int exerciserId, RateCreateDto dto)
    {
        User user = _userService.GetExerciser(exerciserId);

        Session session = _sessionService.Get(dto.SessionId);

        if (session.Status != (int)SessionStatus.Completed)
            throw BusinessExceptions.SessionIsNotFinishedForRate;
        
        Rate rate = new Rate()
        {
            SessionId = session.Id,
            Rate1 = dto.Rate,
            Comment = dto.Comment
        };

        rate = _repository.Create(rate);

        return rate.ToReadDto();
    }

    public RateReadDto GetBySession(int sessionId)
    {
        Session session = _sessionService.Get(sessionId);

        if (session.Status != (int)SessionStatus.Completed)
            throw BusinessExceptions.SessionIsNotFinishedForRate;

        Rate rate = _repository.GetBySessionId(sessionId);

        if (rate == null)
            throw BusinessExceptions.RateDoesNotExist;

        return rate.ToReadDto();
    }

    public IEnumerable<RateReadDto> GetByTrainerId(int trainerId)
    {
        IEnumerable<Rate> rates = _repository.GetByTrainerId(trainerId);

        return rates.ToReadDtos();
    }
}