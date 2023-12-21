using BooksStore.Core.BookAggregate.Commands;
using MediatR;
using SharedKernel.Interfaces;

namespace BooksStore.Core.BookAggregate.CommandHandlers;

public class BookCommandHandler : IRequestHandler<CreateBookCommand, bool>
{
    private readonly IRepository<Book> _rep;

    public BookCommandHandler(IRepository<Book> rep)
    {
        _rep = rep;
    }

    public async Task<bool> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(request.Title, request.Price);
        await _rep.AddAsync(book, cancellationToken);

        return true;
    }
}
