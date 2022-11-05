namespace MyShopBlazor.App.Data.Interface;

public interface ICart
{
    List<Product> GetCartContents();
    void AddingToCart(Product product);
    void DeleteAnItem(Product product);
    void ClearAllBasket();
}