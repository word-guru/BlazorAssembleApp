using MyShop.HttpModels;

namespace MyShop.Domain.Entites;

public record Account : IEntity
{
    public Guid Id { get; set; }
    //[Required,MinLength(3)]
    public string Name { get; set; }
   // [Required,EmailAddress]
    public string Email { get; set; }
    //[Required,MinLength(6)]
    public string Password { get; set; }
    

}