using Ardalis.EFCore.Extensions;
using BooksStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace BooksStore.Infra.Data.Context;

public class AppDbContext : DbContext
{
    private readonly IMediator? _mediator;

    public AppDbContext(DbContextOptions<AppDbContext> options, IMediator? mediator) : base(options)
    {
        _mediator = mediator;
    }

    //public AppDbContext(DbContextOptions options) : base(options)
    //{
    //}

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null)
        {
            return result;
        }

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            entity.DomainEventClear();
            foreach (var domainEvent in entity.DomainEvents)
            {
                await _mediator.Publish(domainEvent).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
