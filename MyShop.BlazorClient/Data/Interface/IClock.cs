namespace MyShop.BlazorClient.Data.Interface;

public interface IClock
{
    public TimeOnly GetCurrentTime();
}