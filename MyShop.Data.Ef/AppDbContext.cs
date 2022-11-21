using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Repository.Models;

namespace MyShop.Data.Ef;

public class AppDbContext : DbContext
{
   // private readonly string _connectionString;
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Account> Accounts => Set<Account>();
    
    public Task Product { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
       // var dbPath = "myapp.db";
       // _connectionString = $"Data Source={dbPath}";
    } //Bogus заполнение бд

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Account>().HasIndex(b => b.Email).IsUnique();
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlite(connectionString);
    // }
}
