using Autofac;
using Autofac.Extensions.DependencyInjection;
using BooksStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
builder.Services.AddControllersWithViews();



//
string connectionString = builder.Configuration.GetConnectionString("SqliteConnection");

//wire up or define dependency that belongs to infrastructure
//DI database
builder.Services
  .AddDbContext<AppDbContext>(options =>
          options.UseSqlite(connectionString, b => b.MigrationsAssembly("BooksStore.Web")));
//DependencyContainer.RegisterServices(builder.Services);


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
  containerBuilder.RegisterModule(new DefaultCoreModule());
  containerBuilder.RegisterModule(new DefaultInfraModule());
});


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
