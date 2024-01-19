using BooksStore.Application;
using BooksStore.Application.DTOs.Settings;
using BooksStore.Application.Interfaces.Shared;
using BooksStore.Infrastructure.Shared;
using BooksStore.Infrastructure.Shared.Services;
using BooksStore.Persistence;

namespace BooksStore.WebApi.Settings;

public static class ContainerRegistration
{
    public static IServiceCollection AddContainer(this IServiceCollection services,
         WebApplicationBuilder builder)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(builder.Configuration);
       services.AddEfPersistenceServices(builder.Configuration);
        return services;
    }
}
