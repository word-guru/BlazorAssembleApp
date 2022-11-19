using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.WebApi.Date;
using MyShop.WebApi.GenericRepository;
using MyShop.WebApi.Repositories.Interface;

namespace MyShop.WebApi.Repositories;

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