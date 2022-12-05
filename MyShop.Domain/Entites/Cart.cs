using MyShop.HttpModels;

namespace MyShop.Domain.Entites;

public class Cart : IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}