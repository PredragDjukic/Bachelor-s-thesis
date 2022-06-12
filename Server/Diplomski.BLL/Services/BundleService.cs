using Diplomski.BLL.DTOs.BundleDTOs;
using Diplomski.BLL.DTOs.PaymentDTOs;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Mappers;
using Diplomski.BLL.Utils.Constants;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Interfaces;

namespace Diplomski.BLL.Services;

public class BundleService : IBundleService
{
    private readonly IBundleRepository _repo;
    private readonly IUserService _userService;
    private readonly IPackageService _packageService;
    private readonly IPaymentService _paymentService;
    
    
    public BundleService(IBundleRepository repo, IUserService userService, IPackageService packageService, IPaymentService paymentService)
    {
        _repo = repo;
        _userService = userService;
        _packageService = packageService;
        _paymentService = paymentService;
    }


    public IEnumerable<BundleReadDto> GetActiveByTrainer(int trainerId)
    {
        IEnumerable<Bundle> bundles = _repo.GetActiveByTrainer(trainerId);

        if (!bundles.Any())
            throw BusinessExceptions.NoBundles;

        return bundles.ToReadDtos();
    }

    public IEnumerable<BundleReadDto> GetActiveByExerciser(int exerciserId)
    {
        IEnumerable<Bundle> bundles = _repo.GetActiveByExerciser(exerciserId);

        if (!bundles.Any())
            throw BusinessExceptions.NoBundles;

        return bundles.ToReadDtos();
    }

    public BundleReadDto GetRead(int userId, int id)
    {
        User user = _userService.Get(userId);
        Bundle bundle = this.Get(id);

        bool isUserRelatedToBundle = bundle.Package.TrainerId != userId &&
                                     bundle.ExerciserId != userId;
        if (isUserRelatedToBundle)
            throw BusinessExceptions.CanNotAccessBundle;

        return bundle.ToReadDto();
    }

    public BundleReadDto Create(int exerciserId, BundleCreateDto dto)
    {
        User exerciser = _userService.GetExerciser(exerciserId);
        Package package = _packageService.Get(dto.PackageId);

        this.BuyBundle(exerciser, package);
        
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

    private void BuyBundle(User exerciser, Package package)
    {
        if (exerciser.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;

        PaymentCreateDto paymentCreatDto = new PaymentCreateDto()
        {
            TrainerId = package.TrainerId,
            ExerciserId = exerciser.Id,
            Price = package.Price,
            CustomerId = exerciser.CustomerId
        };

        _paymentService.CreatePayment(paymentCreatDto);
    }

    public void Delete(int userId, int id)
    {
        User exerciser = _userService.GetExerciser(userId);
        Bundle? bundle = Get(id);

        if (bundle.ExerciserId != exerciser.Id)
            throw BusinessExceptions.CanNotDeleteBundleFromAnother;

        _repo.Delete(bundle);
    }
    
    public Bundle Get(int id)
    {
        Bundle? bundle = _repo.Get(id);

        if (bundle == null)
            throw BusinessExceptions.BundleDoesNotExist;

        return bundle;
    }

}