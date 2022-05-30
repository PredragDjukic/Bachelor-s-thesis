using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Stripe;

namespace Diplomski.BLL.Interfaces;

public interface IPaymentService
{
    string AddCustomer(User user);
    void AddCard(User user, CardModel model);
    StripeList<Card> GetCards(User user);
}