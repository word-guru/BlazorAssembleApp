using System.ComponentModel.DataAnnotations;

namespace MyShop.Models;

public class User
{
    [MinLength(5)]
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}