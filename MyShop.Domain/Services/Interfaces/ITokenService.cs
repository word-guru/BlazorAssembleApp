using MyShop.Models;

namespace MyShop.Domain.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Account account);
}