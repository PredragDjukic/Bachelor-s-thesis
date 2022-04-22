using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.Helpers
{
    public static class CodeHelper
    {
        public static string GenerateSecretCode()
        {
            return new Random()
                .Next(0, 999999)
                .ToString("D6");
        }
        
        public static DateTime GenerateSecretCodeExpiryDate()
        {
            return DateTime.UtcNow.AddMinutes(LiteralConsts.SecretCodeExpiryInMinutes);
        }

    }
}
