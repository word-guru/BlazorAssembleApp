using MyShop.HttpModels;

namespace MyShop.Domain.Entites;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}