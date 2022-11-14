using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Date;
using MyShop.Server.Date.Repository;
using MyShop.Server.Date.Repository.Interface;
using MyShop.Server.Repository;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// AddProduct services to the container.

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

var app = builder.Build();

app.UseCors(policy =>
{
    policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin =>
            origin is "https://localhost:7004" //7004 7203
                or "https://mysite.ru"
        )
        .AllowCredentials();
});
/*app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7296, https://localhost:7296")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType)
);

//app.MapGet("/catalog", async (IProductRepository productRepository) => await productRepository.GetAllProducts());

// Configure the HTTP request pipeline.*/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*app.MapPost("/add_product", async ([FromBody] Product product, 
                                               [FromServices] IProductRepository productRepository) =>
{
    await productRepository.AddProduct(product);
    //await dbContext.SaveChangesAsync();
});

app.MapGet("/get_products", ([FromServices] IProductRepository productRepository) =>
{
    return productRepository.GetAllProducts();
});

app.MapPost("/update_product",
    async ([FromServices] IProductRepository productRepository,
        [FromQuery] long id, [FromBody] Product newProduct) =>
    {
        var product = await productRepository.GetProduct(id);
        if (product is null)
        {
            return Results.NotFound(new {message = "Товар не найден"});
        }

        product.Name = newProduct.Name;
        product.Price = newProduct.Price;
        return Results.Ok();
    });

app.MapGet("/get_product",
    async ([FromServices] IProductRepository productRepository,
        [FromQuery] long id) =>
    {
        var product = await productRepository.GetProduct(id);
        if (product is null)
        {
            return Results.NotFound(new {message = "Товар не найден"});
        }

        return Results.Ok(product);
    });

app.MapPost("/delete_product",
    async ([FromServices]IProductRepository productRepository,
        [FromQuery] long id) =>
    {
        var product = await productRepository.GetProduct(id);
        if (product is null)
        {
            return Results.NotFound(new {message = "Товар не найден"});
        }

        productRepository.DeleteProduct(product!);

        return Results.Ok();
    });*/
app.MapControllers();

app.Run();