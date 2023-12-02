using BooksStore.Application.Abstractions.Messaging;

namespace BooksStore.Application.Books.Commands;
public sealed record CreateBookCommand(string Title, DateTime Created) : ICommand<Guid>;
