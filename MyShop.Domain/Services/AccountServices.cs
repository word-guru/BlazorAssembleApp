using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Models;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<Account> _hasher;

    public AccountServices(IAccountRepository accountRepository, IPasswordHasher<Account> hasher)
    {
        _accountRepository = accountRepository;
        _hasher = hasher;
    }

    // [HttpPost("register")]
    public async Task<Account> Register(string email, string name, string password)
    {
        Account account = new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email
        };

        var existedAccount = await _accountRepository
            .FindByEmail(account.Email);

        var accountExist = existedAccount is not null;
        if (accountExist)
        {
            throw new EmailAlreadyExistException();
        }

        string hashedPassword = _hasher.HashPassword(account, password);
        account.Password = hashedPassword;

        await _accountRepository.Add(account);
        return account;
    }

    public async Task<Account> LogIn(string email, string password)
    {
        var account = await _accountRepository.FindByEmail(email);
        // if (account == null) 
        //     throw new EmailAlreadyExistException();

        if (_hasher.VerifyHashedPassword(account, account.Password, password)
            == PasswordVerificationResult.Failed)
        {
            throw new IncorrectPasswordException();
        }

        return account;
    }
}