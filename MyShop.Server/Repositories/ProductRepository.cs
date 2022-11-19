using Microsoft.EntityFrameworkCore;
using MyShop.Server.Repositories.Interface;
using MyShop.Server.Repository.Models;
using MyShop.Server.Repository.Server.Date;

namespace MyShop.Server.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
  
    public async Task<Product> GetProduct(Guid id)
        => await _dbContext.Products.FirstAsync(it => it.Id == id);

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task DeleteProduct(Product product)
    {
         _dbContext.Products.Remove(product);
         await _dbContext.SaveChangesAsync();
    }

    public async Task AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateProduct(Product product)
    {
        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Category>> GetCategories()
        => await _dbContext.Categories.ToListAsync();
    
   
}