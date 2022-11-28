using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShop.Server.Repository.BlazorClient.Data;
using MyShop.Server.Repository.BlazorClient.Data.Interface;
using Blazored.Toast;
using FluentValidation;
using MyShop.BlazorClient;
using MyShop.Domain.Validators;
using MyShop.HttpApiClient;
using MyShop.Models;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IShopClient, ShopClient>();//7004 7203

builder.Services.AddScoped<IClock, Clock>();
//builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
// builder.Services.AddFluentValidationAutoValidation(config => 
// {
//     config.DisableDataAnnotationsValidation = true;
// });
//builder.Services.AddScoped<IValidator<User>UserValidator>()
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<User>());
builder.Services.AddBlazoredToast();
/*builder.Services.AddHttpClient<IShopClient, ShopClient>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});*/


builder.Services.AddBlazoredToast(); 

await builder.Build().RunAsync();

