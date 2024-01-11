using MediatR;

namespace BooksStore.Application.Features.BookCategory.Queries.GetAllBookCategories;

public sealed record GetAllBookCategoryQuery : IRequest<List<BookCategoryDto>>;
