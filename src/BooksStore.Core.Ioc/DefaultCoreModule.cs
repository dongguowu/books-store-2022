using Autofac;
using BooksStore.Core.Interfaces;
using BooksStore.Core.Services;

namespace BooksStore.Core.IoC;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<BookSearchService>().As<IBookSearchService>().InstancePerLifetimeScope();
  }
}
