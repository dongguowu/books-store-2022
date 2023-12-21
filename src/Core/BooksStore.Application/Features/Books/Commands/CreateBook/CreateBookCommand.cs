using BooksStore.Application.Abstractions.Messaging;

namespace BooksStore.Application.Features.Books.Commands.CreateBook;

public sealed record CreateBookCommand(string Title, DateTime Created) : ICommand<Guid>;
