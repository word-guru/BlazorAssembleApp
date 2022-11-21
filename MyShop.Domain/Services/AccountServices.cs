using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Models;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;

    public AccountServices(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

   // [HttpPost("register")]
    public async Task<Account> Register(Account account)
    {
        var existedAccount = await _accountRepository
            .FindByEmail(account.Email);

        var accountExist = existedAccount is not null;
        if (accountExist)
        {
            throw new EmailAlreadyExistException();
        }

        await _accountRepository.Add(account);
        return account;
    }
}