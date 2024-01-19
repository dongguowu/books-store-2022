using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BooksStore.Application;
using BooksStore.Infrastructure.Shared;
using BooksStore.Persistence;
using BooksStore.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

Assembly.GetExecutingAssembly();

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEfPersistenceServices(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterAutoMapper();


//
//var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection");

//wire up or define dependency that belongs to infrastructure
//DI database
//builder.Services
//    .AddDbContext<BookDatabaseContext>(options =>
//        options.UseSqlite(connectionString, b => b.MigrationsAssembly("BooksStore.Web")));
//DependencyContainer.RegisterServices(builder.Services);


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    //containerBuilder.RegisterModule(new DefaultCoreModule());
    //containerBuilder.RegisterModule(new DefaultInfraModule());
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //    options.RoutePrefix = string.Empty;
    //});
}

;

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();
