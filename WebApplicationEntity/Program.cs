using BlazorAssembleApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationEntity.Models;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();
app.MapGet("/Catalog", async (AppDbContext context) => await context.Products.ToListAsync());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//add_product RPC
// /catalog/products REST
app.MapPost("/add_product", async ([FromBody]Product product, [FromServices]AppDbContext dbContext) =>
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
    })
    .WithDisplayName("Добавляет товар");

app.MapGet("/get_products", ([FromServices] AppDbContext dbContext) =>
    {
        return dbContext.Products.ToListAsync();
    })
    .WithDisplayName("Получает товар");

app.MapPost("/update_product",
    async ([FromServices] AppDbContext dbContext,
        [FromQuery] long id, string name, decimal price) =>
    {
        var product = await dbContext.Products.FindAsync(id);
        product!.Name = name;
        product.Price = price;
        dbContext.Products.Update(product!);
        await dbContext.SaveChangesAsync();
    })
    .WithDisplayName("Обновляет товар");

app.MapPost("/get_product",
        async ([FromServices] AppDbContext dbContext,
            [FromQuery] long id) =>
        {
            return await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        })
    .WithDisplayName("Получает товар по id");

app.MapPost("/delete_product",
    async ([FromServices] AppDbContext dbContext,
        [FromQuery] long productId) =>
    {
        var product = await dbContext.Products.FindAsync(productId);
        dbContext.Products.Remove(product!);
        await dbContext.SaveChangesAsync();
    })
    .WithDisplayName("Удаляет товар");


app.Run();