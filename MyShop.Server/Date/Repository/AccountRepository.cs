using MyShop.Models;
using MyShop.Server.Date.Repository.Interface;
using MyShop.Server.GenericRepository;

namespace MyShop.Server.Date.Repository;

public class AccountRepository : EfRepository<Account>, IAccountRepository
{
public AccountRepository(AppDbContext dbContext) : base(dbContext) {}
}