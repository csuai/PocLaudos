using MudBlazor.Services;

using PocLaudos;
using PocLaudos.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
var conexao = builder.Configuration["Conexao"]!;

builder.Services.AddDbContext<Db>(options =>
{
    options.UseNpgsql(conexao);
});

builder.Services.AddScoped<INotifica, Notifica>();
builder.Services.AddTransient<ImportaDb>();
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

var scope = app.Services.CreateScope();
var importacaoDb = scope.ServiceProvider.GetRequiredService<ImportaDb>();
await importacaoDb.ImportaTudo();

app.Run();
