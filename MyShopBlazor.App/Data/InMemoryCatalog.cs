using MyShop.Models;
using MyShopBlazor.App.Data.Interface;

namespace MyShopBlazor.App.Data;

public class InMemoryCatalog : ICatalog
{
    private readonly object _sync = new();

    private List<Product> Products { get; } = new()
    {
        new Product(1, "Чистый код", 100),
        new Product(2, "Чистая архитектура", 200),
        new Product(3, "Entity Framewrok в действии", 300),
    };

    public IReadOnlyList<Product> GetProducts()
    {
        lock (_sync)
        {
            if (DateTime.UtcNow.DayOfWeek == DayOfWeek.Monday)
            {
                return Products
                    .Select(product =>
                        new Product(product.Id, product.Name, product.Price * 1.5m)
                    )
                    .ToList();
            }
            return Products.ToList();
        }
    }

    public void AddProduct(Product product)
    {
        lock (_sync)
        {
            Products.Add(product);
        }
    }
}