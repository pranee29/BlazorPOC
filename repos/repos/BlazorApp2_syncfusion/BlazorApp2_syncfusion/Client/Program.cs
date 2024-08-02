using BlazorApp2_syncfusion.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Layouts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<DataModel>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI0NTcyNUAzMjMwMmUzNDJlMzBRMERPZEl3SVQvd3U0eUs2bVhpVEV3Vm1iYURZcFJYTmViS0FZSmZQT3VrPQ==");
await builder.Build().RunAsync();
