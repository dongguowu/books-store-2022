using Autofac;
using BooksStore.Infra.Data.Repository;
using BooksStore.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace BooksStore.Infra.Ioc;

public class DefaultInfraModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
    .As(typeof(IRepository<>))
    .As(typeof(IReadRepository<>))
    .InstancePerLifetimeScope();
  }
}
