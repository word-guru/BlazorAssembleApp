﻿using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Repository.Models;


namespace MyShop.WebApi.Date;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Account> Accounts => Set<Account>();
    
    public Task Product { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) { } //Bogus заполнение бд

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Account>().HasIndex(b => b.Email).IsUnique();
    }
}