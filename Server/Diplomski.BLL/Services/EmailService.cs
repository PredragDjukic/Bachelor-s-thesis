using Diplomski.BLL.Interfaces;
using Diplomski.BLL.Interfaces.External;
using Diplomski.BLL.Utils.Constants;
using Diplomski.BLL.Utils.Models;

namespace Diplomski.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISendGridService _sendGridService;


        public EmailService(ISendGridService sendGridService)
        {
            _sendGridService = sendGridService;
        }


        public void SendVerificationCode(string receiver, string secretCode)
        {
            string content = $"Your verification code is {secretCode}";

            MailModel model = new()
            {
                Content = content,
                Receiver = receiver,
                Subject = "Verification",
                Sender = LiteralConsts.EmailSender
            };

            _sendGridService.Execute(model);
        }
    }
}
