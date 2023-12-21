using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;

namespace BooksStore.Infrastructure.Repositories;

public sealed class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Insert(Book book)
    {
        _dbContext.Set<Book>().Add(book);
    }
}
