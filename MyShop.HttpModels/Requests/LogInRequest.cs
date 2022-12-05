using System.ComponentModel.DataAnnotations;

namespace MyShop.HttpModels.Requests;

public class LogInRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required] 
    [MinLength(6)]
    public string Password { get; set; }
}
