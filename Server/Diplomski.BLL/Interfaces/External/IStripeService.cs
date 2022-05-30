using Diplomski.BLL.Utils.Models;

namespace Diplomski.BLL.Interfaces.External;

public interface IStripeService
{
    string CreateCustomer(CustomerModel model);
}