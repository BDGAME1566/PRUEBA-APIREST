using System.Text.Json;
using RetoTecnico.Components;
using RetoTecnico.Models;
using RetoTecnico.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<TipoMovimientoService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5282/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapGet("api/tiposmovimiento", async () =>
{
    var dataPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "data", "tipos-movimiento.json");
    await using var stream = File.OpenRead(dataPath);
    var movimientos = await JsonSerializer.DeserializeAsync<List<TipoMovimiento>>(stream);
    return Results.Ok(movimientos ?? new List<TipoMovimiento>());
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();