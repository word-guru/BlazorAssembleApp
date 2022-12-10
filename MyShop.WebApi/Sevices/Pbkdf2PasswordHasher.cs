using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Entites;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Services.Interfaces;

namespace MyShop.WebApi.Sevices;

public class Pbkdf2PasswordHasher : IPasswordHasherService
{
    private PasswordHasher<Account> _hasher = new();
    private Account _dummy =new();
    public string HashPassword(string password)
    {
        string hashedPassword = _hasher.HashPassword(_dummy, password);

        return hashedPassword;
    }

    public bool VerifyPassword(string passwordHash, string provadedPassword)
    {
        var result = _hasher.VerifyHashedPassword(_dummy,passwordHash,provadedPassword);
        if (result == PasswordVerificationResult.Failed)
        {
            throw new IncorrectPasswordException();
        }
        return false;
    }
}