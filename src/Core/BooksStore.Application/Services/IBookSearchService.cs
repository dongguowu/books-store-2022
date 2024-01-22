using Ardalis.Result;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.Services;

public interface IBookSearchService
{
    Task<Result<List<Book>>> GetAllBooks();
}
