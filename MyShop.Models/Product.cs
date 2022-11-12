namespace MyShop.Models;

public class Product
{
    public Product(
        long              id, 
        string            name, 
        decimal           price, 
        string            description, 
        string            imageUrl, 
        int               quantity, 
        int               categoryId
        )
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        ImageUrl = imageUrl;
        Quantity = quantity;
        CategoryId = categoryId;
    }

   public Product()
    {
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}