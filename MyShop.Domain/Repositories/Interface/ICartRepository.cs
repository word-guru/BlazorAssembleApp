using MyShop.Server.Repository.Models;

namespace MyShop.Domain.Repositories.Interface;

public interface ICartRepository
{
    Task<IReadOnlyList<Cart>> GetCarts();
    Task AddCart(Cart cart);
    Task DeleteCartProduct(Cart cart);
    Task ClearCartProduct();
}