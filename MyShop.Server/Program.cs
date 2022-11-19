using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Server.Date;
using MyShop.Server.Repositories;
using MyShop.Server.Repositories.Interface;
using MyShop.Server.Repository.Models;
using MyShop.Server.Repository.Server.GenericRepository;
using MyShop.Server.Repository.Server.GenericRepository.InterfaceGenericRepozitory;
using MyShop.Server.Repository.Server.Services;

var builder = WebApplication.CreateBuilder(args);
var dbPath = "myapp.db";

// AddProduct services to the container.

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped(
    typeof(IGRepository<>), typeof(EfRepository<>));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();