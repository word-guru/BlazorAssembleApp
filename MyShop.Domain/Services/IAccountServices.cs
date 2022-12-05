﻿using MyShop.Models;

namespace MyShop.Domain.Services;

public interface IAccountServices 
{
    Task<Account> Register(string email, string name, string password);
    Task<(Account account, string token)> LogIn(string email, string password);
}