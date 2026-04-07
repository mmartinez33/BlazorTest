using BlazorApp1.Components;
using BlazorApp1.Data;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//var connectionString = "Server = localhost; Uid = root; Password = epic89; Port = 3306; database = show_elements; ";

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register DbContext with MySQL provider
if (connectionString != null)
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}
else
{
    Console.WriteLine("The connectionString is null");
}

builder.Services.AddRazorPages();  // Added from CoPilot Search about MySQL
builder.Services.AddServerSideBlazor();  // Added from CoPilot Search about MySQL
builder.Services.AddSignalR();  // My Custom Hubs

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();  // Added from CoPilot Search about MySQL
app.UseRouting();  // Added from CoPilot Search about MySQL

app.UseAuthentication();
app.UseAntiforgery();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapBlazorHub();  // Added from CoPilot Search about MySQL
//app.MapHub<StatusHub>("/statushub"); // My Status Hub
//app.MapFallbackToPage("/_Host");  // Added from CoPilot Search about MySQL

app.UseHttpsRedirection();




app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Automatically create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Creates DB & tables from models
}

app.Run();
