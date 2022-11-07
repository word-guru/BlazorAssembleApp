using MyShop.Models;

namespace MyShop.App.Data.Interface;

public interface ICart
{
    List<Product> GetCartContents();
    void AddingToCart(Product product);
    void DeleteAnItem(Product product);
    void ClearAllBasket();
}