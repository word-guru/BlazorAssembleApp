using MyShop.Models;

namespace MyShop.App.Data.Interface;

public interface ICatalog
{
    IReadOnlyList<Product> GetProducts();
    void AddProduct(Product product);
}
