using ProvaDueDatabase.Data;
using Microsoft.EntityFrameworkCore;
using ProvaDueDatabase.Repository;
using ProvaDueDatabase.Services;
using ProvaDueDatabase.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ProvaDueContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddScoped<IFiguraRep, FiguraRep>();
builder.Services.AddScoped<IDomandeRep, DomandeRep>();
builder.Services.AddScoped<IFigureDomandeRep, FigureDomandeRep>();
builder.Services.AddScoped<IRisposteRepository, RisposteRep>();
builder.Services.AddScoped<IUtenteRep, UtenteRep>();
builder.Services.AddScoped<IFiguraService, FigureService>();
builder.Services.AddScoped<IDomandaService, DomandaService>();
builder.Services.AddScoped<IFigureDomandeService, FigureDomandeService>();
builder.Services.AddScoped<IRispostaService, RispostaService>();
builder.Services.AddScoped<IUtenteService, UtenteService>();
//builder.Services.AddScoped<IUnityWork, UnitWork>();
builder.Services.AddSession(builder =>
{
    builder.IdleTimeout = TimeSpan.FromSeconds(320);
});
// SIGNAL R
builder.Services.AddSignalR();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/avatarChat");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//  name: "default",
//  pattern: "{controller=Home}/{action=Index}/{id?}");

//    endpoints.MapHub<ChatHub>("/avatarChat");


//});

app.Run();
