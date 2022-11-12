using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Date;

namespace MyShop.Server.Repository;

public interface IProductRepository
{
    public Task<Product> GetProduct(long id);
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task DeleteProduct(Product product);
    public Task AddProduct(Product product);
    public Task UpdateProduct(Product product);
    Task<IEnumerable<Category>> GetCategories();
    Task<IReadOnlyList<Cart>> GetCarts();
    Task AddCart(Cart cart);

}