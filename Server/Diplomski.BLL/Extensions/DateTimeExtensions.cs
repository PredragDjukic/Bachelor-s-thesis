namespace Diplomski.BLL.Extensions;

public static class DateTimeExtensions
{
    public static bool IsGreater(this DateTime first, DateTime second)
    {
        return (first > second) ?  true : false;
    }
}