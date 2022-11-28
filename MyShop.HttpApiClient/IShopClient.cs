using MyShop.Models;
using MyShop.Server.Repository.Models;

namespace MyShop.HttpApiClient;

public interface IShopClient
{
    Task<IReadOnlyList<Product>> GetProducts();
    Task AddProduct(Product product);
    Task<Product> GetProduct(int id);
    Task DeleteProduct(int id);
    Task<IReadOnlyList<Category>> GetCategories();
    Task<IReadOnlyList<Cart>> GetCartItems();
    Task AddToCart(Cart cart);
    Task DeleteCart(long id);
    Task ClearCart();
   // Task RegisterAccount(Account user);
    Task RegisterAccount(User user);
    Task Authorization(User user);

}