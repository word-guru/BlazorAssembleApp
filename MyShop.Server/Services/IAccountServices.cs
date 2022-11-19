using MyShop.Server.Repository.Models;

namespace MyShop.Server.Repository.Server.Services;

public interface IAccountServices
{
    Task<Account> Register(Account account);
}