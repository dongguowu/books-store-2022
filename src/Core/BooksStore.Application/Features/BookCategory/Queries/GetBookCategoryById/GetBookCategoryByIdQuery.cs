using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetBookCategoryById;

public record GetBookCategoryByIdQuery(Guid Id) : IRequest<BookCategoryDetailDto>
{
}
