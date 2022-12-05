namespace MyShop.Domain.Exceptions;

[Serializable]
public class EmailAlreadyExistException : Exception
{
    public EmailAlreadyExistException(string? message = null)
        : base(message) { }
}