using MyShop.BlazorClient.Data.Interface;

namespace MyShop.BlazorClient.Data;

public class Clock : IClock
{
    private readonly DateTime _time = DateTime.Now;

    public TimeOnly GetCurrentTime()
    {
        return TimeOnly.FromDateTime(_time);
    }
}