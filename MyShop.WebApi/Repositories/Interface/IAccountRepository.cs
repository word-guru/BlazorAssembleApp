using MyShop.Models;
using MyShop.WebApi.GenericRepository.InterfaceGenericRepozitory;

namespace MyShop.WebApi.Repositories.Interface;

public interface IAccountRepository : IGRepository<Account>
{
  Task<Account?> FindByEmail(string email);
}