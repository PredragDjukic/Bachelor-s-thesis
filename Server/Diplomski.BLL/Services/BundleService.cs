using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class BundleService : IBundleService
{
    private readonly IBundleRepository _repo;
    private readonly IUserService _userService;
    private readonly IPackageService _packageService;
    
    
    public BundleService(IBundleRepository repo, IUserService userService, IPackageService packageService)
    {
        _repo = repo;
        _userService = userService;
        _packageService = packageService;
    }


    public BundleReadDto Create(int exerciserId, BundleCreateDto dto)
    {
        User exerciser = _userService.GetExerciser(exerciserId);
        Package package = _packageService.Get(dto.PackageId);

        ///TODO: Payment
        
        Bundle bundle = new Bundle()
        {
            SessionsLeft = package.NumberOfSessions,
            PackageId = package.Id,
            ExerciserId = exerciser.Id,
            IsActive = true
        };

        Bundle result = _repo.Create(bundle);

        return result.ToReadDto();
    }
}