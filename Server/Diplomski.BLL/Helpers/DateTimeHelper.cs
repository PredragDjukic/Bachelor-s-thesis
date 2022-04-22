using Diplomski.BLL.Utils.Constants;

namespace Diplomski.BLL.Helpers
{
    public static class DateTimeHelper
    {
        public static double GetYearDifferenceFromNow(DateTime date)
        {
            TimeSpan diff = DateTime.UtcNow - date;

            return diff.Days / 365;
        }
    }
}
