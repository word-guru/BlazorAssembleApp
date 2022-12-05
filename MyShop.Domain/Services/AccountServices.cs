using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Exceptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Models;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<Account> _hasher;

    public AccountServices(IAccountRepository accountRepository, IPasswordHasher<Account> hasher)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _hasher = hasher ?? throw new ArgumentNullException(nameof(hasher)); //!
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

    public async Task<(Account account,string token)> LogIn(string email, string password)
    {
        
        Account? account = await _accountRepository.FindByEmail(email);
        if (account is null)
        {
            throw new EmailUnregisteredException();
        }

        var result = _hasher.VerifyHashedPassword(account, account.Password, password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new IncorrectPasswordException();
        }

        string token = _tokenService.Generate(account);

        return (account,token);
    }
}

