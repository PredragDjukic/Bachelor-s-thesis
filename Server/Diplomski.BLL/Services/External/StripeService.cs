using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
using Stripe;

namespace Diplomski.BLL.Services.External;

public class StripeService : IStripeService
{
    string? apiKey = Environment.GetEnvironmentVariable(Keys.StripeApiKeyName, EnvironmentVariableTarget.Machine);


    public StripeService()
    {
        StripeConfiguration.ApiKey = this.apiKey;
    }

    public string CreateCustomer(CustomerModel model)
    {
        CustomerCreateOptions options = new CustomerCreateOptions()
        {
            Email = model.Email,
            Name = $"{model.FirstName} {model.LastName}",
            Description = "Customer for user",
            Phone = model.PhoneNumber
        };

        var service = new CustomerService();

        Customer customer = service.Create(options);

        return customer.Id;
    }

    public Customer GetCustomer(string id)
    {
        CustomerService service = new CustomerService();

        Customer customer = service.Get(id);

        return customer;
    }

    public void AddCard(string customerId, string paymentMethod)
    {
        CardCreateOptions options = new CardCreateOptions()
        {
            Source = paymentMethod
        };

        CardService service = new CardService();

        Card card = service.Create(customerId, options);
    }

    public StripeList<Card> GetCards(string customerId)
    {
        CardService service = new CardService();

        StripeList<Card> cards = service.List(customerId);

        return cards;
    }

    public Card GetCard(string customerId, string cardId)
    {
        CardService service = new CardService();

        Card card = service.Get(customerId, cardId);

        return card;
    }

    public void DeleteCard(string customerId, string cardId)
    {
        CardService service = new CardService();

        service.Delete(customerId, cardId);
    }

    public void CreatePaymentIntent(string customerId, long price)
    {
        PaymentIntentCreateOptions options = new PaymentIntentCreateOptions()
        {
            Amount = price,
            Customer = customerId,
            Currency = "usd",
            PaymentMethodTypes = new List<string>
            {
                "card",
            },
            Confirm = true
        };

        PaymentIntentService service = new PaymentIntentService();

        service.Create(options);
    }
}