namespace Core.Domain.Helpers;

public class FormatHour
{
    public static TimeSpan MoreHour(TimeSpan hour)
    {
        var newTime = hour.Add(new TimeSpan(1, 0, 0)); // Sumar una hora
        return newTime; // Devolver el nuevo TimeSpan
    }
}