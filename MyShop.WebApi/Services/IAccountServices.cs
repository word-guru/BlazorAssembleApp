using MyShop.Models;

namespace MyShop.WebApi.Services;

public interface IAccountServices 
{
    Task<Account> Register(Account account);
}