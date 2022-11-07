using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShopBlazor.Server.Date;

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

app.MapGet("/Catalog", async (AppDbContext context) => await context.Products.ToListAsync());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
            [FromQuery] long id,[FromBody]Product newProduct) =>
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(it => it.Id == id);
            if (product is null)
            {
                return Results.NotFound(new {message = "Товар не найден"});
            }
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        })
    .WithDisplayName("Обновляет товар");

app.MapGet("/get_product",
        async ([FromServices] AppDbContext dbContext,
            [FromQuery] long id) =>
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return Results.NotFound(new {message = "Товар не найден"});
            }

            return Results.Ok(product);
        })
    .WithDisplayName("Получает товар по id");

app.MapPost("/delete_product",
        async ([FromServices] AppDbContext dbContext,
            [FromQuery] long id) =>
        {
            var product = await dbContext.Products.FirstAsync(it => it.Id == id);
            if (product is null)
            {
                return Results.NotFound(new {message = "Товар не найден"});
            }
            dbContext.Products.Remove(product!);
            await dbContext.SaveChangesAsync();
            
            return Results.Ok();
        })
    .WithDisplayName("Удаляет товар");


app.Run();