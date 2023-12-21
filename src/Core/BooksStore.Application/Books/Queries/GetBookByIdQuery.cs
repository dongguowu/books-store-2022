using BooksStore.Application.Abstractions.Messaging;

namespace BooksStore.Application.Books.Queries;

public sealed record GetBookByIdQuery(Guid BookId) : IQuery<BookResponse>;
