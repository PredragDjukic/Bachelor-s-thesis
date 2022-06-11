using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Diplomski.BLL.Services.External
{
    public class SendGridService : ISendGridService
    {
        public async Task Execute(MailModel model)
        {
            string? apiKey = Environment.GetEnvironmentVariable(Keys.SendGridApiKeyName, EnvironmentVariableTarget.Machine);
            SendGridClient client = new SendGridClient(apiKey);

            EmailAddress from = new EmailAddress(model.Sender);
            EmailAddress to = new EmailAddress(model.Receiver);
            string subject = model.Subject;
            string content = model.Content;

            SendGridMessage msg = MailHelper.CreateSingleEmail(from, to, subject, content, null);

            await client.SendEmailAsync(msg);
        }
    }
}
