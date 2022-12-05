namespace MyShop.Domain.Exceptions;

public class IncorrectPasswordException : Exception
{
    public IncorrectPasswordException(string? message = null)
        : base(message) { }
}