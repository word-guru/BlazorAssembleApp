using MyShop.Models;

namespace MyShop.Server.Repository;

public interface ICartRepository
{
    Task<IReadOnlyList<Cart>> GetCarts();
    Task AddCart(Cart cart);
    Task DeleteCartProduct(Cart cart);
    Task ClearCartProduct();
}