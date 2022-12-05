using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entites;
using MyShop.Domain.Repositories.Interface;

namespace MyShop.Data.Ef.Repositories;

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