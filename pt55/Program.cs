using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pt55.Data;
using pt55.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<pt55Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("pt55Context") ?? throw new InvalidOperationException("Connection string 'pt55Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(1); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usersaccounts}/{action=Login}/{id?}");

app.Run();
