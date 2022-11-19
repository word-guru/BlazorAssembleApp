namespace MyShop.Server.Repository.BlazorClient.Data.Interface;

public interface IClock
{
    public TimeOnly GetCurrentTime();
}