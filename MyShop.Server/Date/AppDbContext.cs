using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Server.Date;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public Task Product { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

}
