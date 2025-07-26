using Equinox.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EquinoxContext>(options =>
    options.UseSqlite("Data Source=Equinox.db"));

// ✅ Add session services
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// ✅ Enable session
app.UseSession();

app.UseAuthorization();

// Admin area route
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();


