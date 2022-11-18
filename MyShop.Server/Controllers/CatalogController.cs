using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.GenericRepository.InterfaceGenericRepozitory;
using MyShop.Server.Repository;

namespace MyShop.Server.Controllers;

[Route("catalog")]
public class CatalogController : ControllerBase
{
    private readonly IGRepository<Product> _product;
    private readonly IGRepository<Category> _category;

    public CatalogController(IGRepository<Product> product,
        IGRepository<Category> category)
    {
        _product = product;
        _category = category;
    }

    [HttpGet("get_products")]
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _product.GetAll();
    }

    [HttpGet("get_product")]
    public async Task<Product?> GetProduct(Guid id)
    {
        return await _product.GetById(id);
    }

    [HttpPost("add_product")]
    public async Task AddProducts(Product product)
    {
        await _product.Add(product);
    }

    [HttpPost("delete_product")]
    public async Task DeleteProduct(Guid id)
    {
        await _product.DeleteById(id);
    }
}