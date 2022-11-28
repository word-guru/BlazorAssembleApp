﻿using MyShop.Models;

namespace MyShop.Domain.Services;

public interface IAccountServices 
{
    Task<Account> Register(Account account);
    Task<Account> Authorization(Account account);
}