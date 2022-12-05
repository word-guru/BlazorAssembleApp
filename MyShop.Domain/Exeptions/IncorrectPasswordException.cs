namespace MyShop.Domain.Exeptions;

public class IncorrectPasswordException : Exception
{
    public IncorrectPasswordException(string? message = null)
        : base(message) { }
}