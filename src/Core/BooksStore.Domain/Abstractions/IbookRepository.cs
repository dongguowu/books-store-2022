using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Abstractions;

public interface IBookRepository
{
    void Insert(Book book);
}
