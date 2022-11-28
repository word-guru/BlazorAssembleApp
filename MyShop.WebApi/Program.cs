using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Data.Ef;
using MyShop.Data.Ef.Repositories;
using MyShop.Domain.Repositories.Interface;
using MyShop.Domain.Services;
using MyShop.Models;

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
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.Configure<PasswordHasherOptions>(
    opt => opt.IterationCount = 100_000); 
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

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

app.Use(async (context, next) =>
{
    var userAgent = context.Request.Headers.UserAgent.ToString();
    if (userAgent.Contains("Edg"))
    {
        await next();
    }
    else
    {
        context.Response.Headers.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync("Браузер не поддерживается. Используйте Edg!");
        
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();