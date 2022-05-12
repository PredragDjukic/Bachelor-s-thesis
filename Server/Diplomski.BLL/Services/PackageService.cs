using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.BLL.DTOs.UserDtos;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _repository;
    private readonly IUserService _userService;

    
    public PackageService(IPackageRepository repository, IUserService userService)
    {
        _repository = repository;
        _userService = userService;
    }

    public PackageReadDto Create(int trainerId, PackageCreateDto dto)
    {
        UserReadDto user = _userService.GetTrainer(trainerId);

        Package package = new Package()
        {
            TrainerId = trainerId,
            NumberOfSessions = dto.NumberOfSessions,
            Price = dto.Price
        };
        
        Package result = _repository.Create(package);

        return result.ToReadDto();
    }

    public PackageReadDto Get(int id)
    {
        Package? package = _repository.Get(id);

        if (package == null)
            throw BusinessExceptions.PackageDoesNotExist;

        return package.ToReadDto();
    }
}