using SharedKernel.Exceptions;

namespace BooksStore.Domain.Exceptions;
public sealed class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(Guid bookId) : base($"The book with the identifier {bookId} was not found.") { }
}
