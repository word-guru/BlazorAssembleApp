﻿using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.Repository.Exeptions;
using MyShop.WebApi.Repositories.Interface;

namespace MyShop.WebApi.Services;

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