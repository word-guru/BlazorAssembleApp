using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Server.Repository;

namespace MyShop.Server.Controllers;

[Route("catalog")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public CatalogController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet("get_products")] 
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _productRepository.GetAll();
    }

    [HttpGet("get_product")]
    public async Task<Product?> GetProduct(long id)
    {
        var product = await _productRepository.GetById(id);
        if (product is null)
        {
            return null;
        }
        return product;
    }

    [HttpPost("add_product")]
    public async Task AddProducts(Product product)
    {
        await _productRepository.Add(product);
    }
    
    [HttpPost("delete_product")]
    public async Task DeleteProduct(long id)
    {
        var product = await _productRepository.GetById(id);
        

        _productRepository.Delete(product!);

      
    }
    
}