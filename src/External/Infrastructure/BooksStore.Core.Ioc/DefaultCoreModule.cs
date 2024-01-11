using Autofac;
using BooksStore.Application.Services;

namespace BooksStore.Core.IoC;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<BookSearchService>().As<IBookSearchService>().InstancePerLifetimeScope();
    }
}
