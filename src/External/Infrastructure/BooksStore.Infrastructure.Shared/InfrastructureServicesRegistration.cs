using BooksStore.Application.DTOs.Settings;
using BooksStore.Application.Interfaces.Shared;
using BooksStore.Infra.Data.Repository;
using BooksStore.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Interfaces;

namespace BooksStore.Infrastructure.Shared;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, SendGridEmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
