using Ardalis.Specification.EntityFrameworkCore;
using SharedKernel;
using SharedKernel.Interfaces;

namespace BooksStore.Infrastructure.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : BaseEntity, IAggregateRoot
{
    public EfRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
