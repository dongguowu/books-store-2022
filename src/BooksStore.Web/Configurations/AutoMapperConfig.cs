using BooksStore.Core.BookAggregate.AutoMapper;

namespace BooksStore.Web.Configurations;

public static class AutoMapperConfig
{
    public static void RegisterAutoMapper(this IServiceCollection services)
    {
        //AutoMapperConfiguration.RegisterMappings().AssertConfigurationIsValid();

        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        AutoMapperConfiguration.RegisterMappings();
    }
}
