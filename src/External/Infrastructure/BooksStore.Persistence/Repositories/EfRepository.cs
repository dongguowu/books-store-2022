using Ardalis.Specification.EntityFrameworkCore;
using BooksStore.Persistence.DatabaseContext;
using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Persistence.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : BaseEntity, IAggregateRoot
{
    public EfRepository(BookDatabaseContext dbContext) : base(dbContext)
    {
    }
}
