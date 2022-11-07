using MyShop.App.Data.Interface;

namespace MyShop.App.Data;

public class Clock : IClock
{
    private readonly DateTime _time = DateTime.Now;

    public TimeOnly GetCurrentTime()
    {
        return TimeOnly.FromDateTime(_time);
    }
}