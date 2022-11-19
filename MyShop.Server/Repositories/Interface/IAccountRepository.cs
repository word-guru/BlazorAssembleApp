using MyShop.Server.Repository.Models;
using MyShop.Server.Repository.Server.GenericRepository.InterfaceGenericRepozitory;

namespace MyShop.Server.Repositories.Interface;

public interface IAccountRepository : IGRepository<Account>
{
  Task<Account?> FindByEmail(string email);
}