namespace BlazorAssembleApp.Data.Interface;

public interface IClock
{
    public TimeOnly GetCurrentTime();
}