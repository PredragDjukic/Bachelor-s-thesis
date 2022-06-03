using Diplomski.BLL.DTOs.PaymentDTOs;
using Diplomski.BLL.Exceptions;
using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Diplomski.DAL.Enums;
using Diplomski.DAL.Interfaces;
using Stripe;

namespace Diplomski.BLL.Services;

public class PaymentService : IPaymentService
{
    private readonly IStripeService _stripeService;

    private readonly IPaymentRepository _repository;

    
    public PaymentService(IStripeService stripeService, IPaymentRepository repository)
    {
        _stripeService = stripeService;
        _repository = repository;
    }

    
    public string? AddCustomer(User user)
    {
        if (user.UserType != Convert.ToInt32(UserType.Exerciser))
            return null;
        
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

    public void DeleteCard(User user, string cardId)
    {
        if (user.CustomerId == null)
            throw BusinessExceptions.UserDoesNotHaveCustomerId;
        
        Customer customer = _stripeService.GetCustomer(user.CustomerId);
        
        _stripeService.DeleteCard(customer.Id, cardId);
    }

    public void CreatePayment(PaymentCreateDto dto)
    {
        try
        {
            _stripeService.CreatePaymentIntent(dto.CustomerId, Convert.ToInt64(dto.Price * 100));
        }
        catch (Exception e)
        {
            throw BusinessExceptions.PaymentFailed;
        }
        
        Payment payment = new Payment()
        {
            Price = Math.Round(dto.Price * 100),
            TrainerId = dto.TrainerId,
            ExerciserId = dto.ExerciserId
        };

        _repository.Create(payment);
    }
}