using MyShop.Models;

namespace MyShop.Server.Services;

public interface IAccountServices
{
    Task<Account> Register(Account account);
}