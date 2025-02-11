using Bank;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

string filePath = Path.Combine(AppContext.BaseDirectory, "wwwaaaaaaroot", "bankState.json");
builder.Services.AddSingleton(implementationInstance: new BankStateService { FilePath = filePath });

await builder.Build().RunAsync();
