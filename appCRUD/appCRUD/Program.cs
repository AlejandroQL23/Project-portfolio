using System;
using appCRUD.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//crear variable para la cadena de conexion
var conectionString = builder.Configuration.GetConnectionString("Conection");
//Registra servicio para la conexion
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(conectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Employee}/{action=List}/{id?}");

app.Run();
