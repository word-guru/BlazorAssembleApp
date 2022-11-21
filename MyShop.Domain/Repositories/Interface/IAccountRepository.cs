using MyShop.Models;

namespace MyShop.Domain.Repositories.Interface;

public interface IAccountRepository : IGRepository<Account>
{
  Task<Account?> FindByEmail(string email);
}