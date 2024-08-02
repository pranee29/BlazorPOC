using Client_with_many_servers.Client.Pages;
using Client_with_many_servers.Shared;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


builder.Services.AddHttpClient("WeatherForecast", client =>
{
    client.BaseAddress = new Uri("https://localhost:7118/fetchdata");
});


builder.Services.AddHttpClient("User", client =>
{
    client.BaseAddress = new Uri("https://localhost:7187/fetchdata");
});


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7280") });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
