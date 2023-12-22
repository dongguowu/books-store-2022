using Autofac;
using BooksStore.Application.Features.Books.Commands.CreateBook;
using BooksStore.Domain.Bus;
using BooksStore.Domain.Entities;
using BooksStore.Infra.Bus;
using BooksStore.Infra.Data.Repository;
using MediatR;
using SharedKernel.Interfaces;

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

        builder
            .RegisterType<InMemoryBus>()
            .As<IMediatorHandler>()
            .InstancePerLifetimeScope();

        builder
            .RegisterType<CreateBookCommandHandler>()
            .As<IRequestHandler<CreateBookCommand, Book>>()
            .InstancePerLifetimeScope();


        //builder.Register<ServiceFactory>(context =>
        //{
        //    var c = context.Resolve<IComponentContext>();
        //    return t => c.Resolve(t);
        //});
    }
}
