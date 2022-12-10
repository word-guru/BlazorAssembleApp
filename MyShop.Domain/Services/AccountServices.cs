using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Entites;
using MyShop.Domain.Exeptions;
using MyShop.Domain.Repositories.Interface;
using MyShop.Domain.Services.Interfaces;
using MyShop.HttpModels;

namespace MyShop.Domain.Services;

public class AccountServices : IAccountServices
{
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly ITokenService _tokenService;

    public AccountServices(IAccountRepository accountRepository,
        IPasswordHasherService passwordHasherService,
        ITokenService tokenService
    )
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _passwordHasherService = passwordHasherService ?? throw new ArgumentNullException(nameof(passwordHasherService)); //!
        _tokenService = tokenService;
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

        string hashedPassword = _passwordHasherService.HashPassword(password);
        account.Password = hashedPassword;

        await _accountRepository.Add(account);
        return account;
    }

    public async Task<(Account account, string token)> LogIn(string email, string password)
    {
        Account? account = await _accountRepository.FindByEmail(email);
        if (account is null)
        {
            throw new EmailUnregisteredException();
        }

        var result = _passwordHasherService.VerifyPassword(account.Password, password);
        string token = _tokenService.GenerateToken(account);
        return (account, token);
    }
}