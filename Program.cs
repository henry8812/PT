using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PTSeleccion.Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar soporte para páginas Razor y controladores
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Configurar el contexto de la base de datos con Identity
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-N6M1J20\\MSSQLSERVER01;Database=PT01;User Id=admindb;Password=swordfish;");
});

builder.Services.AddIdentity<User, Role>(options =>
{
    // Configura las opciones de Identity si es necesario
})
.AddEntityFrameworkStores<DBContext>()
.AddUserStore<UserStore<User, Role, DBContext, int>>()
.AddRoleStore<RoleStore<Role, DBContext, int>>();

var app = builder.Build();
app.UseStaticFiles();

// Habilitar el uso de controladores
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configuración del frontend: Rutas para las páginas y vistas
app.UseEndpoints(endpoints =>
{
    // Mapear las páginas Razor
    endpoints.MapRazorPages();

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
