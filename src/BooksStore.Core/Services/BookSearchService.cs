using Ardalis.Result;
using BooksStore.Core.BookAggregate;
using BooksStore.Core.Interfaces;
using SharedKernel.Interfaces;

namespace BooksStore.Core.Services;

public class BookSearchService : IBookSearchService
{
    private readonly IReadRepository<Book> _rep;

    public BookSearchService(IReadRepository<Book> rep)
    {
        _rep = rep;
    }

    public async Task<Result<List<Book>>> GetAllBooks()
    {
        return (await _rep.ListAsync()).ToList();
    }

}
