using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Date;

namespace MyShop.Server.Repository;

public interface IProductRepository
{
    public Task<Product> GetById(long Id);
    public Task<IEnumerable<Product>> GetAll();
    public Task Delete(Product product);
    public Task Add(Product product);
    public Task Update(Product product);

}