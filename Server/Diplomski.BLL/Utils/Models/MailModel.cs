namespace Diplomski.BLL.Utils.Models
{
    public class MailModel
    {
        public string Sender { get; set; } = null!;
        public string Receiver { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
