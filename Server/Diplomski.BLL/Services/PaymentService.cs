using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Enums;
using Stripe;

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

    public void AddCard(User user, CardModel model)
    {
        if (user.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;

        _stripeService.AddCard(user.CustomerId, model.Source);
    }

    public StripeList<Card> GetCards(User user)
    {
        if (user.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;
        
        return _stripeService.GetCards(user.CustomerId);
    }

    public Card SetUpDefault(User user, string cardId)
    {
        if (user.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;
        
        Customer customer = _stripeService.GetCustomer(user.CustomerId);
        Card card = _stripeService.GetCard(customer.Id, cardId);

        CustomerService service = new CustomerService();
        CustomerUpdateOptions options = new CustomerUpdateOptions()
        {
            DefaultSource = card.Id
        };

        service.Update(customer.Id, options);

        return card;
    }

    public Card GetDefault(User user)
    {
        if (user.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;
        
        Customer customer = _stripeService.GetCustomer(user.CustomerId);

        return _stripeService.GetCard(customer.Id, customer.DefaultSourceId);
    }
}