namespace MyShop.Server.Repository.Models;

public class Product : IEntity
{
    public Product(
        Guid              id, 
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

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}