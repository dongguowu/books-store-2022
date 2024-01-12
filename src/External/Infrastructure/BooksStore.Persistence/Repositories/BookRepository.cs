using BooksStore.Domain.Entities;
using BooksStore.Persistence.DatabaseContext;

namespace BooksStore.Persistence.Repositories;

public sealed class BookRepository : EfRepository<Book>
{
    public BookRepository(BookDatabaseContext dbContext) : base(dbContext)
    {
    }
}
