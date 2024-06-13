using Microsoft.EntityFrameworkCore;
using SPA.ServicesApp;
using Examen3.ServiceApp2;
using Examen3.ServiceApp2.Contrato;
using Examen3.ServiceApp2.Implementacion;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();



//
builder.Services.AddDbContext<AppDbContext>(
    options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultt"))
);
//

builder.Services.AddScoped<ProductoService>();

///////////////////
builder.Services.AddDbContext<ApplicationDbContext>(
    options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Defaultt2"))
);

builder.Services.AddScoped<UsuarioService>();

builder.Services.AddAuthentication(CoockieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>){
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    }
//////////////////////////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
