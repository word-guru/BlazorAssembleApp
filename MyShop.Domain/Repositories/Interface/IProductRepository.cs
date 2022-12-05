using MyShop.Domain.Entites;
using MyShop.HttpModels;

namespace MyShop.Domain.Repositories.Interface;

public interface IProductRepository
{
    public Task<Product> GetProduct(Guid id);
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task DeleteProduct(Product product);
    public Task AddProduct(Product product);
    public Task UpdateProduct(Product product);
    Task<IEnumerable<Category>> GetCategories();

}