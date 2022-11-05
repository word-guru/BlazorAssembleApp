namespace MyShopBlazor.App.Data.Interface;

public interface ICatalog
{
    IReadOnlyList<Product> GetProducts();
    void AddProduct(Product product);
}
