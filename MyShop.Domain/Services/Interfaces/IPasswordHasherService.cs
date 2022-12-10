namespace MyShop.Domain.Services.Interfaces;

public interface IPasswordHasherService
{
    string HashPassword(string password);
    bool   VerifyPassword(string passwordHash, string provadedPassword);
}