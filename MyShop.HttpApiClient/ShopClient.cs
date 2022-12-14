using System.Net.Http.Headers;
using System.Net.Http.Json;
using MyShop.Domain.Entites;
using MyShop.HttpModels.Requests;
using MyShop.HttpModels.Responses;

namespace MyShop.HttpApiClient;

public class ShopClient : IShopClient
{
    private const string DefaultHost = $"https://localhost:7203";
    private const string DefaultController = "catalog";
    private readonly string _controller;
    private readonly string _host;
    
    private readonly HttpClient _httpClient;

    public ShopClient(string host = DefaultHost,
                      HttpClient? httpClient = null,
                      string controller = DefaultController
    )
    {
        _host = host;
        _httpClient = httpClient ?? new HttpClient();
        _controller = controller;
    }

    public async Task<IReadOnlyList<Product>> GetProducts()
    {
        string uri = $"{_host}/{_controller}/get_products";
        IReadOnlyList<Product>? response = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
        
        return response;
    }

    public async Task AddProduct(Product product)
    {
        if (product is not null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        var uri = $"{_host}/{_controller}/add_product";
        await _httpClient.PostAsJsonAsync(uri, product);
    }

    public async Task<Product> GetProduct(int id)
    {
        var uri = $"{_host}/{_controller}/get_product";
        var product = await _httpClient.GetFromJsonAsync<Product>($"{uri}?Id={id}");
        if (product is null)
        {
            throw new InvalidOperationException("Product can`t be null");
        }

        return product;
    }

    public async Task DeleteProduct(int id)
    {
        var uri = $"{_host}/{_controller}/delete_product";
        var response = await _httpClient.PostAsync($"{uri}?productId={id}", null);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateProduct(Product product)
    {
        var uri = $"{_host}/{_controller}/update_product";
        //var product = await _httpClient.GetFromJsonAsync<Product>($"{uri}?id={id}")
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        
        await _httpClient.PutAsJsonAsync($"{uri}?productId={product.Id}", product);
    }
   
    public async Task<IReadOnlyList<Category>> GetCategories()
    {
        var uri = $"{_host}/{_controller}/get_categories";
        var response = await _httpClient
            .GetFromJsonAsync<IReadOnlyList<Category>>(uri);
        
        return response;
    }
 
    public async Task<IReadOnlyList<Cart>> GetCartItems()
    {
        var uri = $"{_host}/cart/get_carts";
        var response = await _httpClient
            .GetFromJsonAsync<IReadOnlyList<Cart>>(uri);
        
        return response;
    }
    
    public async Task AddToCart(Cart cart)
    {
        if (cart is null)
        {
            throw new ArgumentNullException(nameof(cart));
        }
        var uri = $"{_host}/cart/add_cart";
        await _httpClient.PostAsJsonAsync(uri, cart);
    }
    public async Task DeleteCart(long id)
    {
        var uri = $"{_host}/cart/delete_cart";
        var response = await _httpClient.PostAsync($"{uri}?cartId={id}", null);

        response.EnsureSuccessStatusCode();
    }
    public async Task ClearCart()
    {
       // var uri = $"{_host}/cart/clear_cart";
       // var response = await _httpClient.PostAsync();

       // response.EnsureSuccessStatusCode();
    }

    // public async Task RegisterAccount(Account user)
    // {
    //     var uri = $"{_host}/user/register";
    //     var response = await _httpClient.PostAsJsonAsync(uri, user);
    //     response.EnsureSuccessStatusCode();
    // }

    public async Task RegisterAccount(RegisterRequest user)
    {
        var uri = $"{_host}/account/register";
        var response = await _httpClient.PostAsJsonAsync(uri, user);
        response.EnsureSuccessStatusCode();
    }

   /* public async Task<Account> GetLogIn(LogInRequest user)
    {
        var uri = $"{_host}/account/register";
        var response = await _httpClient.PostAsJsonAsync(uri, user);
        response.EnsureSuccessStatusCode();
    }*/

    public async Task<LogInResponse> LogIn(LogInRequest user)
    {
        var uri = $"{_host}/account/login";
        var response = await _httpClient.PostAsJsonAsync(uri, user);

        response.EnsureSuccessStatusCode();
         var logInResponse = await response.Content.ReadFromJsonAsync<LogInResponse>();
         
         SetAuthorizationToken(logInResponse!.Token);
        
        return  logInResponse!;
    }
    
    public void SetAuthorizationToken(string token)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        var header = new AuthenticationHeaderValue("Bearer", token);
        _httpClient.DefaultRequestHeaders.Authorization = header;
       // IsAuthorizationTokenSet = true;
    }

    public async Task<AccountInfoResponse> GetCurrentAccount()
    {
        var uri = $"{_host}/account/get_info";
        var response = await _httpClient.GetFromJsonAsync<AccountInfoResponse>(uri);
        return response!;
    }
}