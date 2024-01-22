using BooksStore.Application;
using BooksStore.Infrastructure.Shared;
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
