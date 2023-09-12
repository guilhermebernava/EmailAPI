using System.Globalization;

namespace Domain.Utils;

public static class DateTimeFormatUtils
{
    private static readonly string _format = "dd/MM/yyyy HH:mm";
    public static DateTime FormatDateTimeToBr(this DateTime date)
    {
        string formattedDate = date.ToString(_format, CultureInfo.InvariantCulture);
        if (DateTime.TryParseExact(formattedDate, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDateTime)) return parsedDateTime;
        throw new FormatException("Could not format DATE TIME");
    }
}
