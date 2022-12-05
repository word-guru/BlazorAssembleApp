using System.ComponentModel.DataAnnotations;

namespace MyShop.Models.Requests;

public class LogInRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required] 
    [MinLength(6)]
    public string Password { get; set; }
}
