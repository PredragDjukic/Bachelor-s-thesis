using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IPaymentRepository
{
    Payment Create(Payment entity);
    bool DoesPaymentsExistsForTrainer(int trainerId);
    bool DoesPaymentsExistsForExerciser(int exerciserId);
}