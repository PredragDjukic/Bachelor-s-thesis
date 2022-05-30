using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Enums;

namespace Diplomski.BLL.Services;

public class PaymentService : IPaymentService
{
    private readonly IStripeService _stripeService;

    
    public PaymentService(IStripeService stripeService)
    {
        _stripeService = stripeService;
    }

    
    public string AddCustomer(User user)
    {
        if (user.UserType != Convert.ToInt32(UserType.Exerciser))
            throw BusinessExceptions.TrainerCanNotBeCustomer;
        
        CustomerModel customer = new CustomerModel()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber
        };

        string customerId = _stripeService.CreateCustomer(customer);

        return customerId;
    }
}