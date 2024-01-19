using BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;
using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryByName;

public sealed record GetBookCategoryByNameQuery(string Name) : IRequest<Domain.Entities.BookCategory>,
    IRequest<BookCategoryDetailDto>
{
}
