using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace BooksStore.Persistence.DatabaseContext;

public sealed class BookDatabaseContext : DbContext, IUnitOfWork
{
    public BookDatabaseContext(DbContextOptions<BookDatabaseContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var modifiedOrAddedEntities = ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified);

        foreach (var entityEntry in modifiedOrAddedEntities)
        {
            entityEntry.Entity.DateModified = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.DateCreated = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookDatabaseContext).Assembly);


        base.OnModelCreating(modelBuilder);
    }
}
