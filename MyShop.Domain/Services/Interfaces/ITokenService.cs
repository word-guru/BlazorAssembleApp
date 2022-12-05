using MyShop.Domain.Entites;
using MyShop.HttpModels;

namespace MyShop.Domain.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Account account);
}