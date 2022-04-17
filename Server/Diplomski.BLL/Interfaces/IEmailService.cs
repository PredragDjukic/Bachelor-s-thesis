namespace Diplomski.BLL.Interfaces
{
    public interface IEmailService
    {
        void SendVerificationCode(string receiver, string secretCode);
    }
}
