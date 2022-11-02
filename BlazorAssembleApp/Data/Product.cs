namespace BlazorAssembleApp.Data;

public class Product
{
    public Product(long id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    protected Product(){}

    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}