using BooksStore.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksStore.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EfDatabaseConnectionString");

        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            services.AddDbContext<BookDatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
        else
        {
            throw new InvalidOperationException("Database connection string is missing or empty.");
        }

        return services;
    }


    public static IServiceCollection AddInMemoryPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<BookDatabaseContext>(options =>
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            options.UseInMemoryDatabase("bookStore").UseApplicationServiceProvider(serviceProvider);
        });

        return services;
    }
}
