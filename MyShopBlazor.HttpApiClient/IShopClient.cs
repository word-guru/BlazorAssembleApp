using MyShopBlazor.App.Data;

namespace MyShopBlazor.HttpApiClient;

public interface IShopClient
{
    Task<IReadOnlyList<Product>> GetProducts();
    Task AddProduct(Product product);
    Task<Product> GetProduct(int id);
    Task DeleteProduct(int id);
}