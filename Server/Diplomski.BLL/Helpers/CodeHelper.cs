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
    }
}
