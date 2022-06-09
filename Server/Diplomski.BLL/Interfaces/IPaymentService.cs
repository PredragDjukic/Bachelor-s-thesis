using Diplomski.BLL.DTOs.PaymentDTOs;
using Diplomski.BLL.Utils.Models;
using Diplomski.DAL.Entities;
using Stripe;

namespace Diplomski.BLL.Interfaces;

public interface IPaymentService
{
    string? AddCustomer(User user);
    void AddCard(User user, CardModel model);
    StripeList<Card> GetCards(User user);
    Card SetUpDefault(User user, string cardId);
    Card GetDefault(User user);
    void DeleteCard(User user, string cardId);
    void CreatePayment(PaymentCreateDto dto);
    bool DoesPaymentsExistsForTrainer(int trainerId);
    bool DoesPaymentsExistsForExerciser(int exerciserId);
}