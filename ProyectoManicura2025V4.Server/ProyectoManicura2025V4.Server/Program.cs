using Microsoft.EntityFrameworkCore;
using ProyectoManicura2025V4.BD.Datos;
using ProyectoManicura2025V4.BD.Datos.Entidades;
using ProyectoManicura2025V4.Repositorio.Repositorios;
using ProyectoManicura2025V4.Server.Client.Pages;
using ProyectoManicura2025V4.Server.Components;
using ProyectoManicura2025V4.Servicio.ServiciosHttp;

//configura el Constructor de la aplicacion
var builder = WebApplication.CreateBuilder(args);
#region
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7068") });
builder.Services.AddScoped<IHttpServicio, HttpServicio>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


var ConnectionString = builder.Configuration.GetConnectionString("ConnSqlServer")
    ?? throw new InvalidOperationException("El string de conexion no existe.");

builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(ConnectionString));
builder.Services.AddScoped<IRepositorio<turno>, Repositorio<turno>>();



// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
#endregion
//Construye la aplicacion
var app = builder.Build();
#region
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ProyectoManicura2025V4.Server.Client._Imports).Assembly);

app.MapControllers();
#endregion
app.Run();
