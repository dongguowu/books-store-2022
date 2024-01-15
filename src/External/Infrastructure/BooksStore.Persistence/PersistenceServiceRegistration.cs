using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using BooksStore.Persistence.DatabaseContext;
using BooksStore.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Interfaces;

namespace BooksStore.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddEfPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EfDatabaseConnectionString");

        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            services.AddDbContext<BookDatabaseContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });


            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IMediator), typeof(Mediator));
            services.AddScoped(typeof(IRequestHandler<GetAllBookCategoryQuery, List<BookCategoryDto>>),
                typeof(GetAllBookCategoryQueryHandler));
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
