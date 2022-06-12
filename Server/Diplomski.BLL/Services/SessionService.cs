using Diplomski.BLL.DTOs.SessionsDTOs;
using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Enums;
using Diplomski.DAL.Interfaces;
using SessionStatus = Diplomski.BLL.Enums.SessionStatus;

namespace Diplomski.BLL.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _repository;
    
    private readonly IUserService _userService;
    private readonly IBundleService _bundleService;

    private readonly IBundleRepository _bundleRepository;

    
    public SessionService(
        ISessionRepository repository,
        IUserService userService,
        IBundleService bundleService, 
        IBundleRepository bundleRepository
    )
    {
        _repository = repository;
        _userService = userService;
        _bundleService = bundleService;
        _bundleRepository = bundleRepository;
    }


    public SessionReadDto OpenSession(int trainerId, SessionCreateDto dto)
    {
        User trainer = _userService.GetTrainer(trainerId);

        this.CheckSessionTime(trainer.Id, dto);

        Session session = new Session()
        {
            TrainerId = trainer.Id,
            StartDateTime = dto.StartDateTime,
            EndDateTime = dto.StartDateTime.AddHours(1),
            Location = dto.Location,
            Status = Convert.ToInt32(SessionStatus.Available)
        };

        session = _repository.Create(session);

        return session.ToReadDto();
    }

    private void CheckSessionTime(int trainerId, SessionCreateDto dto)
    {
        if (dto.StartDateTime < DateTime.UtcNow)
            throw BusinessExceptions.SessionStartInThePast;

        if (
            _repository.DoesSessionOverlap(
                trainerId,
                dto.StartDateTime,
                dto.StartDateTime.AddHours(1)
            )
        )
            throw BusinessExceptions.SessionOverlap;
    }

    public SessionReadDto Reserve(int exerciserId, SessionReserveDto dto)
    {
        User exerciser = _userService.GetExerciser(exerciserId);

        Bundle bundle = this.GetAndCheckBundle(exerciser.Id, dto.BundleId);
        Session session = this.Get(dto.SessionId);

        session.ExerciserId = exerciser.Id;
        session.BundleId = bundle.Id;
        session.SessionNumber = bundle.Package.NumberOfSessions - bundle.SessionsLeft + 1;
        session.Status = Convert.ToInt32(SessionStatus.Reserved);

        bundle.SessionsLeft--;

        _bundleRepository.Update(bundle);

        session = _repository.Update(session);

        this.SetUpTaskForFinishedSession(session);

        return session.ToReadDto();
    }

    private void SetUpTaskForFinishedSession(Session session)
    {
        DateTime current = DateTime.UtcNow;
        TimeSpan timeToGo = session.EndDateTime - current;
        
        Timer timer = new Timer(x =>
        {
            this.FinishSession(session.Id);
        }, null, timeToGo, Timeout.InfiniteTimeSpan);
    }

    private void FinishSession(int sessionId)
    {
        Session session = this.Get(sessionId);

        if (session.Status != (int)SessionStatus.Reserved)
            throw BusinessExceptions.SessionNotReserved;

        session.Status = (int)SessionStatus.Completed;
        _repository.Update(session);
    }

    public SessionReadDto Cancel(int userId, int sessionId)
    {
        Session session = this.Get(sessionId);

        if (session.Status != (int)SessionStatus.Reserved)
            throw BusinessExceptions.CanNotCancelSession;

        User user = this.GetUserForSession(userId, session);

        Bundle bundle = _bundleService.Get((int)session.BundleId);

        bundle.SessionsLeft++;

        _bundleRepository.Update(bundle);
        
        session.SessionNumber = null;
        session.Status = (int)SessionStatus.Available;
        session.ExerciserId = null;
        session.BundleId = null;

        session = _repository.Update(session);

        return session.ToReadDto();
    }

    private User GetUserForSession(int userId, Session session)
    {
        User user = _userService.Get(userId);

        if (user.UserType == (int)UserType.Trainer)
            if (session.TrainerId != user.Id)
                throw BusinessExceptions.CanNotCancelSession;
        else
        if (session.ExerciserId != user.Id)
                throw BusinessExceptions.CanNotCancelSession;

        return user;
    }

    private Bundle GetAndCheckBundle(int exerciserId, int bundleId)
    {
        Bundle bundle = _bundleService.Get(bundleId);

        if (bundle.ExerciserId != exerciserId)
            throw BusinessExceptions.CanNotAccessBundle;

        if (bundle.IsActive == false || bundle.SessionsLeft == 0)
            throw BusinessExceptions.BundleIsInactive;

        return bundle;
    }

    private Session Get(int id)
    {
        Session? session = _repository.Get(id);

        if (session == null)
            throw BusinessExceptions.SessionDoesNotExist;

        return session;
    }
}