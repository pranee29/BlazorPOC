using BlazorApp_DynamicForm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<EmployeeDetails>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI0NTcyNUAzMjMwMmUzNDJlMzBRMERPZEl3SVQvd3U0eUs2bVhpVEV3Vm1iYURZcFJYTmViS0FZSmZQT3VrPQ==");
await builder.Build().RunAsync();
