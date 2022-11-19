using Microsoft.AspNetCore.Mvc;
using MyShop.Server.Repository.Models;
using MyShop.WebApi.GenericRepository.InterfaceGenericRepozitory;

namespace MyShop.WebApi.Controllers;

[Route("cart")]
public class CartController : ControllerBase
{
    private readonly IGRepository<Cart> _cart;

    public CartController(IGRepository<Cart> cart)
    {
        _cart = cart;
    }

    [HttpPost("add_cart")]
    public async Task AddCart(Cart cart)
    {
        await _cart.Add(cart);
    }

    [HttpGet("get_carts")]
    public async Task<IEnumerable<Cart>> GetCarts()
    {
       return await _cart.GetAll();
    }

    [HttpPost("delete_cart")]
    public async Task Delete(Guid id)
    {
        await _cart.DeleteById(id);
    }

    // [HttpPost("clear_cart")]
    // public async Task ClearCart()
    // {
    //     await _cartRepository.ClearCartProduct();
    // }
}