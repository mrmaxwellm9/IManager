using IManager;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using IManager.Data;
using IManager.Services;
using IManager.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ProductRepository, ProductRepository>();
builder.Services.AddScoped<LocationRepository, LocationRepository>();

// Adding Database context
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<InventoryModel, InventoryModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapRazorPages();

app.Run();
