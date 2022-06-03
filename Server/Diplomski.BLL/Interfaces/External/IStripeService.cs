using Diplomski.BLL.Utils.Models;
using Stripe;

namespace Diplomski.BLL.Interfaces.External;

public interface IStripeService
{
    string CreateCustomer(CustomerModel model);
    Customer GetCustomer(string id);
    void AddCard(string customerId, string paymentMethod);
    StripeList<Card> GetCards(string customerId);
    Card GetCard(string customerId, string cardId);
    void DeleteCard(string customerId, string cardId);
    void CreatePaymentIntent(string customerId, long price);
}