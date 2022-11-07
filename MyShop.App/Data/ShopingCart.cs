using MyShop.App.Data.Interface;
using MyShop.Models;

namespace MyShop.App.Data;

public class ShopingCart : ICart
{
    private List<Product> Products { get; set; }

    public ShopingCart()
    {
        Products = new List<Product>();
    }
    public List<Product> GetCartContents()
    {
        return Products;
    }

    public void AddingToCart(Product product)
    {
        Products.Add(product);
    }

    public void DeleteAnItem(Product product)
    {
        Products.Remove(product);
    }

    public void ClearAllBasket()
    {
        Products.Clear();
    }
}