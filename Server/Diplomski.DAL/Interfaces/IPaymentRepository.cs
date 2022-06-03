using Diplomski.DAL.Entities;

namespace Diplomski.DAL.Interfaces;

public interface IPaymentRepository
{
    Payment Create(Payment entity);
}