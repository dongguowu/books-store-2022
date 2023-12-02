using BooksStore.Domain.Entities;

namespace BooksStore.Domain.Abstractions;
public interface IbookRepository
{
    void Insert(Book book);
}
