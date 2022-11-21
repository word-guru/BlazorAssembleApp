namespace MyShop.Domain.Exeptions;

[Serializable]
public class EmailAlreadyExistException : Exception
{

    public EmailAlreadyExistException(string? message = null)
        : base(message) { }
}