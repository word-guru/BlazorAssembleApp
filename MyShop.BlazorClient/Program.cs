using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShop.Server.Repository.BlazorClient.Data;
using MyShop.Server.Repository.BlazorClient.Data.Interface;
using Blazored.Toast;
using FluentValidation;
using MyShop.BlazorClient;
using MyShop.HttpApiClient;
using MyShop.HttpModels;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IShopClient, ShopClient>();//7004 7203

builder.Services.AddScoped<IClock, Clock>();
builder.Services.AddBlazoredToast();
/*builder.Services.AddHttpClient<IShopClient, ShopClient>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});*/

/*builder.Services.AddValidatorsFromAssemblyContaining<UserRegisterValidator>();
 builder.Services.AddFluentValidationAutoValidation(config => 
 {
     config.DisableDataAnnotationsValidation = true;
 });
builder.Services.AddScoped<IValidator<User>UserRegisterValidator>()
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<User>());*/

builder.Services.AddBlazoredToast(); 

await builder.Build().RunAsync();

