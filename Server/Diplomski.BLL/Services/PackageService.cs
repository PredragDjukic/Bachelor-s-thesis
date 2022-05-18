using Diplomski.BLL.DTOs.PackageDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class PackageService : IPackageService
{
    private readonly IPackageRepository _packageRepository;
    private readonly IBundleRepository _bundleRepository;
    private readonly IUserService _userService;

    
    public PackageService(IPackageRepository packageRepository, IUserService userService, IBundleRepository bundleRepository)
    {
        _packageRepository = packageRepository;
        _userService = userService;
        _bundleRepository = bundleRepository;
    }

    public PackageReadDto Create(int trainerId, PackageCreateDto dto)
    {
        User user = _userService.GetTrainer(trainerId);

        Package package = new Package()
        {
            TrainerId = user.Id,
            NumberOfSessions = dto.NumberOfSessions,
            Price = dto.Price,
            IsActive = true
        };
        
        Package result = _packageRepository.Create(package);

        return result.ToReadDto();
    }

    public PackageReadDto GetRead(int id)
    {
        Package? package = _packageRepository.Get(id);

        if (package == null)
            throw BusinessExceptions.PackageDoesNotExist;

        return package.ToReadDto();
    }

    public PackageReadDto Update(int trainerId, int id, PackageUpdateDto dto)
    {
        Package package = this.Get(id);
        
        if (package.TrainerId != trainerId)
            throw BusinessExceptions.CanNotUpdateOfAnotherTrainer;

        package.NumberOfSessions = dto.NumberOfSessions;
        package.Price = dto.Price;
        package.IsActive = dto.IsActive;

        Package result = _packageRepository.Update(package);

        return result.ToReadDto();
    }

    public void Delete(int trainerId, int id)
    {
        Package package = this.Get(id);

        if (package.TrainerId != trainerId)
            throw BusinessExceptions.CanNotDeleteOfAnotherTrainer;
        
        if (!_bundleRepository.ExistsByPackage(package.Id))
        {
            _packageRepository.Delete(package);

            return;
        }

        this.DeleteLogically(package);
    }

    private void DeleteLogically(Package package)
    {
        package.IsActive = false;

        _packageRepository.Update(package);
    }

    public Package Get(int id)
    {
        Package? package = _packageRepository.Get(id);

        if (package == null)
            throw BusinessExceptions.PackageDoesNotExist;

        return package;
    }

}