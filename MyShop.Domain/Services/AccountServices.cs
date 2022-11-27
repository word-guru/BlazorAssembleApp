using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Models;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<Account> _hasher;

    public AccountServices(IAccountRepository accountRepository,IPasswordHasher<Account> hasher)
    {
        _accountRepository = accountRepository;
        _hasher = hasher;
    }

   // [HttpPost("register")]
    public async Task<Account> Register(Account account)
    {
        string hashedPassword = _hasher.HashPassword(new Account(), account.Password);
        account.Password = hashedPassword;

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