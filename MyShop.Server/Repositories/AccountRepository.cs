using Microsoft.EntityFrameworkCore;
using MyShop.Server.Date;
using MyShop.Server.Repositories.Interface;
using MyShop.Server.Repository.Models;
using MyShop.Server.Repository.Server.GenericRepository;

namespace MyShop.Server.Repositories;

public class AccountRepository : EfRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext dbContext) : base(dbContext) { }

    public Task<Account?> FindByEmail(string email)
    {
        return _dbContext.Accounts.FirstOrDefaultAsync
        (
            a => a.Email == email
        );
    }
}