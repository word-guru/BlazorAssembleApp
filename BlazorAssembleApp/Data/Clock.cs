namespace BlazorAssembleApp.Data;

public class Clock : IClock
{
    private readonly DateTime _time = DateTime.Now;

    public TimeOnly GetCurrentTime()
    {
        return TimeOnly.FromDateTime(_time);
    }
}