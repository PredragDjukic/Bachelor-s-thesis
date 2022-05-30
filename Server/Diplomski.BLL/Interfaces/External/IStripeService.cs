using Diplomski.BLL.Utils.Models;
using Stripe;

namespace Diplomski.BLL.Interfaces.External;

public interface IStripeService
{
    string CreateCustomer(CustomerModel model);
    void AddCard(string customerId, string paymentMethod);
    StripeList<Card> GetCards(string customerId);
}