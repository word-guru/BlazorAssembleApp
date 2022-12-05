namespace MyShop.HttpModels.Responses;

public class LogInResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    
}