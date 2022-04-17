using Diplomski.BLL.Utils.Models;

namespace Diplomski.BLL.Interfaces.External
{
    public interface ISendGridService
    {
        public Task Execute(MailModel model);
    }
}
