using Microsoft.EntityFrameworkCore;
using Login.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
//crear variable para la cadena de conexion
var conectionString = builder.Configuration.GetConnectionString("Conection");
//Registra servicio para la conexion
builder.Services.AddDbContext<appDBContext>(options => options.UseSqlServer(conectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Registrarse}/{id?}");

app.Run();
