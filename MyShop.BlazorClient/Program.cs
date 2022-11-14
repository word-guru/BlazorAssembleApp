using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShop.BlazorClient;
using MyShop.BlazorClient.Data;
using MyShop.BlazorClient.Data.Interface;
using Blazored.Toast;
using MyShop.HttpApiClient;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IShopClient, ShopClient>();//7004 7203

builder.Services.AddScoped<IClock, Clock>();
builder.Services.AddBlazoredToast();
/*builder.Services.AddHttpClient<IShopClient, ShopClient>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});*/


builder.Services.AddBlazoredToast(); 

await builder.Build().RunAsync();

