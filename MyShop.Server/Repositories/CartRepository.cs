using Microsoft.EntityFrameworkCore;
using MyShop.Server.Date;
using MyShop.Server.Repositories.Interface;
using MyShop.Server.Repository.Models;

namespace MyShop.Server.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _dbContext;

    public CartRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Cart>> GetCarts()
        => await _dbContext.Carts.ToListAsync();
    
    public async Task AddCart(Cart cart)
    {
        await _dbContext.Carts.AddAsync(cart);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCartProduct(Cart cart)
    {
        _dbContext.Carts.Remove(cart);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task ClearCartProduct()
    {
        _dbContext.Carts.RemoveRange(_dbContext.Carts);
        await _dbContext.SaveChangesAsync();
    }
}