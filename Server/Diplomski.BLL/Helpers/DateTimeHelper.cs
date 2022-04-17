using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime GenerateSecretCodeExpiryDate()
        {
            return DateTime.UtcNow.AddMinutes(LiteralConsts.SecretCodeExpiryInMinutes);
        }
    }
}
