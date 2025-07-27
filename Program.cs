using Equinox.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Use HOME/data on Azure or current directory locally
var dbPath = Path.Combine(
    Environment.GetEnvironmentVariable("HOME") ?? Directory.GetCurrentDirectory(),
    "data", "Equinox.db"
);

// ✅ Create folder if it doesn't exist
var dataDir = Path.GetDirectoryName(dbPath);
if (!Directory.Exists(dataDir))
{
    Directory.CreateDirectory(dataDir!);
}

// ✅ Register DbContext with SQLite
builder.Services.AddDbContext<EquinoxContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

// ✅ Add session services
builder.Services.AddSession();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// ✅ Enable session
app.UseSession();

app.UseAuthorization();

// ✅ Auto-create SQLite database and seed if needed
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EquinoxContext>();
    context.Database.EnsureCreated(); // Use .Migrate() if using migrations
}

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

