using BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;
using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;

public sealed record GetBookCategoryByNameQuery(string Name) : IRequest<Domain.Entities.BookCategory>,
    IRequest<BookCategoryDetailDto>
{
}
