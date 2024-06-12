using Microsoft.EntityFrameworkCore;
using SPA.ServicesApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


//
builder.Services.AddDbContext<AppDbContext>(
    options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultt"))
);
//

builder.Services.AddScoped<ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
