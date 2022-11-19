using MyShop.Models;

namespace MyShop.Server.Repository.Models;

public class Cart : IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}