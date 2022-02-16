using BooksStore.Infra.Data.Context;
using BooksStore.Infra.Ioc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 
string connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

//wire up or define dependency that belongs to infrastructure
//DI database
builder.Services
  .AddDbContext<AppDbContext>(options =>
          options.UseSqlite(connectionString));
DependencyContainer.RegisterServices(builder.Services);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
