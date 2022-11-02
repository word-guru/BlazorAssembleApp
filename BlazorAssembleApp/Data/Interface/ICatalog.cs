namespace BlazorAssembleApp.Data;

public interface ICatalog
{
    IReadOnlyList<Product> GetProducts();
    void AddProduct(Product product);
}