using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Date;

namespace MyShop.Server.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
  
    public async Task<Product> GetById(long id)
        => await _dbContext.Products.FirstAsync(it => it.Id == id);

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task Delete(Product product)
    {
         _dbContext.Products.Remove(product);
         await _dbContext.SaveChangesAsync();
    }

    public async Task Add(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(Product product)
    {
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    
}