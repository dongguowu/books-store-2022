using Ardalis.Result;
using BooksStore.Application.Features.Books.Queries.SearchBooks;
using BooksStore.Domain.Entities;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Services;

public class BookSearchService : IBookSearchService
{
    private readonly IReadRepository<Book> _rep;

    public BookSearchService(IReadRepository<Book> rep)
    {
        _rep = rep;
    }

    public async Task<Result<List<Book>>> GetAllBooks()
    {
        var query = new BooksSearchQuery(string.Empty);
        var handler = new BooksSearchQueryHandler(_rep);
        var cancellationToken = new CancellationToken();

        return await handler.Handle(query, cancellationToken);
    }
}
