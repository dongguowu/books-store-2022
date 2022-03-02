using Autofac;
using BooksStore.Infra.Data.Repository;
using BooksStore.SharedKernel.Interfaces;
using MediatR;
using Module = Autofac.Module;

namespace BooksStore.Infra.EfDB;

public class DefaultInfraModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
    .As(typeof(IRepository<>))
    .As(typeof(IReadRepository<>))
    .InstancePerLifetimeScope();

    builder
        .RegisterType<Mediator>()
        .As<IMediator>()
        .InstancePerLifetimeScope();

    builder.Register<ServiceFactory>(context =>
    {
      var c = context.Resolve<IComponentContext>();
      return t => c.Resolve(t);
    });

  }
}
