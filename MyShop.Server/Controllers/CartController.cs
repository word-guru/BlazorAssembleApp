using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.Date.Repository.Interface;
using MyShop.Server.Repository;

namespace MyShop.Server.Controllers;

[Route("cart")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost("add_cart")]
    public async Task AddCart(Cart cart)
    {
        await _cartRepository.AddCart(cart);
    }

    [HttpGet("get_carts")]
    public async Task<IEnumerable<Cart>> GetCarts()
    {
       return await _cartRepository.GetCarts();
    }

    [HttpPost("delete_cart")]
    public async Task DeleteCart(Cart cart)
    {
        await _cartRepository.DeleteCartProduct(cart);
    }

    [HttpPost("clear_cart")]
    public async Task ClearCart()
    {
        await _cartRepository.ClearCartProduct();
    }
}