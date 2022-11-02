﻿using BlazorAssembleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationEF.Models;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public Task Product { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

}