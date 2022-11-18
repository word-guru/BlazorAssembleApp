using Microsoft.AspNetCore.Mvc;
using MyShop.Exeptions;
using MyShop.Models;
using MyShop.Server.Date.Repository.Interface;

namespace MyShop.Server.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;

    public AccountServices(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpPost("register")]
    public async Task<Account> Register(Account account)
    {
        var existedAccount = await _accountRepository
            .FindByEmail(account.Email);

        var accountExist = existedAccount is not null;
        if (accountExist)
        {
            throw new ExclusionOfEmailRegistration();
        }

        await _accountRepository.Add(account);
        return account;
    }
}