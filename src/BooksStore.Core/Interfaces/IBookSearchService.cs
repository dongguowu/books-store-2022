using Ardalis.Result;
using BooksStore.Core.BookAggregate;

namespace BooksStore.Core.Interfaces;

public interface IBookSearchService
{
    Task<Result<List<Book>>> GetAllBooks();
}
