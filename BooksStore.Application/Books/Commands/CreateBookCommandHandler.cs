using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;

namespace BooksStore.Application.Books.Commands;
public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IbookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IbookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book(Guid.NewGuid(), request.Title, request.Created);

        _bookRepository.Insert(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}
