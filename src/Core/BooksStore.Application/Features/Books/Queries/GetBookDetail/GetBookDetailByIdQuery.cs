using MediatR;

namespace BooksStore.Application.Features.Books.Queries.GetBookDetail;

public sealed record GetBookDetailByIdQuery(Guid Id) : IRequest<BookDetailDto>;
