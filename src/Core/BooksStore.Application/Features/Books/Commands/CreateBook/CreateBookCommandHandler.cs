using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BooksStore.Application.Features.Books.Commands.CreateBook;

public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IBookRepository _bookRepository;
    private readonly ILogger<CreateBookCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork,
        ILogger<CreateBookCommandHandler> logger)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Creating a new Book(title:{request.Title})");

        var book = new Book(request.Title);

        _bookRepository.Insert(book);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"A book(id:{book.Id},title:{book.Title}) created.");
        return book.Id;
    }
}
