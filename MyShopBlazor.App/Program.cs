using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyShopBlazor.App;
using MyShopBlazor.App.Data;
using MyShopBlazor.App.Data.Interface;
using Blazored.Toast;
using MyShopBlazor.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IShopClient, ShopClient>();//7004 7203

builder.Services.AddScoped<ICatalog, InMemoryCatalog>();
builder.Services.AddScoped<IClock, Clock>();
builder.Services.AddScoped<ICart, ShopingCart>();
/*builder.Services.AddHttpClient<IShopClient, ShopClient>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});*/


builder.Services.AddBlazoredToast(); 

await builder.Build().RunAsync();

