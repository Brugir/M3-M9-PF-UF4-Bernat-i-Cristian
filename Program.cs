using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PokeDexWeb.Data;
using PokeDexWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Afegir serveis per a la base de dades i l'API
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=pokedex.db"));

builder.Services.AddHttpClient<PokemonService>();

// Afegir suport per a les vistes i el controlador
builder.Services.AddControllersWithViews();
// Afegir serveis de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar la línia de rutes per a l'aplicació
if (app.Environment.IsDevelopment())
{
    // Activar Swagger només en desenvolupament
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configurar la ruta per defecte i les vistes de controlador
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pokemon}/{action=Search}/{id?}"); // Estableix la pàgina de cerca per defecte

app.Run();
