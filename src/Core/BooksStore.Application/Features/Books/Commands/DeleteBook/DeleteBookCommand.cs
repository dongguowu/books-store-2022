using MediatR;

namespace BooksStore.Application.Features.Books.Commands.DeleteBook;

public sealed record DeleteBookCommand(Guid Id) : IRequest<bool>;
