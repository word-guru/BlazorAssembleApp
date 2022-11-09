using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Server.Date;
using MyShop.Server.Repository;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));
builder.Services.AddCors();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
);*/

app.MapGet("/catalog", async (IProductRepository productRepository) => await productRepository.GetAll());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/add_product", async ([FromBody] Product product, [FromServices] IProductRepository productRepository) =>
{
    await productRepository.Add(product);
    //await dbContext.SaveChangesAsync();
});

app.MapGet("/get_products", ([FromServices] IProductRepository productRepository) =>
{
    return productRepository.GetAll();
});

app.MapPut("/update_product",
    async ([FromServices] IProductRepository productRepository,
        [FromQuery] long id, [FromBody] Product newProduct) =>
    {
        var product = await productRepository.GetById(id);
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
        var product = await productRepository.GetById(id);
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
        var product = await productRepository.GetById(id);
        if (product is null)
        {
            return Results.NotFound(new {message = "Товар не найден"});
        }

        productRepository.Delete(product!);

        return Results.Ok();
    });


app.Run();