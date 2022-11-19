using MyShop.Models;

namespace MyShop.Server.Repository.Models;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}