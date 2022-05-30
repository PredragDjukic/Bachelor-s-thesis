using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Stripe;

namespace Diplomski.BLL.Services.External;

public class StripeService : IStripeService
{
    string? apiKey = Environment.GetEnvironmentVariable("StripeApiKeyDiplomski", EnvironmentVariableTarget.Machine);


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
}