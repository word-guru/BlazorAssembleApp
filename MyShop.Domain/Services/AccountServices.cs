using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Models;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasher<User> _hasher;

    public AccountServices(IAccountRepository accountRepository,IPasswordHasher<User> hasher)
    {
        _accountRepository = accountRepository;
        _hasher = hasher;
    }

   // [HttpPost("register")]
    public async Task<Account> Register(Account account)
    {
        string hashedPassword = _hasher.HashPassword(new User(), account.Password);
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
    
    public async Task<Account> Authorization(Account account)
    {
        var passwordHash = _hasher.HashPassword(new User(), account.Password);

        PasswordVerificationResult result = _hasher.VerifyHashedPassword(
            new User(), passwordHash, account.Password);
        
        if (result == PasswordVerificationResult.Failed)
        {
            
        }

        return account;
    }
}