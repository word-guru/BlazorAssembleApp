using MyShopBlazor.App.Data.Interface;

namespace MyShopBlazor.App.Data;

public class Clock : IClock
{
    private readonly DateTime _time = DateTime.Now;

    public TimeOnly GetCurrentTime()
    {
        return TimeOnly.FromDateTime(_time);
    }
}