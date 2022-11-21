using Microsoft.AspNetCore.Mvc;
using MyShop.Domain.Repositories.Interface;
using MyShop.Server.Repository.Models;

namespace MyShop.WebApi.Controllers;

[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly IGRepository<Category> _category;

    public CategoryController(IGRepository<Category> category)
    {
        _category = category;
    }
    
    [HttpGet("get_categories")]
    public async Task<IReadOnlyList<Category>> GetCategories()
    {
        return await _category.GetAll();
    }
    
    [HttpGet("get_category")]
    public async Task <Category> GetCategory(Guid id)
    {
        return await _category.GetById(id);
    }
    
    [HttpPost("add_category")]
    public async Task AddCategory(Category category)
    {
        await _category.Add(category);
    }
}