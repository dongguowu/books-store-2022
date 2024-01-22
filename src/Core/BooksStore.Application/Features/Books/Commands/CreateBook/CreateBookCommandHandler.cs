using BooksStore.Application.Abstractions.Messaging;
using BooksStore.Domain.Abstractions;
using BooksStore.Domain.Entities;
using Microsoft.Extensions.Logging;
using SharedKernel.Interfaces;

namespace BooksStore.Application.Features.Books.Commands.CreateBook;

public sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IRepository<Book> _bookRepository;
    private readonly ILogger<CreateBookCommandHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookCommandHandler(IRepository<Book> bookRepository, IUnitOfWork unitOfWork,
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

        await _bookRepository.AddAsync(book, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation($"A book(id:{book.Id},title:{book.Title}) created.");
        return book.Id;
    }
}
