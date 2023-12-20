using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BooksStore.Application.Books.Commands;
public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateBookCommandHandler> _logger;

    public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, ILogger<CreateBookCommandHandler> logger)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {

        _logger.LogInformation($"Creating a new Book(title:{request.Title})");

        var book = new Book(Guid.NewGuid(), request.Title, request.Created);

        _bookRepository.Insert(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"A book(id:{book.Id},title:{book.Title}) created.");
        return book.Id;
    }
}
