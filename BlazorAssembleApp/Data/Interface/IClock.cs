namespace BlazorAssembleApp.Data;

public interface IClock
{
    public TimeOnly GetCurrentTime();
}