using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAssembleApp;
using BlazorAssembleApp.Data;
using Blazored.Toast;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddScoped<ICatalog, InMemoryCatalog>();
builder.Services.AddScoped<IClock, Clock>();
builder.Services.AddScoped<ICart, ShopingCart>();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();